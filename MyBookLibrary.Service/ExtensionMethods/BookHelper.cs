using System;
using System.Collections.Generic;
using System.Linq;
using MyBookLibrary.RestClients;
using MyBookLibrary.Service.Model;

namespace MyBookLibrary.Service.ExtensionMethods
{
    public static class BookHelper
    {
        public static List<Book> RemoveDuplicates(this List<Book> books)
        {
            return books.Distinct(new BookComparer()).ToList();
        }

        public static List<Book> ComputeMinutesRank(this List<Book> books)
        {
            books = books.OrderByDescending(b => b.Minutes).ToList();

            int rank = 1;

            foreach (var book in books)
            {
                book.MinutesRank = rank++;
                book.MinutesRankPercentile = CalculatePercentile(book.MinutesRank, books.Count);
            }

            return books;
        }

        public static List<Book> ComputeDaysTaken(this List<Book> books)
        {
            foreach (var book in books)
            {
                if (book.DateCompleted == null || book.DateStarted == null)
                    continue;

                book.DaysTaken = ((DateTime)book.DateCompleted - (DateTime)book.DateStarted).Days;
            }

            return books;
        }

        public static List<Book> ComputeSpeedRank(this List<Book> books)
        {
            books = books.OrderByDescending(b => b.DaysTaken).ToList();

            int rank = 1;

            foreach (var book in books)
            {
                if (book.DaysTaken == null)
                {
                    book.SpeedRankPercentile = 0;
                    continue;
                }

                book.SpeedRank = rank++;
                book.SpeedRankPercentile = CalculatePercentile(book.MinutesRank, books.Count);
            }

            return books;
        }

        private static int CalculatePercentile(int value, int total)
        {
            return 100 - ((value - 1)*100/total);
        }

        public static List<Book> ComputeReleaseDateRank(this List<Book> books)
        {
            books = books.OrderByDescending(b => b.ReleaseDate).ToList();

            int rank = 1;

            foreach (var book in books.Where(book => book.ReleaseDate != null))
            {
                book.ReleaseDateRank = rank++;
                book.ReleaseDateRankPercentile = CalculatePercentile(book.ReleaseDateRank, books.Count);
            }

            return books;
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
                Minutes = b.Minutes,
                Ratings = b.Ratings
            }).ToList();

            foreach (var booksWithMultipleAuthor in booksWithMultipleAuthors)
            {
                for (var i = 1; i < booksWithMultipleAuthor.Author.Count(); i++)
                {
                    var newBook = new Book
                    {
                        Author = new[] { booksWithMultipleAuthor.Author[i]},
                        Name = booksWithMultipleAuthor.Name,
                        Ratings = booksWithMultipleAuthor.Ratings,
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

        public static List<Book> PersistNewBookToList(this List<Book> destinationBookList, List<Book> sourceBookList)
        {
            if (sourceBookList == null || sourceBookList.Count == 0)
                return destinationBookList;

            if (destinationBookList == null || destinationBookList.Count == 0)
                return sourceBookList;

            foreach (var imageFreeBook in sourceBookList)
            {
                if (destinationBookList.All(b => b.Id != imageFreeBook.Id))
                    destinationBookList.Add(imageFreeBook);

                var destinationBook = destinationBookList.FirstOrDefault(b => b.Name == imageFreeBook.Name);

                if (destinationBook != null && destinationBook.GoogleBookId != imageFreeBook.GoogleBookId && !string.IsNullOrWhiteSpace(imageFreeBook.GoogleBookId))
                    destinationBook.GoogleBookId = imageFreeBook.GoogleBookId;
            }

            return destinationBookList;
        }

        public static List<Book> UpdateCoverUrl(this List<Book> destinationBookList, List<Book> sourceBookList)
        {
            if (sourceBookList == null || sourceBookList.Count == 0)
                return destinationBookList;

            if (destinationBookList == null || destinationBookList.Count == 0)
                return sourceBookList;

            foreach (var imageFreeBook in sourceBookList)
            {
                var destinationBook = destinationBookList.FirstOrDefault(b => b.Id == imageFreeBook.Id);
                if (destinationBook != null && 
                    destinationBook.CoverUrl != imageFreeBook.CoverUrl &&
                    !destinationBook.CoverUrl.Contains("mercury-book-repo.s3.amazonaws.com/img/"))
                {
                    destinationBook.CoverUrl = imageFreeBook.CoverUrl;
                }
            }

            return destinationBookList;
        }

        public static List<Book> PersistBookImagesToS3(this List<Book> books)
        {
            if (books == null || books.Count == 0)
                return books;

            var s3Client = new AmazonS3Client();

            foreach (var book in books)
            {
                try
                {
                    if (!book.CoverUrl.Contains("mercury-book-repo.s3.amazonaws.com/img/"))
                    {
                        var news3Url = s3Client.SendUrlToS3(book.CoverUrl, book.Id.ToString());

                        book.CoverUrl = news3Url;
                    }
                }
                catch (Exception)
                {
                    // ignored
                }
            }   

            return books;
        }
    }
}
