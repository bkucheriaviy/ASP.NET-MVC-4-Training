using System.Web;
using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UrlsAndRoutes.Tests
{
    [TestClass]
    public class RouteTests
    {
        [TestMethod]
        public void TestIncomingRoutes()
        {
            TestRouteMatch("~/", "Home", "Index");
            TestRouteMatch("~/Home", "Home", "Index");
            TestRouteMatch("~/Home/Index", "Home", "Index");
            TestRouteMatch("~/Public/Home/About", "Home", "About");
            TestRouteMatch("~/Public/Home/About/MyId", "Home", "About", new {id = "MyId"});
            TestRouteMatch("~/Public/Home/About/MyId/More/Segments", "Home", "About", new {id = "MyId", catchall = "More/Segments"});
            TestRouteFail("~/Home/OtherAction");
            TestRouteFail("~/Account/Index");
            TestRouteFail("~/Account/About");
            //TestRouteMatch("~/Admin", "Admin", "Index");
            //TestRouteMatch("~/Admin/Index", "Admin", "Index");
            //TestRouteMatch("~/Customer", "Customer", "Index");
            //TestRouteMatch("~/Customer/List", "Customer", "List");
            //TestRouteMatch("~/Customer/List/All/", "Customer", "List", new {id = "All"});
            //TestRouteMatch("~/Customer/List/All/Delete","Customer", "List", new {id = "All",catchall="Delete"});
            //TestRouteMatch("~/Customer/List/All/Delete/Perm", "Customer", "List", new { id = "All", catchall = "Delete/Perm" });
        }

        private void TestRouteMatch(string url, string controller, string action, object propertySet = null)
        {
            //given
            var httpContext = CreateHttpContext(url);
            var routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);
            //when
            var result = routes.GetRouteData(httpContext);
            //then
            Assert.IsNotNull(result);
            Assert.AreEqual(controller, result.Values["controller"]);
            Assert.AreEqual(action, result.Values["action"]);

            //then for properties cases
            if (propertySet != null)
            {
                var propInfo = propertySet.GetType().GetProperties();
                foreach (var p in propInfo)
                {
                    Assert.IsTrue(result.Values.ContainsKey(p.Name));
                    Assert.AreEqual(p.GetValue(propertySet, null).ToString(), result.Values[p.Name]);
                }
            }
        }

        private void TestRouteFail(string url)
        {
            //given
            var httpContext = CreateHttpContext(url);
            var routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);
            //when
            var result = routes.GetRouteData(httpContext);
            //then
            Assert.IsNull(result);
        }
        private HttpContextBase CreateHttpContext(string url = null, string httpMentod = "GET")
        {
            var mockHttpRequest = new Mock<HttpRequestBase>();
            mockHttpRequest.Setup(r => r.AppRelativeCurrentExecutionFilePath).Returns(url);
            mockHttpRequest.Setup(r => r.HttpMethod).Returns(httpMentod);
            var mockHttpResponse = new Mock<HttpResponseBase>();
            var mockHttpContext = new Mock<HttpContextBase>();
            mockHttpContext.Setup(c => c.Request).Returns(mockHttpRequest.Object);
            mockHttpContext.Setup(c => c.Response).Returns(mockHttpResponse.Object);
            return mockHttpContext.Object;
        }

       
    }
}
