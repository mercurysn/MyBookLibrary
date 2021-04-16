using System.Collections.Generic;
using System.Linq;
using MyBookLibrary.Data;
using MyBookLibrary.Service.Model;
using Newtonsoft.Json;

namespace MyBookLibrary.Service
{
    public class BookReadService : IBookReadService
    {
        private readonly IBookDatabaseReader _reader;

        public BookReadService(IBookDatabaseReader reader)
        {
            _reader = reader;
        }

        public Book GetBookFromId(int id)
        {
            var books = GetAll();

            return books.FirstOrDefault(b => b.Id == id);
        }

        public List<Book> GetAll()
        {
            return JsonConvert.DeserializeObject<List<Book>>(_reader.ReadFile());
        }

        public List<Book> GetLongestBooks(int size = 50)
        {
            return JsonConvert.DeserializeObject<List<Book>>(_reader.ReadFile())
                .OrderBy(b => b.MinutesRank)
                .Take(size)
                .ToList();
        }

        public List<Book> GetShortestBooks(int size = 50)
        {
            return JsonConvert.DeserializeObject<List<Book>>(_reader.ReadFile())
                .OrderByDescending(b => b.MinutesRank)
                .Take(size)
                .ToList();
        }

        public List<Book> GetFastestBooks(int size = 50)
        {
            return JsonConvert.DeserializeObject<List<Book>>(_reader.ReadWithDescriptionFile())
                .OrderByDescending(b => b.SpeedRank)
                .Take(size)
                .ToList();
        }

        public List<Book> ReadAllFromLocalImageFreeFile()
        {
            return JsonConvert.DeserializeObject<List<Book>>(_reader.ReadImageFreeFile());
        }

        public List<Book> ReadAllFromLocalFullFile()
        {
            return JsonConvert.DeserializeObject<List<Book>>(_reader.ReadFullFile());
        }

        public List<Book> ReadAllFromLocalWithDescriptionFile()
        {
            return JsonConvert.DeserializeObject<List<Book>>(_reader.ReadWithDescriptionFile());
        }
    }
}
