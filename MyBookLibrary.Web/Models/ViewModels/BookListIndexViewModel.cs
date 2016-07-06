using System.Collections.Generic;
using MyBookLibrary.Service.Model;

namespace MyBookLibrary.Web.Models.ViewModels
{
    public class BookListIndexViewModel
    {
        public List<Book> Books { get; set; }
        public List<int> BookDecade { get; set; }
        public string Size { get; set; }
    }
}
