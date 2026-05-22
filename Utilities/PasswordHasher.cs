using System;
using System.Security.Cryptography;
using System.Text;

namespace ReadLog.Utilities
{
    public static class PasswordHasher
    {
        // Converts a plain password into a secure SHA256 string
        public static string HashPassword(string password)
        {
            if (string.IsNullOrEmpty(password)) return string.Empty;

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        // Compares a typed password with the hashed password stored in the database
        public static bool VerifyPassword(string enteredPassword, string storedHash)
        {
            string hashedInput = HashPassword(enteredPassword);
            return string.Equals(hashedInput, storedHash, StringComparison.OrdinalIgnoreCase);
        }
    }
}
