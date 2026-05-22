using ReadLog.Controllers; // Hooks into controller layer structures
using System;
using System.Data;
using System.Windows.Forms;
using ReadLog.Database;    // Connects to our Database helper for direct queries if needed (try to keep this in controllers though!)

namespace ReadLog.Forms
{
    public partial class BookDetailForm : Form
    {
        private int bookId;

        // Connect to our middleman architecture tier
        private BookController _bookController = new BookController();

        public BookDetailForm(int id)
        {
            InitializeComponent();
            bookId = id;

            LoadRatings();
            LoadBookDetails();
        }

        // LOAD DATA VIA LAYER MIDDLEMAN
        private void LoadBookDetails()
        {
            try
            {
                DataRow row = _bookController.GetBookDetails(bookId);

                if (row != null)
                {
                    lblTitle.Text = row["Title"].ToString();
                    lblAuthor.Text = row["Author"].ToString();
                    lblGenre.Text = row["Genre"].ToString();
                    lblStatus.Text = row["ReadingStatus"].ToString();
                    lblPages.Text = row["TotalPages"].ToString();

                    int currentPage = row["CurrentPage"] != DBNull.Value ? Convert.ToInt32(row["CurrentPage"]) : 0;
                    numCurrentPage.Value = currentPage;

                    int totalPages = Convert.ToInt32(row["TotalPages"]);

                    // Compute Progress metrics locally inside view presentation tier
                    int progress = totalPages > 0 ? (currentPage * 100) / totalPages : 0;
                    if (progress > 100) progress = 100;
                    progressReading.Value = progress;

                    if (row["Rating"] != DBNull.Value)
                    {
                        cmbRating.SelectedItem = row["Rating"].ToString() + " Stars";
                    }

                    if (row["Review"] != DBNull.Value)
                    {
                        txtReview.Text = row["Review"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed loading book context summary profile: {ex.Message}", "System Query Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRatings()
        {
            cmbRating.Items.Clear();
            // Reusing core AppData constants collection array structure
            cmbRating.Items.AddRange(AppData.Ratings);
        }

        // CONTROL PERSISTENCE WITH EXPLICIT ARCHITECTURE ACTIONS
        private void btnSaveReview_Click(object sender, EventArgs e)
        {
            int rating = cmbRating.SelectedIndex >= 0 ? cmbRating.SelectedIndex + 1 : 0;
            string review = txtReview.Text;

            try
            {
                bool success = _bookController.UpdateBookReview(bookId, rating, review);
                if (success)
                {
                    MessageBox.Show("Review saved successfully!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed tracking user commentary modifications: {ex.Message}", "Save Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateProgress_Click(object sender, EventArgs e)
        {
            int currentPage = (int)numCurrentPage.Value;
            int totalPages = Convert.ToInt32(lblPages.Text);

            try
            {
                bool success = _bookController.UpdateReadingProgress(bookId, currentPage);

                if (success)
                {
                    int percent = totalPages > 0 ? (currentPage * 100) / totalPages : 0;
                    if (percent > 100) percent = 100;
                    progressReading.Value = percent;

                    MessageBox.Show("Progress updated!", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Synchronize and render visual controls data status fresh
                    LoadBookDetails();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not manipulate metric database states: {ex.Message}", "Processing Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}