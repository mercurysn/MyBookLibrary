using MyBookLibrary.Common;

namespace MyBookLibrary.Data
{
    public class DatabaseReaderFactory
    {
        public static IBookDatabaseReader GetReader()
        {
            if (CurrentEnvironment.IsLocal())
                return new BookDatabaseReader();

            return new BookDatabaseDropboxReader();
        }
    }
}
