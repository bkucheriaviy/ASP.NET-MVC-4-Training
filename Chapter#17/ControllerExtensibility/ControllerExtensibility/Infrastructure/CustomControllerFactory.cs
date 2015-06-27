using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using ControllerExtensibility.Controllers;

namespace ControllerExtensibility.Infrastructure
{
    public class CustomControllerFactory : IControllerFactory
    {
        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            switch (controllerName)
            {
                case "Product":
                    return (IController) DependencyResolver.Current.GetService(typeof(ProductController));
                case "Customer":
                    return (IController)DependencyResolver.Current.GetService(typeof(CustomerController));
                default:
                {
                    requestContext.RouteData.Values["controller"] = "Product";
                    return (IController) DependencyResolver.Current.GetService(typeof(ProductController));
                }
            }
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Default;
        }

        public void ReleaseController(IController controller)
        {
            var disposable = controller as IDisposable;
            if (disposable != null)
                disposable.Dispose();
        }
    }
}