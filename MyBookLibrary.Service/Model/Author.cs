using System.Collections.Generic;
using System.Linq;

namespace MyBookLibrary.Service.Model
{
    public class Author
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public List<Book> Books { get; set; }
        public int Minutes { get; set; }
        public int Pages { get; set; }
        public double? AvgRating { get; set; }
    }

    public static class AuthorExtension
    {
        public static List<Author> RemoveAuthorsWithLessThanXBooks(this List<Author> authors, int minBookCount = 2)
        {
            return authors.Where(bg => bg.Books.Count >= minBookCount).ToList();
        }
    }
}
