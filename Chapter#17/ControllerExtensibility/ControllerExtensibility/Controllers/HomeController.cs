using System.Web.Mvc;
using ControllerExtensibility.Infrastructure.ActionMethodSelectors;
using ControllerExtensibility.Models;

namespace ControllerExtensibility.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("Result", new Result {ActionName = "Index", ControllerName = "Home"});
        }

        [Local]
        [ActionName("Index")]
        public ActionResult LocalIndex()
        {
            return View("Result", new Result { ActionName = "LocalIndex", ControllerName = "Home" });
        }

        protected override void HandleUnknownAction(string actionName)
        {
            Response.Write(string.Format("You requested the {0} action", actionName));
        }
    }
}
