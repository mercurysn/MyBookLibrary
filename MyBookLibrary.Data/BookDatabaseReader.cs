using System.IO;

namespace MyBookLibrary.Data
{
    public class BookDatabaseReader : IBookDatabaseReader
    {
        public static string ReadImageFreeFile()
        {
            return File.ReadAllText(@"C:\source\MyBookLibrary\MyBookLibrary.Data\Database\BookImageFree.json");
        }

        public static string ReadFullFile()
        {
            return File.ReadAllText(@"C:\source\MyBookLibrary\MyBookLibrary.Data\Database\Book.json");
        }

        public static string ReadWithImageFile()
        {
            return File.ReadAllText(@"C:\source\MyBookLibrary\MyBookLibrary.Data\Database\BookWithImage.json");
        }
    }
}
