using System.Linq;
using System.Web.Mvc;
using MyBookLibrary.Service;
using MyBookLibrary.Service.ExtensionMethods;
using MyBookLibrary.Web.Models.ViewModels;

namespace MyBookLibrary.Web.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IBookReadService _bookReadService;
        private readonly IBookAggrService _bookAggrService;

        public AuthorController(IBookReadService bookReadService, IBookAggrService bookAggrService)
        {
            _bookReadService = bookReadService;
            _bookAggrService = bookAggrService;
        }

        public ActionResult Index(string size)
        {
            var books = _bookReadService.GetAll()
                .RemoveDuplicates()
                .DenormaliseAuthors()
                .RemoveBooksWithoutSeries();

            return View(new AuthorViewModel
            {
                Authors = _bookAggrService.GroupByAuthor(books)
            });
        }

        public ActionResult AuthorRating()
        {
            var books = _bookReadService.GetAll()
                .RemoveDuplicates()
                .DenormaliseAuthors()
                .RemoveBooksWithoutSeries();

            return View(new AuthorViewModel
            {
                Authors = _bookAggrService.GroupByMultiAuthor(books).OrderByDescending(b => b.AvgRating).ToList()
            });
        }
    }
}