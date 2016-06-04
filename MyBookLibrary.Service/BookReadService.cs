using System.Collections.Generic;
using System.Linq;
using MyBookLibrary.Data;
using MyBookLibrary.Service.Model;
using Newtonsoft.Json;

namespace MyBookLibrary.Service
{
    public class BookReadService : IBookReadService
    {
        public Book GetBookFromId(int id)
        {
            var books = GetAll();

            return books.FirstOrDefault(b => b.Id == id);
        }

        public List<Book> GetAll()
        {
            return JsonConvert.DeserializeObject<List<Book>>(BookDatabaseDropboxReader.ReadFile());
        }

        public List<Book> ReadAllFromLocalImageFreeFile()
        {
            return JsonConvert.DeserializeObject<List<Book>>(BookDatabaseReader.ReadImageFreeFile());
        }

        public List<Book> ReadAllFromLocalFullFile()
        {
            return JsonConvert.DeserializeObject<List<Book>>(BookDatabaseReader.ReadFullFile());
        }

        public List<Book> ReadAllFromLocalWithImageFile()
        {
            return JsonConvert.DeserializeObject<List<Book>>(BookDatabaseReader.ReadWithImageFile());
        }

        public List<Book> ReadAllFromLocalWithDescriptionFile()
        {
            return JsonConvert.DeserializeObject<List<Book>>(BookDatabaseReader.ReadWithDescriptionFile());
        }
    }
}
