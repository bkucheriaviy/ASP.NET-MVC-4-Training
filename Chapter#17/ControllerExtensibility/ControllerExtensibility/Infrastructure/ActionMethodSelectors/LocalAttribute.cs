using System.Reflection;
using System.Web.Mvc;

namespace ControllerExtensibility.Infrastructure.ActionMethodSelectors
{
    public class LocalAttribute: ActionMethodSelectorAttribute
    {
        public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
        {
            return controllerContext.HttpContext.Request.IsLocal;
        }
    }
}