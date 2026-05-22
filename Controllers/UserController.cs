using System;
using System.Data;
using System.Data.SqlClient;
using ReadLog.Models;
using ReadLog.Database;

namespace ReadLog.Controllers
{
    public class UserController
    {
        // Tool to check if a user exists with the matching username and password (for LoginForm)
        public User Login(string username, string password)
        {
            // In a real app, you would hash the password here using your Utilities layer!
            string query = "SELECT * FROM Users WHERE Username = @Username AND Password = @Password";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Username", username),
                new SqlParameter("@Password", password)
            };

            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

            // If a row was found, the login is successful! Turn it into a User model.
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new User
                {
                    // Update these strings to match the exact column names in your Users database table
                    UserID = Convert.ToInt32(row["Id"]),
                    Username = row["Username"].ToString()
                };
            }

            return null; // Returns null if no user was found (wrong username/password)
        }

        // Tool to register a brand new user
        public bool RegisterUser(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            string query = "INSERT INTO Users (Username, Password) VALUES (@Username, @Password)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Username", username),
                new SqlParameter("@Password", password)
            };

            int rowsAffected = DatabaseHelper.ExecuteNonQuery(query, parameters);
            return rowsAffected > 0;
        }
    }
}
