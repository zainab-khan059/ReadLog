using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ReadLog
{
    public partial class BookDetailForm : Form
    {
        private int bookId;
        // Sample values

        public BookDetailForm(int id)
        {
            InitializeComponent();

            bookId = id;

            LoadRatings();
            LoadBookDetails();
        }


        // LOAD BOOK DATA
        private void LoadBookDetails()
        {
            using (SqlConnection conn =
                new SqlConnection(DatabaseHelper.connectionString))
            {
                conn.Open();

                string query =
                    "SELECT * FROM Books WHERE Id=@Id";

                SqlCommand cmd =
                    new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Id", bookId);

                SqlDataReader reader =
                    cmd.ExecuteReader();

                if (reader.Read())
                {
                    lblTitle.Text =
                        reader["Title"].ToString();

                    lblAuthor.Text =
                        reader["Author"].ToString();

                    lblGenre.Text =
                        reader["Genre"].ToString();

                    lblStatus.Text =
                        reader["ReadingStatus"].ToString();

                    lblPages.Text =
                        reader["TotalPages"].ToString();

                    // Current page
                    int currentPage = 0;

                    if (reader["CurrentPage"] != DBNull.Value)
                    {
                        currentPage =
                            Convert.ToInt32(
                                reader["CurrentPage"]
                            );
                    }

                    numCurrentPage.Value = currentPage;

                    // Total pages
                    int totalPages =
                        Convert.ToInt32(
                            reader["TotalPages"]
                        );

                    // Progress %
                    int progress = 0;

                    if (totalPages > 0)
                    {
                        progress =
                            (currentPage * 100) / totalPages;
                    }

                    if (progress > 100)
                    {
                        progress = 100;
                    }

                    progressReading.Value = progress;

                    // Rating
                    if (reader["Rating"] != DBNull.Value)
                    {
                        cmbRating.SelectedItem =
                            reader["Rating"].ToString() + " Stars";
                    }

                    // Review
                    if (reader["Review"] != DBNull.Value)
                    {
                        txtReview.Text =
                            reader["Review"].ToString();
                    }
                }
            }
        }
        // LOAD RATING OPTIONS
        private void LoadRatings()
        {
            cmbRating.Items.Add("1 Star");
            cmbRating.Items.Add("2 Stars");
            cmbRating.Items.Add("3 Stars");
            cmbRating.Items.Add("4 Stars");
            cmbRating.Items.Add("5 Stars");

            cmbRating.SelectedIndex = 4;
        }



        // SAVE REVIEW BUTTON
        private void btnSaveReview_Click(
     object sender,
     EventArgs e)
        {
            // Get rating number
            int rating = 0;

            if (cmbRating.SelectedIndex >= 0)
            {
                rating =
                    cmbRating.SelectedIndex + 1;
            }

            string review =
                txtReview.Text;

            using (SqlConnection conn =
                new SqlConnection(
                    DatabaseHelper.connectionString))
            {
                conn.Open();

                string query =
                    @"UPDATE Books
              SET
                Rating=@Rating,
                Review=@Review
              WHERE Id=@Id";

                SqlCommand cmd =
                    new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue(
                    "@Rating",
                    rating
                );

                cmd.Parameters.AddWithValue(
                    "@Review",
                    review
                );

                cmd.Parameters.AddWithValue(
                    "@Id",
                    bookId
                );

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show(
                "Review saved successfully!"
            );
        }

        // DELETE BOOK BUTTON
        private void btnDelete_Click(
            object sender,
            EventArgs e)
        {
            DialogResult result =
                MessageBox.Show(
                    "Are you sure you want to delete this book?",
                    "Delete Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

            if (result == DialogResult.Yes)
            {
                MessageBox.Show(
                    "Book deleted successfully!"
                );

                this.Close();
            }
        }
        private void btnUpdateProgress_Click(
    object sender,
    EventArgs e)
        {
            int currentPage =
                (int)numCurrentPage.Value;

            int totalPages =
                Convert.ToInt32(lblPages.Text);

            using (SqlConnection conn =
                new SqlConnection(
                    DatabaseHelper.connectionString))
            {
                conn.Open();

                string query =
                    @"UPDATE Books
              SET CurrentPage=@CurrentPage
              WHERE Id=@Id";

                SqlCommand cmd =
                    new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue(
                    "@CurrentPage",
                    currentPage
                );

                cmd.Parameters.AddWithValue(
                    "@Id",
                    bookId
                );

                cmd.ExecuteNonQuery();
            }

            // UPDATE BAR
            int percent = 0;

            if (totalPages > 0)
            {
                percent =
                    (currentPage * 100) / totalPages;
            }

            if (percent > 100)
            {
                percent = 100;
            }

            progressReading.Value = percent;

            MessageBox.Show(
                "Progress updated!"
            );

            // Reload form data
            LoadBookDetails();
        }
    }
}
