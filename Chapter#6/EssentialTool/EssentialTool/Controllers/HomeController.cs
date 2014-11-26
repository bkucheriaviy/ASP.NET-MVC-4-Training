using System.Web.Mvc;
using EssentialTool.Models;

namespace EssentialTool.Controllers
{
    public class HomeController : Controller
    {
        private readonly Product[] _products =
        {
            new Product {Name = "Kayak", Category = "Watersports", Price = 275M},
            new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.5M},
            new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.5M},
            new Product {Name = "Corner flag", Category = "Soccer", Price = 34.5M}
        };

        private readonly IShoppingCart _shopingCart;

        public HomeController(IShoppingCart shopingCart)
        {
            _shopingCart = shopingCart;
        }

        public ActionResult Index()
        {
            _shopingCart.Products = _products;
            var total = _shopingCart.CalculateProductTotal();
            return View(total);
        }
    }
}
