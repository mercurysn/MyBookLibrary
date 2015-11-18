using System.Collections.Generic;
using MyBookLibrary.Data;
using MyBookLibrary.Data.Dtos;
using MyBookLibrary.Service.Model;
using Newtonsoft.Json;

namespace MyBookLibrary.Service
{
    public class JsonFileGenerator
    {
        public void GenerateJsonDataFile()
        {
            var bookDtos = GetBookDtos();

            var books = GetBookModel(bookDtos);

            BookDatabaseWriter.SaveToFile(JsonConvert.SerializeObject(books, Formatting.Indented));
        }

        private static List<Book> GetBookModel(List<BookDto> bookDtos)
        {
            List<Book> books = AutoMapper.Mapper.Map<List<Book>>(bookDtos);



            return books;
        }

        private static List<BookDto> GetBookDtos()
        {
            BookRepository repository = new BookRepository();

            var bookDtos = repository.GetAllBookDtos();
            return bookDtos;
        }
    }

}
