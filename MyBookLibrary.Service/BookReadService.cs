using System.Collections.Generic;
using MyBookLibrary.Data;
using MyBookLibrary.Service.Model;
using Newtonsoft.Json;

namespace MyBookLibrary.Service
{
    public class BookReadService : IBookReadService
    {
        public List<Book> GetAll()
        {
            return JsonConvert.DeserializeObject<List<Book>>(BookDatabaseReader.ReadFile());
        }
    }
}
