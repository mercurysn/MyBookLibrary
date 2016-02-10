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

        public static List<BookAggregatedGroup> GroupByAuthorBookCount(this List<Book> books)
        {
            return books
                .RemoveDuplicates()
                .GroupBy(b => b.Author[0])
                .Select(b => new BookAggregatedGroup
                {
                    Field = b.Key,
                    Value = b.Count(),
                    Books = books.Where(x => x.Author[0] == b.Key.ToString()).OrderBy(y => y.ReleaseDate).ToList()
                })
                .OrderByDescending(b => b.Value)
                .ToList();
        }

        public static List<BookAggregatedGroup> GroupByAuthorMinutes(this List<Book> books)
        {
            return books
                .RemoveDuplicates()
                .GroupBy(b => b.Author[0])
                .Select(b => new BookAggregatedGroup
                {
                    Field = b.Key.ToString(),
                    Value = b.Sum(x => x.Minutes),
                    Books = books.Where(x => x.Author[0] == b.Key.ToString()).OrderBy(y => y.ReleaseDate).ToList()
                })
                .OrderByDescending(b => b.Value)
                .ToList();
        }

        public static List<BookAggregatedGroup> GroupBySeries(this List<Book> books)
        {
            return books
                .RemoveDuplicates()
                .GroupBy(b => b.Series)
                .Select(b => new BookAggregatedGroup
                {
                    Field = b.Key,
                    Value = b.Count(),
                    Books = books.Where(x => x.Series.Equals(b.Key.ToString())).OrderBy(y => y.SeriesOrder).ToList()
                })
                .OrderByDescending(b => b.Value)
                .ToList();
        }

        public static List<BookAggregatedGroup> GroupByDecade(this List<Book> books)
        {
            return books
                .RemoveDuplicates()
                .ReoveBooksWithoutReleaseDate()
                .GroupBy(b =>  ((DateTime)b.ReleaseDate).Year.ToDecade())
                .Select(b => new BookAggregatedGroup
                {
                    Field = b.Key.ToString(),
                    Value = b.Count(),
                    Books = books.Where(x => ((DateTime)x.ReleaseDate).Year.ToDecade().ToString() == b.Key.ToString()).OrderBy(y => y.ReleaseDate).ToList()
                })
                .OrderBy(b => b.Field)
                .ToList();
        }

        public static List<BookAggregatedGroup> YearStats(this List<Book> books)
        {
            return books
                .GroupBy(b => ((DateTime)b.DateCompleted).Year)
                .Select(b => new BookAggregatedGroup
                {
                    Field = b.Key.ToString(),
                    Value = b.Count(),
                    Books = books.Where(x => ((DateTime)x.DateCompleted).Year.ToString() == b.Key.ToString()).OrderBy(y => y.DateCompleted).ToList()
                })
                .OrderBy(b => b.Field)
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
