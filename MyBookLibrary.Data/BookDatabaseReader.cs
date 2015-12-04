using System.IO;

namespace MyBookLibrary.Data
{
    public class BookDatabaseReader : IBookDatabaseReader
    {
        public static string ReadFile()
        {
            return File.ReadAllText(@"C:\source\MyBookLibrary\MyBookLibrary.Data\Database\Book.json");
        }
    }
}
