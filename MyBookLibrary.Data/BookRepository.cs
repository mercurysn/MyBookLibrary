using System.Collections.Generic;
using MyBookLibrary.Data.Dtos;
using MyBookLibrary.Data.Readers;

namespace MyBookLibrary.Data
{
    public class BookRepository
    {
        public List<BookDto> GetAllBookDtos()
        {
            CsvFileReader reader = new CsvFileReader();

            return reader.GetAllRecords();
        }
        
    }
}
