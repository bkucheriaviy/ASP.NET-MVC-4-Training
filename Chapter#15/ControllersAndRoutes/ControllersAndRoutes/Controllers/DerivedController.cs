using System;
using System.Web.Mvc;
using ControllersAndRoutes.Infrastructure;

namespace ControllersAndRoutes.Controllers
{
    public class DerivedController : Controller
    {
        //
        // GET: /Derived/

        public ActionResult Index()
        {
            ViewBag.Message = "Hello from the DerivedController Index method";
            return View("MyView");
        }

        public ActionResult ShowWeatherForecast()
        {
            var city = RouteData.Values["city"].ToString();
            var forDate = DateTime.Parse(Request.Form["forDate"]);
            return View();
        }

        public ActionResult Search(string query = "all", int page = 1)
        {
            return View();
        }

        public ActionResult ProduceOutput()
        {
            if (Server.MachineName == "BOHDAN-PC")
                return new CustomRedirectResult {Url = "/Basic/Index"};
            Response.Write("Controller: Derived. Action: ProduceOutput");
            return null;
        }

        public ActionResult ProduceRedirect()
        {
            return new RedirectResult("/Basic/Index");
        }

        public ActionResult ProduceRedirectAnalog()
        {
            return Redirect("/Basic/Index");
        }
    }
}
