using System;
using System.Web.Mvc;

namespace WorkingWithRazor.Controllers
{
    public class HomeController : Controller
    {
        public string[] ListOfFruits { get; set; }

        public HomeController()
        {
            ListOfFruits = new[] {"Orange", "Apple", "Banana"};
        }

        public ActionResult Index()
        {
            return View(this);
        }

        public ActionResult List()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult Time()
        {
            return PartialView(DateTime.Now);
        }
    }
}
