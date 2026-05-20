using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ReadLog
{
    public partial class LoginForm : Form
    {
        // Database connection string
        string connectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;
              Initial Catalog=ReadLogDB;
              Integrated Security=True";

        public LoginForm()
        {
            InitializeComponent();

            // Hide password characters
            txtPassword.UseSystemPasswordChar = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Clear old error message
            lblError.Text = "";

            // Get user input
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Check if fields are empty
            if (username == "" || password == "")
            {
                lblError.Text = "Please enter username and password.";
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // SQL query
                    string query = "SELECT COUNT(*) FROM Users " +
                                   "WHERE Username=@username AND Password=@password";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    // Parameters
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    // Execute query
                    int count = (int)cmd.ExecuteScalar();

                    // If user exists
                    if (count > 0)
                    {
                        MessageBox.Show("Login Successful!");

                        // Open Dashboard
                        DashboardForm dashboard = new DashboardForm();
                        dashboard.Show();

                        // Hide Login Form
                        this.Hide();
                    }
                    else
                    {
                        lblError.Text = "Invalid username or password.";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message);
            }
        }

       
    }
}
