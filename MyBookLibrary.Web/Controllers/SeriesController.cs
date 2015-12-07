using System.Web.Mvc;
using MyBookLibrary.Service;

namespace MyBookLibrary.Web.Controllers
{
    public class SeriesController : Controller
    {
        private readonly IBookReadService _bookReadService;

        public SeriesController(IBookReadService bookReadService)
        {
            _bookReadService = bookReadService;
        }

        public ActionResult Index()
        {
            var books = _bookReadService.GetAll();

            return View(books);
        }
    }
}