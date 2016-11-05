using System.Collections.Generic;
using System.Linq;
using MyBookLibrary.Service.ExtensionMethods;
using MyBookLibrary.Service.Model;

namespace MyBookLibrary.Service
{
    public class BookAggrService : IBookAggrService
    {
        public List<Series> GroupBySeries(List<Book> books)
        {
            return books
                .RemoveDuplicates()
                .GroupBy(b => b.Series)
                .Select(b => new Series
                {
                    Name = b.Key,
                    Count = b.Count(),
                    Pages = b.Sum(x => x.Pages),
                    Minutes = b.Sum(x => x.Minutes),
                    AvgRating = b.Average(x => x.Ratings),
                    Authors = books.Where(x => x.Series.Equals(b.Key.ToString())).Select(x => x.Author).FirstOrDefault(),
                    Books = books.Where(x => x.Series.Equals(b.Key.ToString())).OrderBy(y => y.SeriesOrder).ToList()
                })
                .OrderBy(b => b.Name)
                .ToList();
        }
    }
}
