using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using MyBookLibrary.Service;
using MyBookLibrary.Service.ExtensionMethods;
using MyBookLibrary.Web.Models.ViewModels;

namespace MyBookLibrary.Web.Controllers
{
    public class BookListController : Controller
    {
        private readonly IBookReadService _bookReadService;

        public BookListController(IBookReadService bookReadService)
        {
            _bookReadService = bookReadService;
        }

        public ActionResult Index()
        {
            var books = _bookReadService.GetAll().RemoveDuplicates();

            return View(new BookListIndexViewModel
            {
                Books = books.OrderByDescending(b => b.Id).ToList(),
                BookDecade = books
                    .DistinctBy(b => ((DateTime)b.ReleaseDate).Year.ToDecade()).Select(b => ((DateTime)b.ReleaseDate).Year.ToDecade()).ToList().OrderByDescending(x => x).ToList()
            });

        }

        public ActionResult BookListSummary()
        {
            var books = _bookReadService.GetAll().RemoveDuplicates().OrderByDescending(b => b.DateCompleted).ToList();

            return View("BookListSummary", new BookListIndexViewModel
            {
                Books = books,
                BookDecade = books
                    .DistinctBy(b => ((DateTime)b.ReleaseDate).Year.ToDecade()).Select(b => ((DateTime)b.ReleaseDate).Year.ToDecade()).ToList().OrderByDescending(x => x).ToList()
            });
        }
    }
}