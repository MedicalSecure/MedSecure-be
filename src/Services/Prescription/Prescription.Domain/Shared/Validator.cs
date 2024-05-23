using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prescription.Domain.Shared
{
    public abstract class Validator
    {
        public static string? isNotNullOrWhiteSpace(string value, string paramName, bool throwError = true)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                if (throwError == false) return $"{paramName} cannot be null, empty, or whitespace.";
                throw new DomainException($"{paramName} cannot be null, empty, or whitespace.");
            }
            return null;
        }

        public static string? isNotNull(object? value, string paramName, bool throwError = true)
        {
            if (value == null)
            {
                if (throwError == false) return $"{paramName} cannot be null";
                throw new DomainException($"{paramName} cannot be null");
            }
            return null;
        }

        public static string? isGuidValid(Guid? value, string paramName, bool throwError = true)
        {
            if (value == null)
            {
                if (throwError == false) return $"{paramName} cannot be null";
                throw new DomainException($"{paramName} cannot be null");
            }
            if (value == Guid.Empty)
            {
                if (throwError == false) return $"{paramName} cannot be Empty";
                throw new DomainException($"{paramName} cannot be Empty");
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
                throw new DomainException($"{paramName} must be between 0 and 23.");
            }
            return null;
        }
    }
}