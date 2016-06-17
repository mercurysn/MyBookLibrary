using System.IO;

namespace MyBookLibrary.Data
{
    public class LocalDatabaseReader : IBookDatabaseReader
    {
        public string ReadImageFreeFile()
        {
            return File.ReadAllText(@"C:\source\MyBookLibrary\MyBookLibrary.Data\Database\BookImageFree.json");
        }

        public string ReadFullFile()
        {
            return File.ReadAllText(@"C:\source\MyBookLibrary\MyBookLibrary.Data\Database\Book.json");
        }

        public string ReadWithDescriptionFile()
        {
            return File.ReadAllText(@"C:\source\MyBookLibrary\MyBookLibrary.Data\Database\BookWithDescription.json");
        }
    }
}
