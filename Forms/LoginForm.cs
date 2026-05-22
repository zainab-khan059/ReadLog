using System;
using System.Windows.Forms;
using ReadLog.Controllers; // Connects to your middleman controllers
using ReadLog.Utilities;   // Connects to your validation/security helpers
using ReadLog.Models;      // Connects to your User model

namespace ReadLog.Forms
{
    public partial class LoginForm : Form
    {
        // Create an instance of the UserController middleman
        private UserController _userController = new UserController();

        public LoginForm()
        {
            InitializeComponent();
        }

        // 🛠️ The Login Button Click Event
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // 1. Grab inputs from your textboxes (Change txtUsername/txtPassword to match your textbox names!)
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // 2. Use Utilities to validate input first (No empty fields allowed)
            if (!ValidationHelper.IsRequiredFieldPresent(username) || !ValidationHelper.IsRequiredFieldPresent(password))
            {
                MessageBox.Show("Please enter both username and password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 3. Ask the Controller to verify the user against the database
                User loggedInUser = _userController.Login(username, password);

                if (loggedInUser != null)
                {
                    MessageBox.Show($"Welcome back, {loggedInUser.Username}!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 4. Open your Dashboard and hide this login screen
                    DashboardForm dashboard = new DashboardForm();
                    dashboard.Show();
                    this.Hide();
                }
                else
                {
                    // If controller returns null, login failed
                    MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // If anything goes wrong with the database connection, catch it here safely
                MessageBox.Show($"An error occurred while connecting to the database: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}