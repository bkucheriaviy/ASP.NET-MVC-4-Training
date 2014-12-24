using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using UrlsAndRoutes.Infrastructure;

namespace UrlsAndRoutes
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute("OnlyChromeRoute", "Chrome/{*all}",
                new {controller = "Home", action = "CustomVariable", id = "Chrome"},
                new
                {
                    customConstrain = new UserAgentConstraint("Chrome")
                },
                new[] {"UrlsAndRoutes.Controllers"});
            routes.MapRoute("", "Public/{controller}/{action}/{id}/{*catchall}",
                new {controller = "Home", action = "Index", id = UrlParameter.Optional},
                new
                {
                    controller = "^H.*",
                    action = "^Index$|^About$",
                    httpMethod = new HttpMethodConstraint("GET")
                },
                new[] {"UrlsAndRoutes.Controllers.AdditionalControlers"});

            routes.MapRoute("", "{controller}/{action}/{id}/{*catchall}",
                new {controller = "Home", action = "Index", id = UrlParameter.Optional},
                new
                {
                    controller = "^H.*",
                    action = "^Index$|^CustomVariable$",
                    httpMethod = new HttpMethodConstraint("GET")
                },
                new[] {"UrlsAndRoutes.Controllers"});
        }
    }
}