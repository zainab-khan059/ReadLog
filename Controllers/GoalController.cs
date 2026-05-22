using System;
using System.Data;
using System.Data.SqlClient;
using ReadLog.Database;

namespace ReadLog.Controllers
{
    public class GoalController
    {
        // 1. Fetch all goal records to populate the history table
        public DataTable GetGoalHistory()
        {
            string query = "SELECT GoalYear, TargetBooks, CompletedBooks FROM ReadingGoals ORDER BY GoalYear DESC";
            return DatabaseHelper.ExecuteQuery(query);
        }

        // 2. Save or update a reading goal for a specific year
        public bool SaveOrUpdateGoal(int year, int targetBooks, int completedBooks)
        {
            // Check if a goal already exists for this year
            string checkQuery = "SELECT COUNT(*) FROM ReadingGoals WHERE GoalYear = @Year";
            SqlParameter[] checkParams = { new SqlParameter("@Year", year) };

            DataTable dt = DatabaseHelper.ExecuteQuery(checkQuery, checkParams);
            int exists = dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0][0]) : 0;

            string saveQuery;
            if (exists > 0)
            {
                saveQuery = @"UPDATE ReadingGoals 
                              SET TargetBooks = @Target, CompletedBooks = @Completed 
                              WHERE GoalYear = @Year";
            }
            else
            {
                saveQuery = @"INSERT INTO ReadingGoals (GoalYear, TargetBooks, CompletedBooks) 
                              VALUES (@Year, @Target, @Completed)";
            }

            SqlParameter[] saveParams = {
                new SqlParameter("@Year", year),
                new SqlParameter("@Target", targetBooks),
                new SqlParameter("@Completed", completedBooks)
            };

            return DatabaseHelper.ExecuteNonQuery(saveQuery, saveParams) > 0;
        }

        // 3. Clear all records from the goals table
        public bool ClearAllGoals()
        {
            string query = "DELETE FROM ReadingGoals";
            return DatabaseHelper.ExecuteNonQuery(query) > 0;
        }
        // 4. Fetch the target goal row tracking data specifically for the current year
        public DataRow GetLatestGoalData(int year)
        {
            string query = "SELECT TargetBooks, CompletedBooks FROM ReadingGoals WHERE GoalYear = @Year";
            SqlParameter[] parameters = { new SqlParameter("@Year", year) };

            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }
        public DataTable GetLatestGoalData()
        {
            // Fetches your tracking data to fill the dashboard grid view
            string query = "SELECT TOP 1 TargetBooks, BooksCompleted FROM ReadingGoals ORDER BY Id DESC";
            return DatabaseHelper.ExecuteQuery(query);
        }
    }
}