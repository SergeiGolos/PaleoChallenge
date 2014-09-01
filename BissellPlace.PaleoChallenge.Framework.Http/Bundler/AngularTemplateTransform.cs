using System.IO;
using System.Linq;
using System.Web.Optimization;

namespace BissellPlace.PaleoChallenge.Framework.Http.Bundler
{
    /// <summary>
    /// Helper class to allow for filtering of min files form bundles.
    /// </summary>
    public class AngularTemplateTransform : IBundleTransform
    {
        /// <summary>
        /// Process the bundle.
        /// </summary>
        /// <param name="context">The current bundle context.</param>
        /// <param name="response">The response object to write to.</param>
        public void Process(BundleContext context, BundleResponse response)
        {
            string strBundleResponse = string.Empty;

            foreach (BundleFile file in response.Files)
            {
                var matchPath = context.BundleVirtualPath.Split('/').Last();
                var fileString = file.VirtualFile.VirtualPath;
                var filename = fileString.Remove(0, fileString.IndexOf(matchPath)).Replace("\\", "/");

                using (var fileStream = file.VirtualFile.Open())
                {
                    using (var textStream = new StreamReader(fileStream))
                    {
                        strBundleResponse += string.Format("<script id='{0}' type='text/ng-template'>{1}</script>", filename, textStream.ReadToEnd());
                    }
                }
            }

            response.Content = strBundleResponse;
        }
    }
}