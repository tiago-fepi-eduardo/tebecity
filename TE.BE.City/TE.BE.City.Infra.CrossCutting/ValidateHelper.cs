
using System.Text.RegularExpressions;

namespace TE.BE.City.Infra.CrossCutting
{
    /// <summary>
    /// This classes is only a concept example. Date validation can be done on model or service classes
    /// </summary>
    public static class ValidateHelper
    {
        /// <summary>
        /// Minimun 16 digits only numbers.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        //public static bool ValidateCreditCardNumber(long value)
        //{
        //    var pattern = @"^\d{16,}$";

        //    return Regex.Match(value.ToString(), pattern, RegexOptions.IgnoreCase).Success;
        //}

        // Other examples of classes would be:
        // Format Decimal Currency
        // Convert Currency to Other Nationality
        // Apply security checkup
        // ... So on.
    }
}
