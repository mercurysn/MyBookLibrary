namespace MyBookLibrary.Data
{
    public interface IBookDatabaseReader
    {
        string ReadImageFreeFile();
        string ReadFullFile();
        string ReadWithDescriptionFile();
        string ReadFile();
    }
}