using System.Collections.Generic;
using MyBookLibrary.Service.Model;

namespace MyBookLibrary.Service.Report
{
    public class MonthAggregatedGroup<T>
    {
        public string Display { get; set; }
        public int Month { get; set; }
        public string MonthDisplay { get; set; }
        public int Year { get; set; }
        public string YearMonth { get; set; }
        public T NumberOfBooks { get; set; }
        public int Minutes { get; set; }
        public int Pages { get; set; }
        public List<Book> Books { get; set; }
    }
}
