using System.Collections.Generic;
using MyBookLibrary.Service.Model;

namespace MyBookLibrary.Service.Report
{
    public class BookAggregatedGroup<T>
    {
        public string Field { get; set; }
        public T Value { get; set; }
        public List<Book> Books { get; set; }
    }
}
