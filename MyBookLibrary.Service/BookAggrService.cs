using System;
using System.Collections.Generic;
using System.Linq;
using MyBookLibrary.Service.ExtensionMethods;
using MyBookLibrary.Service.Model;

namespace MyBookLibrary.Service
{
    public class BookAggrService : IBookAggrService
    {
        public List<Author> GroupByAuthor(List<Book> books)
        {
            return books
                .RemoveDuplicates()
                .GroupBy(b => b.Author[0])
                .Select(b => new Author
                {
                    Name = b.Key,
                    Count = b.Count(),
                    Pages = b.Sum(x => x.Pages),
                    Minutes = b.Sum(x => x.Minutes),
                    AvgRating = b.Average(x => x.Ratings),
                    Books = books.Where(x => x.Author[0].Equals(b.Key.ToString())).OrderBy(y => y.ReleaseDate).ToList()
                })
                .OrderBy(b => b.Name)
                .ToList();
        }

        public List<Author> GroupByMultiAuthor(List<Book> books)
        {
            return books
                .RemoveDuplicates()
                .GroupBy(b => b.Author[0])
                .Select(b => new Author
                {
                    Name = b.Key,
                    Count = b.Count(),
                    Pages = b.Sum(x => x.Pages),
                    Minutes = b.Sum(x => x.Minutes),
                    AvgRating = b.Average(x => x.Ratings),
                    Books = books.Where(x => x.Author[0].Equals(b.Key.ToString())).OrderBy(y => y.ReleaseDate).ToList()
                })
                .OrderBy(b => b.Name)
                .ToList()
                .RemoveAuthorsWithLessThanXBooks()
                .ToList();
        }

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

        public List<BookGroupDto> GroupByYear(List<Book> books)
        {
            return books
                .GroupBy(b => ((DateTime) b.DateCompleted).Year)
                .Select(b => new BookGroupDto
                {
                    Name = b.Key.ToString(),
                    TotalTime = b.Sum(x => x.Minutes),
                    TotalPages = b.Sum(x => x.Pages),
                    Books = books.Where(x => ((DateTime)x.DateCompleted).Year.ToString() == b.Key.ToString()).OrderByDescending(y => y.DateCompleted).ToList(),
                    SortOrder = (new DateTime(b.Key, 1, 1) - new DateTime(1990, 1, 1)).Days 
                })
                .ComputeRankPercentile()
                .OrderByDescending(x => x.Name)
                .ToList();
        }

        public List<BookGroupDto> GroupByMonth(List<Book> books)
        {
            return books
                .ReoveBooksWithoutDateCompleted()
                .GroupBy(b => $"{((DateTime)b.DateCompleted).Year.ToString()}-{((DateTime)b.DateCompleted).Month.ToString()}")
                .Select(b => new BookGroupDto
                {
                    Name = b.Key.ToString(),
                    Year = Convert.ToInt32(b.Key.ToString().Split('-').ElementAt(0)),
                    Month = Convert.ToInt32(b.Key.ToString().Split('-').ElementAt(1)),
                    TotalTime = b.Sum(c => c.Minutes),
                    TotalPages = b.Sum(c => c.Pages),
                    Books = books.Where(x => $"{((DateTime)x.DateCompleted).Year.ToString()}-{((DateTime)x.DateCompleted).Month.ToString()}" == b.Key.ToString()).OrderByDescending(y => y.DateCompleted).ToList()
                })
                .ComputeRankPercentile()
                .OrderByDescending(b => b.Year)
                .ThenByDescending(b => b.Month)
                .ToList();
        } 
    }
}
