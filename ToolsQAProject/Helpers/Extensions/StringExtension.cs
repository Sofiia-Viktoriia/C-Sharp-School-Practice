namespace ToolsQAProject.Helpers.Extensions
{
    public static class StringExtension
    {
        public static string TextAfter(this string value, string search)
        {
            return value[(value.IndexOf(search) + search.Length)..];
        }
    }
}
