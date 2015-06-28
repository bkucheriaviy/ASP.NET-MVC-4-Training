using System.Web.Mvc;
using HelperMethods.Models;

namespace HelperMethods.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult InnerHelperMethod()
        {
            ViewBag.Fruits = new[] {"Apple", "Mango", "Orange"};
            ViewBag.Cities = new[] {"New York", "London", "Paris"};
            return View();
        }
        public ActionResult ExternalHelperMethod()
        {
            ViewBag.Fruits = new[] { "Apple", "Mango", "Orange" };
            ViewBag.Cities = new[] { "New York", "London", "Paris" };
            return View();
        }

        public ActionResult InputElementEncoding()
        {
            return View((object)"This is an HTML element: <input/>");
        }

        public ActionResult FormHelperMethod()
        {
            return View(new Person());
        }

        [HttpPost]
        public ActionResult FormHelperMethod(Person person)
        {
            return View(person);
        }
    }
}
