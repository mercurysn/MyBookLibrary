using System.Web;
using System.Web.Optimization;

namespace MyBookLibrary.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/layout-css").Include(
                "~/Content/bootstrap1.min.css",
                "~/Content/font-awesome.min.css",
                "~/Content/animate.min.css",
                "~/Content/lightbox.css",
                "~/Content/main.css",
                "~/Content/responsive.css"
                ));

            bundles.Add(new StyleBundle("~/bundles/layout-scripts").Include(
                "~/Scripts/jquery.js",
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/lightbox.min.js",
                "~/Scripts/wow.min.js",
                "~/Scripts/main.js"
                ));
        }
    }
}
