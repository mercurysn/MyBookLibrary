namespace MyBookLibrary.Service.ExtensionMethods
{
    public static class StringHelper
    {
        public static string ConcatAuthor(this string[] authors)
        {
            return string.Join(", ", authors);
        }
    }
}
