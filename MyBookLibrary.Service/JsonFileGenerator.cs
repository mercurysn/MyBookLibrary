using MyBookLibrary.Data;
using Newtonsoft.Json;

namespace MyBookLibrary.Service
{
    public class JsonFileGenerator
    {
        public void GenerateJsonDataFile()
        {
            BookRepository repository = new BookRepository();

            var books = repository.GetAllBookDtos();

            BookDatabaseWriter.SaveToFile(JsonConvert.SerializeObject(books, Formatting.Indented));
        }
    }

}
