using CsvHelper.Configuration;
using MyBookLibrary.Data.Dtos;

namespace MyBookLibrary.Data.Mappers
{
    public sealed class ShelfariFileMapper : CsvClassMap<BookDto>
    {
        public ShelfariFileMapper()
        {
            Map(m => m.Book);
            Map(m => m.Author);
            Map(m => m.Time);
            Map(m => m.DateStarted);
            Map(m => m.DateEnded);
            Map(m => m.Year);
            Map(m => m.GoogleBookID);
            Map(m => m.Series);
            Map(m => m.Pages);
            Map(m => m.URL);
        }
    }
}
