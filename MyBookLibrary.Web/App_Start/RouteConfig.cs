using System.Web.Mvc;
using System.Web.Routing;

namespace MyBookLibrary.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "BookDetails",
                url: "Book/{id}",
                defaults: new { controller = "BookDetails", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "BookListSummary",
                url: "BookList/BookListSummary",
                defaults: new { controller = "BookList", action = "BookListSummary" }
            );

            routes.MapRoute(
                name: "BookListCoverSize",
                url: "BookList/{size}",
                defaults: new { controller = "BookList", action = "Index", size = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
