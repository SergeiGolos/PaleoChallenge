using System.Web.Mvc;
using BissellPlace.PaleoChallenge.Framework;

namespace BissellPlace.PaleoChallenge.Controllers
{    
    public class HomeController : Controller
    {
        private readonly ISecurityUser _user;

        public HomeController(ISecurityUser user)
        {
            _user = user;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
