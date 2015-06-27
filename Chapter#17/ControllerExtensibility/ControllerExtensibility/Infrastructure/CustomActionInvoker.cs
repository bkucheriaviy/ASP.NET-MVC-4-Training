using System.Web.Mvc;

namespace ControllerExtensibility.Infrastructure
{
    public class CustomActionInvoker: IActionInvoker
    {
        public bool InvokeAction(ControllerContext controllerContext, string actionName)
        {
            if (actionName != "Index")
                return false;

            controllerContext.HttpContext.Response.Write("This is output from the Index action");
            return true;
        }
    }
}