using System.Web.Mvc;
using MyBookLibrary.Service;
using MyBookLibrary.Web.Models.ViewModels;

namespace MyBookLibrary.Web.Controllers
{
    public class StatsController : Controller
    {
        private readonly IBookReadService _bookReadService;
        private readonly IBookAggrService _bookAggrService;

        public StatsController(IBookReadService bookReadService, IBookAggrService bookAggrService)
        {
            _bookReadService = bookReadService;
            _bookAggrService = bookAggrService;
        }

        public ActionResult Index()
        {
            var books = _bookReadService.GetAll();

            return View(new BookGroupByTimeBViewModel
            {
                BookGroups = _bookAggrService.GroupByYear(books)
            });
        }

        public ActionResult Month()
        {
            var books = _bookReadService.GetAll();

            return View("Index", new BookGroupByTimeBViewModel
            {
                BookGroups = _bookAggrService.GroupByMonth(books)
            });
        }

        public ActionResult Longest()
        {
            return View("BookStats", _bookReadService.GetLongestBooks(20));
        }

        public ActionResult Shortest()
        {
            return View("BookStats", _bookReadService.GetShortestBooks(20));
        }
    }
}