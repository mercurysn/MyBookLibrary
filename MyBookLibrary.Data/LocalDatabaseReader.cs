using System.IO;
using MyBookLibrary.Common;

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

        public string ReadFile()
        {
            if (CurrentEnvironment.IsLocal())
                return ReadFullFile();

            return ReadWithDescriptionFile();
        }
    }
}
