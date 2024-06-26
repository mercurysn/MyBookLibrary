﻿using System;
using System.Collections.Generic;
using System.Linq;
using MyBookLibrary.Service.ExtensionMethods;
using MyBookLibrary.Service.Model;
using MyBookLibrary.Service.Report;

namespace MyBookLibrary.Service
{
    public static class StatService
    {
        public static List<Book> SortBooksByMinutes(this List<Book> books)
        {
            return books.RemoveDuplicates().OrderByDescending(x => x.Minutes).ToList();
        }

        public static List<BookAggregatedGroup<int>> GroupByAuthorBookCount(this List<Book> books)
        {
            return books
                .RemoveDuplicates()
                .GroupBy(b => b.Author[0])
                .Select(b => new BookAggregatedGroup<int>
                {
                    Field = b.Key,
                    Value = b.Count(),
                    Books = books.Where(x => x.Author[0] == b.Key.ToString()).OrderBy(y => y.ReleaseDate).ToList()
                })
                .OrderByDescending(b => b.Value)
                .ToList();
        }

        public static List<BookAggregatedGroup<int>> GroupByAuthorMinutes(this List<Book> books)
        {
            return books
                .RemoveDuplicates()
                .GroupBy(b => b.Author[0])
                .Select(b => new BookAggregatedGroup<int>
                {
                    Field = b.Key.ToString(),
                    Value = b.Sum(x => x.Minutes),
                    Books = books.Where(x => x.Author[0] == b.Key.ToString()).OrderBy(y => y.ReleaseDate).ToList()
                })
                .OrderByDescending(b => b.Value)
                .ToList();
        }

        public static List<BookAggregatedGroup<string>> GroupByAuthorRatings(this List<Book> books)
        {
            return books
                .RemoveDuplicates()
                .GroupBy(b => b.Author[0])
                .Select(b => new BookAggregatedGroup<string>
                {
                    Field = b.Key.ToString(),
                    Value = (Convert.ToDouble(b.Average(x => x.Ratings))).ToString("#.00"),
                    Books = books.Where(x => x.Author[0] == b.Key.ToString()).OrderBy(y => y.ReleaseDate).ToList()
                })
                .OrderByDescending(b => b.Value)
                .ToList();
        }

        public static List<BookAggregatedGroup<string>> GroupBySeriesRatings(this List<Book> books)
        {
            return books
                .RemoveDuplicates()
                .RemoveBooksWithoutSeries()
                .GroupBy(b => b.Series)
                .Select(b => new BookAggregatedGroup<string>
                {
                    Field = b.Key,  
                    Value = (Convert.ToDouble(b.Average(x => x.Ratings))).ToString("#.00"),
                    Books = books.Where(x => x.Series != null && x.Series.Equals(b.Key.ToString())).OrderBy(y => y.SeriesOrder).ToList()
                })
                .OrderByDescending(b => b.Value)
                .ToList();
        }

        public static List<BookAggregatedGroup<string>> RemoveAuthorsWithLessThanXBooks(this List<BookAggregatedGroup<string>> booksGroups, int minBookCount = 2)
        {
            return booksGroups.Where(bg => bg.Books.Count >= minBookCount).ToList();
        }

        public static List<BookAggregatedGroup<int>> GroupBySeries(this List<Book> books)
        {
            return books
                .RemoveDuplicates()
                .GroupBy(b => b.Series)
                .Select(b => new BookAggregatedGroup<int>
                {
                    Field = b.Key,
                    Value = b.Count(),
                    Books = books.Where(x => x.Series.Equals(b.Key.ToString())).OrderBy(y => y.SeriesOrder).ToList()
                })
                .OrderByDescending(b => b.Value)
                .ToList();
        }

        public static List<BookAggregatedGroup<int>> GroupByDecade(this List<Book> books)
        {
            return books
                .RemoveDuplicates()
                .ReoveBooksWithoutReleaseDate()
                .GroupBy(b =>  ((DateTime)b.ReleaseDate).Year.ToDecade())
                .Select(b => new BookAggregatedGroup<int>
                {
                    Field = b.Key.ToString(),
                    Value = b.Count(),
                    Books = books.Where(x => ((DateTime)x.ReleaseDate).Year.ToDecade().ToString() == b.Key.ToString()).OrderBy(y => y.ReleaseDate).ToList()
                })
                .OrderBy(b => b.Field)
                .ToList();
        }

