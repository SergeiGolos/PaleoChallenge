using BissellPlace.PaleoChallenge.Framework.Http.Bundler;
using System.Web;
using System.Web.Optimization;

namespace BissellPlace.PaleoChallenge
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/angular.js",
                        "~/Scripts/lodash.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/moment.js",
                        "~/Scripts/rx.js",
                        "~/Scripts/rx.async.js",
                        "~/Scripts/rx.lite.js",
                        "~/Scripts/rx.angular.js",
                        "~/Scripts/respond.js",
                        "~/Scripts/d3.js",
                        "~/Scripts/nv.d3.js",
                        "~/Scripts/angularjs-nvd3-directives.js"));

            bundles.Add(new ScriptBundle("~/bundles/src")
                    .IncludeDirectory("~/App/src/", "*.js", false)
                    .IncludeDirectory("~/App/src/controllers/", "*.js", true)
                    .IncludeDirectory("~/App/src/directives/", "*.js", true)
                    .IncludeDirectory("~/App/src/services/", "*.js", true));

            bundles.Add(new Bundle("~/Content/views", new AngularTemplateTransform())
                   .IncludeDirectory("~/App/views/", "*.html", true));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/nv.d3.css",
                      "~/Content/site.css"));

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = false;
        }
    }
}
