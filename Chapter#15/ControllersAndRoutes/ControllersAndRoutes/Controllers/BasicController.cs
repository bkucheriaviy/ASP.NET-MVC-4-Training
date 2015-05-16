using System.Web.Mvc;
using System.Web.Routing;

namespace ControllersAndRoutes.Controllers
{
   public class BasicController : IController
    {
        public void Execute(RequestContext requestContext)
        {
            var controllerName = (string)requestContext.RouteData.Values["controller"];
            var actionName = (string)requestContext.RouteData.Values["action"];

            if (actionName == "Redirect")
                requestContext.HttpContext.Response.Redirect("/Derived/Index");
            else
            requestContext.HttpContext.Response.Write(string.Format("Controller: {0}. Action: {1}", controllerName, actionName));
        }
    }
}
