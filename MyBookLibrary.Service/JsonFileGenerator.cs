using MyBookLibrary.Data;

namespace MyBookLibrary.Service
{
    public class JsonFileGenerator
    {
        public void GenerateJsonDataFile()
        {
            BookRepository repository = new BookRepository();

            var books = repository.GetAllBookDtos();
        }
    }

}
