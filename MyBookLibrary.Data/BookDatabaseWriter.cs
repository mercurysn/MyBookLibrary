using System.IO;

namespace MyBookLibrary.Data
{
    public class BookDatabaseWriter
    {
        public static void SaveToFullFile(string json)
        {
            File.WriteAllText(@"C:\source\MyBookLibrary\MyBookLibrary.Data\Database\Book.json", json);
        }

        public static void SaveToWithDescriptionFile(string json)
        {
            File.WriteAllText(@"C:\source\MyBookLibrary\MyBookLibrary.Data\Database\BookWithDescription.json", json);
        }


        public static void SaveToImageFreeFile(string json)
        {
            File.WriteAllText(@"C:\source\MyBookLibrary\MyBookLibrary.Data\Database\BookImageFree.json", json);
        }
    }
}
