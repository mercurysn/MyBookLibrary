using System.Collections.Generic;
using MyBookLibrary.Data;
using MyBookLibrary.Service.Model;
using Newtonsoft.Json;

namespace MyBookLibrary.Service
{
    public class JsonFileGenerator
    {
        public void GenerateJsonDataFile()
        {
            BookRepository repository = new BookRepository();

            var bookDtos = repository.GetAllBookDtos();

            List<Book> books = AutoMapper.Mapper.Map<List<Book>>(bookDtos);

            BookDatabaseWriter.SaveToFile(JsonConvert.SerializeObject(books, Formatting.Indented));
        }
    }

}
