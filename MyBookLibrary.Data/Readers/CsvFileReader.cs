using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
using MyBookLibrary.Data.Dtos;
using MyBookLibrary.Data.Mappers;

namespace MyBookLibrary.Data.Readers
{
    public class CsvFileReader
    {
        public CsvReader Reader { get; set; }

        public CsvFileReader()
        {
            TextReader textReader = File.OpenText(@"C:\Source\MyBookLibrary\MyBookLibrary.Data\Source\2016-02-09 Shelfari.csv");
            Reader = new CsvReader(textReader);
            ConfigureCsvReader();
        }

        private void ConfigureCsvReader()
        {
            Reader.Configuration.RegisterClassMap<ShelfariFileMapper>();
            Reader.Configuration.IgnoreHeaderWhiteSpace = true;
        }

        public List<BookDto> GetAllRecords()
        {
            return Reader.GetRecords<BookDto>().ToList();
        }
    }
}
