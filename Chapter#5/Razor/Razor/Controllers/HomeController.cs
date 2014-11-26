using System.Web.Mvc;
using Razor.Models;

namespace Razor.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        readonly Product _myProduct = new Product
        {
            ProductId = 1,
            Name = "Kayak",
            Description = "A boat for one person",
            Category = "Watersports",
            Price = 275M
        };
        public ActionResult Index()
        {
            
            return View(_myProduct);
        }
        public ActionResult NameAndPrice()
        {
            return View(_myProduct);
        }

        public ActionResult DemoExpression()
        {
            ViewBag.ProductCount = 1;
            ViewBag.ExpressShip = true;
            ViewBag.ApplyDiscount = false;
            ViewBag.Supplier = null;
            return View(_myProduct);
        }

        public ActionResult DemoArray()
        {
            var array = new[]
            {
                new Product{Name = "Kayak",Price = 48.9M},
                new Product{Name = "Lifejacket",Price = 19.50M},
                new Product{Name = "Soccer ball",Price = 34.95M}
            };
            return View(array);
        }
    }
}
