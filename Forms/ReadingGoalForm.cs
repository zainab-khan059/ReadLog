using System;
using System.Data;
using System.Windows.Forms;
using ReadLog.Controllers; // Connects to our middleman controllers

namespace ReadLog.Forms
{
    public partial class ReadingGoalForm : Form
    {
   

        // Connect to our middleman tier controller
        private GoalController _goalController = new GoalController();

        public ReadingGoalForm()
        {
            InitializeComponent();
            LoadGoalHistory();
        }

        
        // 1. LOAD REAL GOAL HISTORY FROM CONTROLLER
        private void LoadGoalHistory()
        {
            dgvHistory.Rows.Clear();

            try
            {
                DataTable dt = _goalController.GetGoalHistory();

                foreach (DataRow row in dt.Rows)
                {
                    int target = Convert.ToInt32(row["TargetBooks"]);
                    int completed = Convert.ToInt32(row["CompletedBooks"]);
                    string status = completed >= target ? "Completed" : "In Progress";

                    dgvHistory.Rows.Add(
                        row["GoalYear"].ToString(),
                        target.ToString(),
                        completed.ToString(),
                        status
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load reading goals: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 2. SAVE/UPDATE VIA CONTROLLER
        private void btnSaveGoal_Click(object sender, EventArgs e)
        {
            int currentYear = DateTime.Now.Year;
            int target = (int)numGoal.Value;
            int completed = (int)numCompleted.Value;

            try
            {
                bool success = _goalController.SaveOrUpdateGoal(currentYear, target, completed);

                if (success)
                {
                    MessageBox.Show("Reading goal saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadGoalHistory(); // Refresh the grid automatically
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not save goal profile: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 3. CLEAR ENTIRE TABLE VIA CONTROLLER
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
                try
                {
                    _goalController.ClearAllGoals();
                    MessageBox.Show("All goals have been cleared.", "Cleared", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadGoalHistory(); // Refresh the empty grid
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to clear goal contents: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

       
    }
}