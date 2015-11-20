using System;
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

        public static List<BookAggregatedGroup> GroupByAuthor(this List<Book> books)
        {
            return books
                .RemoveDuplicates()
                .GroupBy(b => b.Author[0])
                .Select(b => new BookAggregatedGroup
                {
                    Field = b.Key,
                    Value = b.Count()
                }).OrderByDescending(b => b.Value).ToList();
        } 
    }

    public class BookComparer : IEqualityComparer<Book>
    {
        public bool Equals(Book x, Book y)
        {
            return StringComparer.InvariantCultureIgnoreCase.Equals(x.Name, y.Name);
        }

        public int GetHashCode(Book book)
        {
            return StringComparer.InvariantCultureIgnoreCase.GetHashCode(book.Name);
        }
    }
}
