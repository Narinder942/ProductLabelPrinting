using System.Web;
using System.Web.Optimization;

namespace ProductLabelPrinting.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.unobtrusive-ajax.min.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new Bundle("~/bundles/CustomJS").Include(
               "~/Content/Theme/js/main.js",
               "~/Content/Theme/vendor/apexcharts/apexcharts.min.js",
               "~/Content/Theme/vendor/bootstrap/js/bootstrap.bundle.min.js",
               "~/Content/Theme/vendor/datepicker/bootstrap-datepicker.min.js"


               ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/Theme/vendor/bootstrap/css/bootstrap.min.css",
                      "~/Content/Theme/vendor/bootstrap-icons/bootstrap-icons.css",
                      "~/Content/Theme/vendor/boxicons/css/boxicons.min.css",
                      "~/Content/Theme/css/style.css",
                      "~/Content/Theme/vendor/datepicker/bootstrap-datepicker.min.css"
                      ));

            BundleTable.EnableOptimizations = false;


        }
    }
}
