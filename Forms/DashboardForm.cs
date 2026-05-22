using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ReadLog
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
            LoadDashboard();
        }
        private void LoadDashboard()
        {
            using (SqlConnection conn =
                new SqlConnection(
                    DatabaseHelper.connectionString))
            {
                conn.Open();

                // TOTAL READ
                string readQuery =
                    @"SELECT COUNT(*)
              FROM Books
              WHERE ReadingStatus='Read'";

                SqlCommand readCmd =
                    new SqlCommand(readQuery, conn);

                int totalRead =
                    Convert.ToInt32(
                        readCmd.ExecuteScalar()
                    );

                lblTotalRead.Text =
                    totalRead.ToString();

                // CURRENTLY READING
                string currentQuery =
                    @"SELECT COUNT(*)
              FROM Books
              WHERE ReadingStatus='Currently Reading'";

                SqlCommand currentCmd =
                    new SqlCommand(currentQuery, conn);

                int currentReading =
                    Convert.ToInt32(
                        currentCmd.ExecuteScalar()
                    );

                lblCurrentlyReading.Text =
                    currentReading.ToString();

                // RECENT BOOKS
                lstRecentBooks.Items.Clear();

                string recentQuery =
                    @"SELECT TOP 5 Title
              FROM Books
              ORDER BY Id DESC";

                SqlCommand recentCmd =
                    new SqlCommand(recentQuery, conn);

                SqlDataReader reader =
                    recentCmd.ExecuteReader();

                while (reader.Read())
                {
                    lstRecentBooks.Items.Add(
                        reader["Title"].ToString()
                    );
                }

                reader.Close();

                // GOAL DATA
                string goalQuery =
                    @"SELECT TOP 1 *
              FROM ReadingGoals
              ORDER BY GoalYear DESC";

                SqlCommand goalCmd =
                    new SqlCommand(goalQuery, conn);

                SqlDataReader goalReader =
                    goalCmd.ExecuteReader();

                if (goalReader.Read())
                {
                    int target =
                        Convert.ToInt32(
                            goalReader["TargetBooks"]
                        );

                    int completed =
                        Convert.ToInt32(
                            goalReader["CompletedBooks"]
                        );

                    lblGoal.Text =
                        completed + " / " + target;

                    int percent = 0;

                    if (target > 0)
                    {
                        percent =
                            (completed * 100) / target;
                    }

                    if (percent > 100)
                    {
                        percent = 100;
                    }

                    progressGoal.Value = percent;

                    lblGoalPercent.Text =
                        percent + "% complete";
                }

                goalReader.Close();
            }
        }
        private void btnLibrary_Click(object sender, EventArgs e)
        {
            LibraryForm libForm = new LibraryForm(this); // send dashboard
            this.Hide();
            libForm.Show();
        }
        private void btnAddBook_Click(object sender, EventArgs e)
        {
            AddEditBookForm form = new AddEditBookForm(this); // give it dashboard
            this.Hide();
            form.Show();
        }
        private void btnReadingGoal_Click(object sender, EventArgs e)
        {
            ReadingGoalForm form = new ReadingGoalForm(this);
            this.Hide();
            form.Show();
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close(); // or this.Hide() depending on your flow
        }

    }
}