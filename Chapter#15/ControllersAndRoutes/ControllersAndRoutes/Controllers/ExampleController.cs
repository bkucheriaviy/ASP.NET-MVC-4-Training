using System;
using System.Web.Mvc;

namespace ControllersAndRoutes.Controllers
{
    public class ExampleController : Controller
    {
        //
        // GET: /Example/

        public ViewResult Index()
        {
            return View(DateTime.Now);
        }

        public ViewResult Home()
        {
            return View("Homepage");
        }

        public ViewResult IndexAlternateLayout()
        {
            return View("Index", "_AlternateLayoutPage");
        }

        public ViewResult IndexWithViewBag()
        {
            ViewBag.Message = TempData["Message"];
            ViewBag.Date = TempData["date"];

            return View();
        }

        public RedirectResult Redirect()
        {
            return Redirect("/Example/Index");
        }

        public RedirectResult RedirectPermanent()
        {
            return RedirectPermanent("/Example/Index");
        }
        public RedirectToRouteResult RedirectToRoute()
        {
            TempData["Message"] = "Hello";
            TempData["Date"] = DateTime.Now;
            return RedirectToAction("IndexWithViewBag");
        }

        public RedirectToRouteResult RedirectToRoutePermanent()
        {
            return RedirectToActionPermanent("Index", "Derived");
        }

        public HttpStatusCodeResult StatusCodeNotFound()
        {
            return new HttpStatusCodeResult(404, "Url cannot be serviced");
        }
        public HttpStatusCodeResult StatusCodeNotFoundAlternate()
        {
            return HttpNotFound();
        }
        public HttpStatusCodeResult StatusCode()
        {
            return new HttpUnauthorizedResult();
        }
    }
}
