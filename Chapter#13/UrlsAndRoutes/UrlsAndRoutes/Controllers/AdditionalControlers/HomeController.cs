using System.Web.Mvc;

namespace UrlsAndRoutes.Controllers.AdditionalControlers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Controller = "AdditionalControlers.HomeController";
            ViewBag.Action = "Index";
            return View("ActionName");
        }
    }
}
