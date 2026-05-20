using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ReadLog
{
    public partial class AddEditBookForm : Form
    {
        private int bookId = -1;
        private bool isEditMode = false;
        private Form dashboard;
        public AddEditBookForm()
        {
            InitializeComponent();

            LoadGenres();
            LoadStatuses();
        }
        public AddEditBookForm(int id)
        {
            InitializeComponent();

            LoadGenres();
            LoadStatuses();

            bookId = id;
            isEditMode = true;

            LoadBookData();
        }
        public AddEditBookForm(Form dash)
        {
            InitializeComponent();
            dashboard = dash;
        }
        // LOAD GENRE OPTIONS
        private void LoadGenres()
        {
            cmbGenre.Items.Add("Sci-Fi");
            cmbGenre.Items.Add("Fantasy");
            cmbGenre.Items.Add("Self Help");
            cmbGenre.Items.Add("Programming");
            cmbGenre.Items.Add("Education");
            cmbGenre.Items.Add("History");

            cmbGenre.SelectedIndex = 0;
        }

        // LOAD STATUS OPTIONS
        private void LoadStatuses()
        {
            cmbStatus.Items.Add("Currently Reading");
            cmbStatus.Items.Add("Read");
            cmbStatus.Items.Add("Want To Read");

            cmbStatus.SelectedIndex = 0;
        }

        // SAVE BUTTON
        private void btnSave_Click(
    object sender,
    EventArgs e)
        {
            lblError.Text = "";

            if (txtTitle.Text.Trim() == "")
            {
                lblError.Text = "Title is required.";
                return;
            }

            if (txtAuthor.Text.Trim() == "")
            {
                lblError.Text = "Author is required.";
                return;
            }

            using (SqlConnection conn =
                new SqlConnection(
                    DatabaseHelper.connectionString))
            {
                conn.Open();

                SqlCommand cmd;

                // EDIT MODE
                if (isEditMode)
                {
                    string query =
                        @"UPDATE Books
                SET
                    Title=@Title,
                    Author=@Author,
                    Genre=@Genre,
                    PublicationYear=@PublicationYear,
                    ReadingStatus=@ReadingStatus,
                    TotalPages=@TotalPages
                WHERE Id=@Id";

                    cmd =
                        new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue(
                        "@Id",
                        bookId
                    );
                }
                else
                {
                    // ADD MODE
                    string query =
                        @"INSERT INTO Books
                (
                    Title,
                    Author,
                    Genre,
                    PublicationYear,
                    ReadingStatus,
                    TotalPages
                )
                VALUES
                (
                    @Title,
                    @Author,
                    @Genre,
                    @PublicationYear,
                    @ReadingStatus,
                    @TotalPages
                )";

                    cmd =
                        new SqlCommand(query, conn);
                }

                cmd.Parameters.AddWithValue(
                    "@Title",
                    txtTitle.Text
                );

                cmd.Parameters.AddWithValue(
                    "@Author",
                    txtAuthor.Text
                );

                cmd.Parameters.AddWithValue(
                    "@Genre",
                    cmbGenre.Text
                );

                cmd.Parameters.AddWithValue(
                    "@PublicationYear",
                    numYear.Value
                );

                cmd.Parameters.AddWithValue(
                    "@ReadingStatus",
                    cmbStatus.Text
                );

                cmd.Parameters.AddWithValue(
                    "@TotalPages",
                    numPages.Value
                );

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show(
                "Book saved successfully!"
            );

            this.Close();
        }

        // CANCEL BUTTON
        private void btnCancel_Click(object sender, EventArgs e)
        {

            DialogResult result =
                MessageBox.Show(
                    "Discard changes?",
                    "Cancel",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void LoadBookData()
        {
            using (SqlConnection conn =
                new SqlConnection(
                    DatabaseHelper.connectionString))
            {
                conn.Open();

                string query =
                    "SELECT * FROM Books WHERE Id=@Id";

                SqlCommand cmd =
                    new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue(
                    "@Id",
                    bookId
                );

                SqlDataReader reader =
                    cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtTitle.Text =
                        reader["Title"].ToString();

                    txtAuthor.Text =
                        reader["Author"].ToString();

                    cmbGenre.Text =
                        reader["Genre"].ToString();

                    numYear.Value =
                        Convert.ToDecimal(
                            reader["PublicationYear"]
                        );

                    cmbStatus.Text =
                        reader["ReadingStatus"].ToString();

                    numPages.Value =
                        Convert.ToDecimal(
                            reader["TotalPages"]
                        );
                }
            }
        }

        private void AddEditBookForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            dashboard.Show();
        }
    }
}
