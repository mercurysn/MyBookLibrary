using MyBookLibrary.Common;

namespace MyBookLibrary.Data
{
    public class DatabaseReaderFactory
    {
        public static IBookDatabaseReader GetReader()
        {
            if (CurrentEnvironment.IsLocal())
                return new LocalDatabaseReader();

            return new BookDatabaseDropboxReader();
        }
    }
}
