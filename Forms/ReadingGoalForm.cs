using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ReadLog
{
    public partial class ReadingGoalForm : Form
    {
        private Form dashboard;
        public ReadingGoalForm()
        {
            InitializeComponent();

            LoadGoalHistory();
        }
        public ReadingGoalForm(Form dash)
        {
            InitializeComponent();
            dashboard = dash;
        }

        // LOAD SAMPLE HISTORY
        private void LoadGoalHistory()
        {
            dgvHistory.Rows.Clear();

            dgvHistory.Rows.Add(
                "2024",
                "10",
                "12",
                "Completed"
            );

            dgvHistory.Rows.Add(
                "2025",
                "15",
                "9",
                "In Progress"
            );
        }



        // SAVE GOAL BUTTON
        private void btnSaveGoal_Click(
     object sender,
     EventArgs e)
        {
            using (SqlConnection conn =
                new SqlConnection(
                    DatabaseHelper.connectionString))
            {
                conn.Open();

                int currentYear =
                    DateTime.Now.Year;

                // Check if year already exists
                string checkQuery =
                    @"SELECT COUNT(*) FROM ReadingGoals
              WHERE GoalYear=@Year";

                SqlCommand checkCmd =
                    new SqlCommand(checkQuery, conn);

                checkCmd.Parameters.AddWithValue(
                    "@Year",
                    currentYear
                );

                int exists =
                    (int)checkCmd.ExecuteScalar();

                SqlCommand cmd;

                if (exists > 0)
                {
                    // UPDATE EXISTING GOAL
                    string updateQuery =
                        @"UPDATE ReadingGoals
                  SET
                    TargetBooks=@Target,
                    CompletedBooks=@Completed
                  WHERE GoalYear=@Year";

                    cmd =
                        new SqlCommand(updateQuery, conn);
                }
                else
                {
                    // INSERT NEW GOAL
                    string insertQuery =
                        @"INSERT INTO ReadingGoals
                (
                    GoalYear,
                    TargetBooks,
                    CompletedBooks
                )
                VALUES
                (
                    @Year,
                    @Target,
                    @Completed
                )";

                    cmd =
                        new SqlCommand(insertQuery, conn);
                }

                cmd.Parameters.AddWithValue(
                    "@Year",
                    currentYear
                );

                cmd.Parameters.AddWithValue(
                    "@Target",
                    numGoal.Value
                );

                cmd.Parameters.AddWithValue(
                    "@Completed",
                    numCompleted.Value
                );

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show(
                "Reading goal saved successfully!"
            );
        }



        private void ReadingGoalForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            dashboard.Show();
        }

        private void btnClearGoals_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to clear all goals? This action cannot be undone.",
                "Confirm Clear",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(DatabaseHelper.connectionString))
                {
                    conn.Open();
                    string deleteQuery = "DELETE FROM ReadingGoals";
                    SqlCommand cmd = new SqlCommand(deleteQuery, conn);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("All goals have been cleared.");
            }
        }
    }
}