using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ReadLog
{
    public partial class LibraryForm : Form

    {
        private Form dashboard;
        private int selectedBookId = -1;
        public LibraryForm(Form dashboard)
        {
            InitializeComponent();

            LoadFilters();
            LoadBooks();
            this.dashboard = dashboard;
        }

        // LOAD FILTER OPTIONS
        private void LoadFilters()
        {
            // Genre Filter
            cmbGenre.Items.Add("All");
            cmbGenre.Items.Add("Sci-Fi");
            cmbGenre.Items.Add("Fantasy");
            cmbGenre.Items.Add("Self Help");
            cmbGenre.Items.Add("Programming");
            cmbGenre.Items.Add("Education");
            cmbGenre.Items.Add("History");
            cmbGenre.SelectedIndex = 0;

            // Status Filter
            cmbStatus.Items.Add("All");
            cmbStatus.Items.Add("Read");
            cmbStatus.Items.Add("Currently Reading");
            cmbStatus.Items.Add("Want To Read");
            cmbStatus.SelectedIndex = 0;

            // Rating Filter
            cmbRating.Items.Add("All");
            cmbRating.Items.Add("1 Star");
            cmbRating.Items.Add("2 Stars");
            cmbRating.Items.Add("3 Stars");
            cmbRating.Items.Add("4 Stars");
            cmbRating.Items.Add("5 Stars");
            cmbRating.SelectedIndex = 0;
        }

        // LOAD SAMPLE BOOKS
        private void LoadBooks()
        {
            dgvBooks.Rows.Clear();

            using (SqlConnection conn =
                new SqlConnection(DatabaseHelper.connectionString))
            {
                conn.Open();

                string query = "SELECT * FROM Books";

                SqlCommand cmd =
                    new SqlCommand(query, conn);

                SqlDataReader reader =
                    cmd.ExecuteReader();

                while (reader.Read())
                {
                    dgvBooks.Rows.Add(
                        reader["Id"],
                        reader["Title"],
                        reader["Author"],
                        reader["Genre"],
                        reader["ReadingStatus"],
                        reader["Rating"]
                    );
                }
            }
        }

        // SEARCH BOOKS
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string search = txtSearch.Text.ToLower();

            foreach (DataGridViewRow row in dgvBooks.Rows)
            {
                if (row.IsNewRow)
                    continue;

                string title = row.Cells[0].Value.ToString().ToLower();
                string author = row.Cells[1].Value.ToString().ToLower();

                if (title.Contains(search) || author.Contains(search))
                {
                    row.Visible = true;
                }
                else
                {
                    row.Visible = false;
                }
            }
        }

        // OPEN BOOK DETAILS ON DOUBLE CLICK
        private void dgvBooks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int bookId = Convert.ToInt32(
                    dgvBooks.Rows[e.RowIndex].Cells["colId"].Value);

                BookDetailForm form = new BookDetailForm(bookId);

                form.ShowDialog();
            }
        }

        private void dgvBooks_CellClick(
    object sender,
    DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedBookId = Convert.ToInt32(
                    dgvBooks.Rows[e.RowIndex]
                    .Cells[0].Value
                );
            }
        }

        private void btnDelete_Click(
    object sender,
    EventArgs e)
        {
            if (selectedBookId == -1)
            {
                MessageBox.Show(
                    "Please select a book first."
                );

                return;
            }

            DialogResult result =
                MessageBox.Show(
                    "Delete this book permanently?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn =
                    new SqlConnection(
                        DatabaseHelper.connectionString))
                {
                    conn.Open();

                    string query =
                        "DELETE FROM Books WHERE Id=@Id";

                    SqlCommand cmd =
                        new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue(
                        "@Id",
                        selectedBookId
                    );

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show(
                    "Book deleted successfully!"
                );

                LoadBooks();

                selectedBookId = -1;
            }
        }
        private void btnEdit_Click(
    object sender,
    EventArgs e)
        {
            if (selectedBookId == -1)
            {
                MessageBox.Show(
                    "Please select a book first."
                );

                return;
            }

            AddEditBookForm editForm =
                new AddEditBookForm(selectedBookId);

            editForm.ShowDialog();

            LoadBooks();
        }

        private void LibraryForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            dashboard.Show();
        }


    }
    
}
