using System.Web.Mvc;
using BissellPlace.PaleoChallenge.Framework;

namespace BissellPlace.PaleoChallenge.Controllers
{    
    public class HomeController : Controller
    {
        /// <summary>
        /// The security user in the curent context.
        /// </summary>
        private readonly ISecurityUser _user;

        /// <summary>
        /// Creates an instance of the Home Controller.
        /// </summary>
        /// <param name="user">The user in the current context.</param>
        public HomeController(ISecurityUser user)
        {
            _user = user;
        }

        /// <summary>
        /// Gets the index page for the application.
        /// </summary>
        /// <returns>The single page application view.</returns>
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
