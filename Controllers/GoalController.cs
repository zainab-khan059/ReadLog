using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ReadLog.Models;
using ReadLog.Database;

namespace ReadLog.Controllers
{
    public class GoalController
    {
        // Tool to get reading goals for a specific user
        public List<Goal> GetGoalsByUserId(int userId)
        {
            List<Goal> goalList = new List<Goal>();
            string query = "SELECT * FROM Goals WHERE UserId = @UserId";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@UserId", userId)
            };

            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

            foreach (DataRow row in dt.Rows)
            {
                Goal goal = new Goal
                {
                    GoalID = Convert.ToInt32(row["Id"]),
                    TargetBooks = Convert.ToInt32(row["TargetBooks"]),
                    Year = Convert.ToDateTime(row["TargetDate"]).Year
                };
                goalList.Add(goal);
            }

            return goalList;
        }

        // Tool to add a new reading goal
        public bool AddGoal(int userId, int targetBooks, DateTime targetDate)
        {
            if (targetBooks <= 0) return false;

            string query = "INSERT INTO Goals (UserId, TargetBooks, TargetDate) VALUES (@UserId, @TargetBooks, @TargetDate)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@UserId", userId),
                new SqlParameter("@TargetBooks", targetBooks),
                new SqlParameter("@TargetDate", targetDate)
            };

            int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);
            return rowsAffected > 0;
        }
    }
}