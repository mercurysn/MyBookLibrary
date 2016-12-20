using System.Collections.Generic;
using System.Linq;
using MyBookLibrary.Service.Model;

namespace MyBookLibrary.Service.ExtensionMethods
{
    public static class BookGroupDtoHelper
    {
        public static IEnumerable<BookGroupDto> ComputeRankPercentile(this IEnumerable<BookGroupDto> bookGroups)
        {
            bookGroups = bookGroups.OrderByDescending(b => b.TotalTime).ToList();

            int rank = 1;

            foreach (var bookGroup in bookGroups)
            {
                bookGroup.Rank = rank++;
                bookGroup.Percentile = bookGroup.Rank.CalculatePercentile(bookGroups.Count() - 1);
            }

            return bookGroups;
        }
    }
}
