using System.Web.Mvc;

namespace ControllersAndRoutes.Infrastructure
{
   public class CustomRedirectResult: ActionResult
    {
       public string Url { get; set; }
       public override void ExecuteResult(ControllerContext context)
       {
           var fullUrl = UrlHelper.GenerateContentUrl(Url, context.HttpContext);
           context.HttpContext.Response.Redirect(fullUrl);
       }
    }
}
