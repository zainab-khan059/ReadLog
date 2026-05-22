using ReadLog.Controllers; // Connects to our middleman controllers
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using ReadLog.Database;    // Connects to our Database helper for direct queries if needed (try to keep this in controllers though!)

namespace ReadLog.Forms
{
    public partial class AddEditBookForm : Form
    {
        private int bookId = -1;
        private bool isEditMode = false;

        // Connect to our middleman architecture tier
        private BookController _bookController = new BookController();

        public AddEditBookForm()
        {
            InitializeComponent();
            InitializeDropdownOptions();
        }

        public AddEditBookForm(int id)
        {
            InitializeComponent();
            InitializeDropdownOptions();

            bookId = id;
            isEditMode = true;

            LoadBookData();
        }

        
        // Keep dropdown setup bundled cleanly together
        private void InitializeDropdownOptions()
        {
            cmbGenre.Items.Clear();
            cmbGenre.Items.AddRange(AppData.Genres);

            cmbStatus.Items.Clear();
            cmbStatus.Items.AddRange(AppData.Status);
        }

        // LOAD DATA VIA LAYER MIDDLEMAN
        private void LoadBookData()
        {
            try
            {
                DataRow row = _bookController.GetBookDetails(bookId);

                if (row != null)
                {
                    txtTitle.Text = row["Title"].ToString();
                    txtAuthor.Text = row["Author"].ToString();
                    cmbGenre.Text = row["Genre"].ToString();
                    numYear.Value = Convert.ToDecimal(row["PublicationYear"]);
                    cmbStatus.Text = row["ReadingStatus"].ToString();
                    numPages.Value = Convert.ToDecimal(row["TotalPages"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed loading book records: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // SAVE LOGIC HANDLED EXCLUSIVELY VIA CONTROLLER
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Reset error if you have an lblError indicator
            if (lblError != null) lblError.Text = "";

            string title = txtTitle.Text.Trim();
            string author = txtAuthor.Text.Trim();

            if (string.IsNullOrEmpty(title))
            {
                if (lblError != null) lblError.Text = "Title is required.";
                else MessageBox.Show("Title is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(author))
            {
                if (lblError != null) lblError.Text = "Author is required.";
                else MessageBox.Show("Author is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                bool success;

                if (isEditMode)
                {
                    success = _bookController.UpdateBook(bookId, title, author, cmbGenre.Text, (int)numYear.Value, cmbStatus.Text, (int)numPages.Value);
                }
                else
                {
                    success = _bookController.AddBook(title, author, cmbGenre.Text, (int)numYear.Value, cmbStatus.Text, (int)numPages.Value);
                }

                if (success)
                {
                    MessageBox.Show("Book saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not process save option: {ex.Message}", "Processing Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Discard changes?", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

       
        // Form_Load handles double verification safely
        private void AddEditBookForm_Load(object sender, EventArgs e)
        {
            InitializeDropdownOptions();
        }
    }
}