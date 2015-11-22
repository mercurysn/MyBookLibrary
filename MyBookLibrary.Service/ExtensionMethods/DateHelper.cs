using System;

namespace MyBookLibrary.Service.ExtensionMethods
{
    public static class DateHelper
    {
        public static int ToDecade(this int year)
        {
            return (int)Math.Floor((decimal) (year / 10)) * 10;
        }
    }
}
