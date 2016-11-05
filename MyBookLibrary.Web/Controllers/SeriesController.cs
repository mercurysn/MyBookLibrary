using System.Web.Mvc;
using MyBookLibrary.Service;
using MyBookLibrary.Service.ExtensionMethods;
using MyBookLibrary.Web.Models.ViewModels;

namespace MyBookLibrary.Web.Controllers
{
    public class SeriesController : Controller
    {
        private readonly IBookReadService _bookReadService;
        private readonly IBookAggrService _bookAggrService;

        public SeriesController(IBookReadService bookReadService, IBookAggrService bookAggrService)
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

            return View(new SeriesViewModel
            {
                Series = _bookAggrService.GroupBySeries(books)
            });
        }
    }
}