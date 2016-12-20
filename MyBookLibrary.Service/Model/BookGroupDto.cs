using System.Collections.Generic;

namespace MyBookLibrary.Service.Model
{
    public class BookGroupDto
    {
        public string Name { get; set; }
        public int BookCount { get; set; }
        public int TotalTime { get; set; }
        public int TotalPages { get; set; }
        public int AverageTime { get; set; }
        public int Rank { get; set; }
        public int Percentile { get; set; }
        public int SortOrder { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public List<Book> Books { get; set; }
    }
}
