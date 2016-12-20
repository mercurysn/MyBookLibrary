namespace MyBookLibrary.Service.ExtensionMethods
{
    public static class IntHelper
    {
        public static int CalculatePercentile(this int value, int total)
        {
            return 100 - ((value - 1) * 100 / total);
        }
    }
}
