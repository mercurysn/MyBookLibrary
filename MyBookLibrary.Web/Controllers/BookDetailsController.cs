using System.Web.Mvc;
using MyBookLibrary.Service;

namespace MyBookLibrary.Web.Controllers
{
    public class BookDetailsController : Controller
    {
        private readonly IBookReadService _bookReadService;

        public BookDetailsController(IBookReadService bookReadService)
        {
            _bookReadService = bookReadService;
        }

        // GET: BookDetails
        public ActionResult Index(int id)
        {
            var book =_bookReadService.GetBookFromId(id);

            return View(book);
        }
    }
}