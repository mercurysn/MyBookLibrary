using System.Web.Mvc;
using MyBookLibrary.Service;

namespace MyBookLibrary.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookReadService _bookReadService;

        public HomeController(IBookReadService bookReadService)
        {
            _bookReadService = bookReadService;
        }

        public ActionResult Index()
        {
            var books = _bookReadService.GetAll();

            return View(books);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}