        public static List<BookAggregatedGroup<int>> YearStats(this List<Book> books)
        {
            return books
                .GroupBy(b => ((DateTime)b.DateCompleted).Year)
                .Select(b => new BookAggregatedGroup<int>
                {
                    Field = b.Key.ToString(),
                    Value = b.Count(),
                    Books = books.Where(x => ((DateTime)x.DateCompleted).Year.ToString() == b.Key.ToString()).OrderBy(y => y.DateCompleted).ToList()
                })
                .OrderBy(b => b.Field)
                .ToList();
        }

        public static List<MonthAggregatedGroup<int>> GroupByYearMonthAscending(this List<Book> books)
        {
            return books
                .GroupByYearMonth()
                .OrderBy(b => b.Year)
                .ThenBy(b => b.Month)
                .ToList();
        }

        public static List<Dictionary<string, string>> DailyCompareStats(this List<Book> books)
        {
            var resultDict = new List<Dictionary<string, string>>();

            var minYears = books
                .Where(b => ((DateTime)b.DateCompleted).Year > 1980)
                .GroupBy(b => ((DateTime) b.DateCompleted).Year)
                .Min(b => b.Key);

            var maxYears = books
                .GroupBy(b => ((DateTime)b.DateCompleted).Year)
                .Max(b => b.Key);

            var dateEnd = new DateTime(DateTime.Now.Year, 12, 31);

            for (var dateStart = new DateTime(DateTime.Now.Year, 1, 1); dateStart != dateEnd; dateStart = dateStart.AddDays(1))
            {
                var dayStat = new Dictionary<string, string> {{"Name", dateStart.ToString("dd-MM")}};
                for (int i = minYears; i <= maxYears; i++)
                {
                    if (dateStart.Month == 2 && dateStart.Day == 29)
                    {
                        dayStat.Add(i.ToString(), "0");
                    }
                    else
                    {
                        var bookCount = books.Count(b => ((DateTime)b.DateCompleted).Year == i && ((DateTime)b.DateCompleted) <= new DateTime(i, dateStart.Month, dateStart.Day));
                        dayStat.Add(i.ToString(), bookCount.ToString());
                    }
                }
                
                resultDict.Add(dayStat);
            }

            return resultDict;
        }

        public static List<MonthAggregatedGroup<int>> GroupByYearMonth(this List<Book> books)
        {
            return books
                .ReoveBooksWithoutDateCompleted()
                .GroupBy(b => $"{((DateTime) b.DateCompleted).Year.ToString()}-{((DateTime)b.DateCompleted).Month.ToString()}")
                .Select(b => new MonthAggregatedGroup<int>
                {
                    Display = b.Key.ToString(),
                    YearMonth = b.Key.ToString(),
                    Year = Convert.ToInt32(b.Key.ToString().Split('-').ElementAt(0)),
                    Month = Convert.ToInt32(b.Key.ToString().Split('-').ElementAt(1)),
                    NumberOfBooks = b.Count(),
                    Minutes = b.Sum(c => c.Minutes),
                    MinutesDisplay = b.Sum(c => c.Minutes).ConvertMinuteToHoursMinutes(),
                    Pages = b.Sum(c => c.Pages),
                    PagesDisplay = b.Sum(c => c.Pages).ToString("#,##0"),
                    Books = books.Where(x => $"{((DateTime)x.DateCompleted).Year.ToString()}-{((DateTime)x.DateCompleted).Month.ToString()}" == b.Key.ToString()).OrderBy(y => y.DateCompleted).ToList()
                })
                .OrderByDescending(b => b.Year)
                .ThenByDescending(b => b.Month)
                .ToList();
        } 
    }

    public class BookComparer : IEqualityComparer<Book>
    {
        public bool Equals(Book x, Book y)
        {
            return StringComparer.InvariantCultureIgnoreCase.Equals(x.Name, y.Name) && StringComparer.InvariantCultureIgnoreCase.Equals(x.Author[0], y.Author[0]);
        }

        public int GetHashCode(Book book)
        {
            return StringComparer.InvariantCultureIgnoreCase.GetHashCode(string.Concat(book.Name, string.Join("", book.Author)));
        }
    }
}
