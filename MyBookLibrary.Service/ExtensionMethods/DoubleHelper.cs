using System;

namespace MyBookLibrary.Service.ExtensionMethods
{
    public static class DoubleHelper
    {
        public static double ToDecimalPlace(this double? value, int decimalPlace)
        {
            if (value == null)
            return 0;

            var dec = (double) value;

            var mult = Math.Pow(10.0, decimalPlace);
            return Math.Truncate(dec * mult) / mult;
        }
    }
}
