using System.Collections.Generic;

namespace MyBookLibrary.Service.Model
{
    public class Series
    {
        public string Name { get; set; }
        public string[] Authors { get; set; }
        public int Count { get; set; }
        public List<Book> Books { get; set; }
        public int Minutes { get; set; }
        public int Pages { get; set; }
        public double? AvgRating { get; set; }
    }
}
