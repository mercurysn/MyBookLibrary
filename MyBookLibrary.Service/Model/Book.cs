using System;

namespace MyBookLibrary.Service.Model
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int Minutes { get; set; }
        public DateTime? DateStarted { get; set; }
        public DateTime? DateCompleted { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int Pages { get; set; }
        public string CoverUrl { get; set; }
        public string CoverHash { get; set; }
    }
}
