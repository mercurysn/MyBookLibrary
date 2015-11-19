using System.Collections.Generic;
using System.Linq;
using MyBookLibrary.Service.Model;

namespace MyBookLibrary.Service
{
    public static class StatService
    {
        public static List<Book> SortBooksByMinutes(this List<Book> books)
        {
            return books.OrderByDescending(x => x.Minutes).ToList();
        }
    }
}
