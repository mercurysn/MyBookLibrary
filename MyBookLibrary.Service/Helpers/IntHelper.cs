using System;

namespace MyBookLibrary.Service.Helpers
{
    public class IntHelper
    {
        private static readonly Random Random = new Random();

        public static int GeneratingRandom(int start, int end)
        {
            return Random.Next(start, end);
        }
    }
}
