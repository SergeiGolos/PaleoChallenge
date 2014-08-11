using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PaleoChallenge.Business.DataAccess;

namespace PaleoChallenge.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEntryRepository _repository;

        public HomeController(IEntryRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View(_repository.Query(n=> true));
        }
    }
}
