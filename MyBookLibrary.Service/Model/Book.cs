using System;
using System.Collections.Generic;

namespace MyBookLibrary.Service.Model
{
    public class Book : IEquatable<Book>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string[] Author { get; set; }
        public int Minutes { get; set; }
        public DateTime? DateStarted { get; set; }
        public DateTime? DateCompleted { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int Pages { get; set; }
        public string CoverUrl { get; set; }
        public string CoverHash { get; set; }
        public string Series { get; set; }
        public double SeriesOrder { get; set; }
        public string Description { get; set; }
        public string Publisher { get; set; }
        public string Isbn10 { get; set; }
        public string Isbn13 { get; set; }
        public string GoogleBookId { get; set; }
        public string GoogleBookLink { get; set; }
        public decimal CrowdRating { get; set; }
        public bool GoogleError { get; set; }
        public bool ImageError { get; set; }
        public List<string> Categories { get; set; }
        public int? Ratings { get; set; }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Book);
        }

        public bool Equals(Book other)
        {
            if (other == null)
                return false;

            return Name == other.Name;
        }
    }
}
