using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace UrlsAndRoutes.Infrastructure
{
    public class LegacyRoute : RouteBase
    {
        private readonly string[] _targetUrls;

        public LegacyRoute(params string[] targetUrls)
        {
            _targetUrls = targetUrls;
        }

        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            var requestedUrl = httpContext.Request.AppRelativeCurrentExecutionFilePath;
            if (!_targetUrls.Contains(requestedUrl)) return null;

            var result = new RouteData(this, new MvcRouteHandler());
            result.Values.Add("controller", "Legacy");
            result.Values.Add("action", "GetLegacyUrl");
            result.Values.Add("legacyUrl", requestedUrl);
            return result;
        }

        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            if (!values.ContainsKey("legacyUrl") && !_targetUrls.Contains(values["legacyUrl"])) return null;
            return new VirtualPathData(this, new UrlHelper(requestContext).Content((string) values["legacyUrl"]).Substring(1));
        }
    }
}