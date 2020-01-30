using System.Web;
using System.Web.Optimization;

namespace Nomad
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"
                      ));


            var bundle2 = new StyleBundle("~/bundles/MainScriptNotMinify").Include(
          "~/Scripts/jquery.min.js",
          "~/Scripts/plugins/bootstrap.bundle.min.js",
          "~/Scripts/plugins/isotope.pkgd.min.js",
          "~/Scripts/plugins/jquery.countdown.min.js",
          "~/Scripts/plugins/jquery.easing.min.js",
          "~/Scripts/plugins/jquery.magnific-popup.min.js",
          "~/Scripts/plugins/onepage.min.js",
          "~/Scripts/plugins/owl.carousel.min.js",
          "~/Scripts/plugins/instafeed.min.js",
          "~/Scripts/plugins/imagesloaded.pkgd.min.js",
          "~/Scripts/plugins/twitterFetcher_min.js",
          "~/Scripts/plugins/aos.js"

          );


            bundle2.Transforms.Clear();

            bundles.Add(bundle2);

            bundles.Add(new ScriptBundle("~/bundles/MainScript").Include(
                      "~/Scripts/plugins/jquery.countTo.js",
                      "~/Scripts/main.js",
                      "~/Scripts//Newsletter/Newsletter.js",
                      "~/Scripts/jquery-eu-cookie-law-popup.js"
                      ));

            var bundle = new StyleBundle("~/bundles/bootstrapNotMinify").Include(
                      "~/css/bootstrap.min.css",
                      "~/css/fontawesome-all.min.css",
                      "~/css/plugins/owl.carousel.min.css",
                      "~/css/plugins/spacing-and-height.css"
                      );
            bundle.Transforms.Clear();
            bundles.Add(new StyleBundle("~/bundles/Styles").Include(
                      //"~/css/fontawesome-all.min.css",
                      //"~/css/bootstrap.min.css",
                      //"~/css/plugins/owl.carousel.min.css",
                      //"~/css/plugins/magnific-popup.css",
                      //"~/css/plugins/aos.css",
                      //"~/css/plugins/spacing-and-height.css",
                      "~/css/site.css",
                      "~/css/jquery-eu-cookie-law-popup.css"

                      ));
            bundles.Add(bundle);
            BundleTable.EnableOptimizations = false;
        }
    }
}
