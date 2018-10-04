using System.Text.RegularExpressions;

namespace Traveler
{
    static class Helper
    {
        public static bool IsNumeric(string text)
        {
            return Regex.IsMatch(text, "(^[0-9]+$)");
        }
    }
}
