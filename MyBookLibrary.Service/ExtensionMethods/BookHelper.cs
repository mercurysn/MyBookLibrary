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
    }
}
