

namespace BacPatient.Domain.Shared
{
    public abstract class Validator
    {
        public static string? isNotNullOrWhiteSpace(string value, string paramName, bool throwError = true)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                if (throwError == false) return $"{paramName} cannot be null, empty, or whitespace.";
                throw new ArgumentException($"{paramName} cannot be null, empty, or whitespace.", paramName);
            }
            return null;
        }

        public static string? isHourValid(int value, string paramName, bool throwError = true)
        {
            if (value > 23 || value < 0)
            {
                if (throwError == false)
                {
                    return $"{paramName} must be between 0 and 23."; // Corrected message
                }
                throw new ArgumentException($"{paramName} must be between 0 and 23.", paramName);
            }
            return null;
        }
    }
}