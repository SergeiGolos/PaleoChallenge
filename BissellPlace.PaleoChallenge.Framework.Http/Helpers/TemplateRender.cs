using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;

namespace BissellPlace.PaleoChallenge.Framework.Http.Helpers
{
    public static class TemplateRenderHelper
    {
        /// <summary>
        /// Returns the content of the requested Bundle with transforms applied.
        /// </summary>
        /// <param name="path">The virtual url of the bundle.</param>
        /// <returns>Bundle context with applied transforms.</returns>        
        public static void TemplateRender(this HtmlHelper helper, string path)
        {        
            var bundle = BundleTable.Bundles.GetBundleFor(path);
            var context = new BundleContext(helper.ViewContext.HttpContext, BundleTable.Bundles, path);
            var result = bundle.ApplyTransforms(context, path, bundle.EnumerateFiles(context));

            helper.Raw(result.Content);
        } 
    }
}