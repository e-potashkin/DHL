namespace DHL.Common.Extensions
{
    public static class StringExtensions
    {
        public static string ConvertToHtmlLtGtSymbol(this string input) => input.Replace("<", "&lt;").Replace(">", "&gt;");

        public static string RemoveLtGtSymbol(this string input) => input.Replace("&lt;", string.Empty).Replace("&gt;", string.Empty);
    }
}
