using System;

namespace ReadLog.Utilities
{
    public static class ValidationHelper
    {
        // Helper to check if a string is empty or just spaces
        public static bool IsRequiredFieldPresent(string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }

        // Helper to ensure an input meets a minimum length (e.g., passwords must be 6+ characters)
        public static bool IsMinimumLength(string input, int minLength)
        {
            if (input == null) return false;
            return input.Length >= minLength;
        }

        // Helper to check if a string is a valid number (useful for target reading goals)
        public static bool IsValidPositiveNumber(string input, out int result)
        {
            return int.TryParse(input, out result) && result > 0;
        }
    }
}
