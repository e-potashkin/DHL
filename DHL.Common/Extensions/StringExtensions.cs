using System.Linq;

namespace DHL.Common.Extensions
{
    public static class StringExtensions
    {
        public static string ConvertAmpToHtmlSymbol(this string input) => input.Replace("&", "&amp;");

        public static string ConvertToHtmlLtGtSymbol(this string input) => input.Replace("<", "&lt;").Replace(">", "&gt;");

        public static string RemoveLtGtSymbol(this string input) => input.Replace("&lt;", string.Empty).Replace("&gt;", string.Empty);

        public static string GetStreetName(this string input) => new string(input.Where(x => char.IsLetter(x) || char.IsPunctuation(x)).ToArray());

        public static string GetStreetNumber(this string input) => new string(input.Where(char.IsDigit).ToArray());
    }
}
