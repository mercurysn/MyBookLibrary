using System.Collections.Generic;

namespace MyBookLibrary.RestClients.Model
{
    public class GoogleBook
    {
        public string Kind { get; set; }
        public VolumeInfo VolumeInfo { get; set; }
    }

    public class VolumeInfo
    {
        public string Title { get; set; }
        public string Publisher { get; set; }
        public string Description { get; set; }
        public List<IndustryIdentifiers> IndustryIdentifiers { get; set; }
        public string Isbn10 { get; set; }
        public string Isbn13 { get; set; }

    }

    public class IndustryIdentifiers
    {
        public string Type { get; set; }
        public string Identifier { get; set; }
    }
}
