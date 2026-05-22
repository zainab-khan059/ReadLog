using ReadLog.Controllers; // Connects to our middleman controllers
using System;
using System.Data;
using System.Windows.Forms;
using ReadLog.Database;    // Connects to our Database helper for direct queries if needed (try to keep this in controllers though!)

namespace ReadLog.Forms
{
    public partial class LibraryForm : Form
    {
        private Form dashboard;
        private int selectedBookId = -1;

        // 1. Link our middleman controller
        private BookController _bookController = new BookController();

        public LibraryForm(Form dashboard)
        {
            InitializeComponent();
            this.dashboard = dashboard;

            LoadFilters();
            LoadBooks();
        }

        // LOAD FILTER OPTIONS (Kept local since it's pure UI configuration)
        private void LoadFilters()
        {
            cmbGenre.Items.Clear();
            cmbStatus.Items.Clear();
            cmbRating.Items.Clear();

            cmbGenre.Items.Add("All");
            // Assuming AppData class was moved or accessible. If it causes an error, make sure AppData namespace matches!
            cmbGenre.Items.AddRange(AppData.Genres);
            cmbGenre.SelectedIndex = 0;

            cmbStatus.Items.Clear();
            cmbStatus.Items.AddRange(AppData.Status);

            cmbRating.Items.Add("All");
            cmbRating.Items.Add("1 Star");
            cmbRating.Items.Add("2 Stars");
            cmbRating.Items.Add("3 Stars");
            cmbRating.Items.Add("4 Stars");
            cmbRating.Items.Add("5 Stars");
            cmbRating.SelectedIndex = 0;
        }

        // 2. LOAD BOOKS FROM CONTROLLER
        private void LoadBooks()
        {
            dgvBooks.Rows.Clear();

            try
            {
                // Request data via controller layer
                DataTable dt = _bookController.GetLibraryBooks();

                foreach (DataRow row in dt.Rows)
                {
                    dgvBooks.Rows.Add(
                        row["BookID"],
                        row["Title"],
                        row["Author"],
                        row["Genre"],
                        row["ReadingStatus"],
                        row["Rating"]
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load books: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // SEARCH BOOKS (Pure UI search logic over already-loaded table rows)
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string search = txtSearch.Text.ToLower();

            foreach (DataGridViewRow row in dgvBooks.Rows)
            {
                if (row.IsNewRow) continue;

                // Checking text contents safely across Title (cell 1) or Author (cell 2)
                string title = row.Cells[1].Value?.ToString().ToLower() ?? "";
                string author = row.Cells[2].Value?.ToString().ToLower() ?? "";

                row.Visible = title.Contains(search) || author.Contains(search);
            }
        }

        // OPEN BOOK DETAILS ON DOUBLE CLICK
        private void dgvBooks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int bookId = Convert.ToInt32(dgvBooks.Rows[e.RowIndex].Cells[0].Value);
                BookDetailForm form = new BookDetailForm(bookId);
                form.ShowDialog();
            }
        }

        private void dgvBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedBookId = Convert.ToInt32(dgvBooks.Rows[e.RowIndex].Cells[0].Value);
            }
        }

        // 3. DELETE VIA CONTROLLER
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedBookId == -1)
            {
                MessageBox.Show("Please select a book first.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show("Delete this book permanently?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool success = _bookController.DeleteBook(selectedBookId);

                    if (success)
                    {
                        MessageBox.Show("Book deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadBooks();
                        selectedBookId = -1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Could not delete book: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedBookId == -1)
            {
                MessageBox.Show("Please select a book first.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            AddEditBookForm editForm = new AddEditBookForm(selectedBookId);
            editForm.ShowDialog();
            LoadBooks();
        }

        private void LibraryForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            dashboard.Show();
        }
    }
}