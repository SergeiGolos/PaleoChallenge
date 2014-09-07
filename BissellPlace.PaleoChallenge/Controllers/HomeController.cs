using System.Web.Mvc;
using BissellPlace.PaleoChallenge.Framework;
using BissellPlace.PaleoChallenge.Framework.Providers;
using BissellPlace.PaleoChallenge.Providers;

namespace BissellPlace.PaleoChallenge.Controllers
{    
    public class HomeController : Controller
    {
        /// <summary>
        /// The security user in the curent context.
        /// </summary>
        private readonly ISecurityUser _user;

        private readonly IViewSummaryProvider _viewProvider;

        /// <summary>
        /// Creates an instance of the Home Controller.
        /// </summary>
        /// <param name="user">The user in the current context.</param>
        /// <param name="viewProvider">The view summary provider for the controler to use.</param>
        public HomeController(ISecurityUser user, IViewSummaryProvider viewProvider)
        {
            _user = user;
            _viewProvider = viewProvider;
        }

        /// <summary>
        /// Gets the index page for the application.
        /// </summary>
        /// <returns>The single page application view.</returns>
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View(_viewProvider.GetWeekSummary());
        }
    }
}
