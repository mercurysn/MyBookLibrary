using System.IO;

namespace MyBookLibrary.Data
{
    public class BookDatabaseWriter
    {
        public static void SaveToFile(string json)
        {
            File.WriteAllText(@"C:\source\MyBookLibrary\MyBookLibrary.Data\Database\Book.json", json);
        }
    }
}
