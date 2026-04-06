using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace QuanLyTietKiemNganHang.Helpers
{
    public static class FormValidator
    {
        public static bool Required(string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }

        public static bool IsPhone(string value)
        {
            return Regex.IsMatch(value ?? string.Empty, @"^(0|\+84)\d{9,10}$");
        }

        public static bool IsEmail(string value)
        {
            return Regex.IsMatch(value ?? string.Empty, @"^[^\s@]+@[^\s@]+\.[^\s@]+$");
        }

        public static bool IsCitizenId(string value)
        {
            return Regex.IsMatch(value ?? string.Empty, @"^\d{12}$");
        }

        public static bool Positive(decimal value)
        {
            return value > 0;
        }

        public static string JoinErrors(IEnumerable<string> errors)
        {
            return string.Join(Environment.NewLine, errors.Where(e => !string.IsNullOrWhiteSpace(e)));
        }
    }
}
