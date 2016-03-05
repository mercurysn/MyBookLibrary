using System;
using System.Collections.Generic;
using System.Linq;
using MyBookLibrary.Service.Model;

namespace MyBookLibrary.Service.ExtensionMethods
{
    public static class BookHelper
    {
        public static List<Book> RemoveDuplicates(this List<Book> books)
        {
            return books.Distinct(new BookComparer()).ToList();
        }

        public static List<Book> RemoveBooksWithoutSeries(this List<Book> books)
        {
            return books.Where(b => !string.IsNullOrWhiteSpace(b.Series)).ToList();
        }

        public static List<Book> ReoveBooksWithoutReleaseDate(this List<Book> books)
        {
            return books.Where(b => (b.ReleaseDate != null)).ToList();
        }

        public static List<Book> ReoveBooksWithoutDateCompleted(this List<Book> books)
        {
            return books.Where(b => (b.DateCompleted != null)).ToList();
        }

        public static List<Book> DenormaliseAuthors(this List<Book> books)
        {
            List<Book> booksWithMultipleAuthors = books.Where(x => x.Author.Count() > 1).Select(b => new Book
            {
                Author = b.Author,
                Name = b.Name,
                Minutes = b.Minutes
            }).ToList();

            foreach (var booksWithMultipleAuthor in booksWithMultipleAuthors)
            {
                for (var i = 1; i < booksWithMultipleAuthor.Author.Count(); i++)
                {
                    var newBook = new Book
                    {
                        Author = new[] { booksWithMultipleAuthor.Author[i]},
                        Name = booksWithMultipleAuthor.Name,
                        Categories = booksWithMultipleAuthor.Categories,
                        CoverHash = booksWithMultipleAuthor.CoverHash,
                        CoverUrl = booksWithMultipleAuthor.CoverUrl,
                        CrowdRating = booksWithMultipleAuthor.CrowdRating,
                        DateCompleted = booksWithMultipleAuthor.DateCompleted,
                        DateStarted = booksWithMultipleAuthor.DateStarted,
                        Description = booksWithMultipleAuthor.Description,
                        GoogleBookId = booksWithMultipleAuthor.GoogleBookId,
                        GoogleBookLink = booksWithMultipleAuthor.GoogleBookLink,
                        Id = booksWithMultipleAuthor.Id,
                        Minutes = booksWithMultipleAuthor.Minutes
                    };
                    books.Add(newBook);
                }
            }

            return books;
        }
    }
}
