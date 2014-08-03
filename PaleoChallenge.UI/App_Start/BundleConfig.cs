using System.Web;
using System.Web.Optimization;

namespace PaleoChallenge.UI
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/angular.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/rx.js",
                        "~/Scripts/rx.all.js",
                        "~/Scripts/rx.angular.js",                        
                        "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/src")
                    .IncludeDirectory("~/App/src/", "*.js", true));  

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
