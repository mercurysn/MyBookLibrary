using System.Collections.Generic;
using MyBookLibrary.Service.Model;

namespace MyBookLibrary.Service.Report
{
    public class BookAggregatedGroup
    {
        public string Field { get; set; }
        public int Value { get; set; }
        public List<Book> Books { get; set; }
    }
}
