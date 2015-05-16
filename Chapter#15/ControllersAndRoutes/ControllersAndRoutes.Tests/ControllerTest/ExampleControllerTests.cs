using System;
using ControllersAndRoutes.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ControllersAndRoutes.Tests.ControllerTest
{
    [TestClass]
    public class ExampleControllerTests
    {
        [TestMethod]
        public void TestIndex()
        {
            //given
            var controller = new ExampleController();
            //when
            var result = controller.Index();
            //then
            Assert.AreEqual("", result.ViewName);
            Assert.AreEqual(DateTime.Now.DayOfWeek, ((DateTime) result.Model).DayOfWeek);
        }

        [TestMethod]
        public void TestHome()
        {
            //given
            var controller = new ExampleController();
            //when
            var result = controller.Home();
            //then
            Assert.AreEqual("Homepage", result.ViewName);
        }

        [TestMethod]
        public void TestIndexAlternateLayout()
        {
            //given
            var controller = new ExampleController();
            //when
            var result = controller.IndexAlternateLayout();
            //then
            Assert.AreEqual("Index", result.ViewName);
            Assert.AreEqual("_AlternateLayoutPage", result.MasterName);
        }

        [TestMethod]
        [Ignore]
        public void TestIndexWithViewBag()
        {
            //given
            var controller = new ExampleController();
            //when
            var result = controller.IndexWithViewBag();
            //then
            Assert.AreEqual("", result.ViewName);
            Assert.AreEqual(DateTime.Now.DayOfWeek, result.ViewBag.Date.DayOfWeek);
            Assert.AreEqual("Hello from ViewBag", result.ViewBag.Message);
        }

        [TestMethod]
        public void TestRedirect()
        {
            //given
            var controller = new ExampleController();
            //when
            var result = controller.Redirect();
            //then
            Assert.AreEqual(false, result.Permanent);
            Assert.AreEqual("/Example/Index", result.Url);
        }

        [TestMethod]
        public void TestRedirectPermanent()
        {
            //given
            var controller = new ExampleController();
            //when
            var result = controller.RedirectPermanent();
            //then
            Assert.AreEqual(true, result.Permanent);
            Assert.AreEqual("/Example/Index", result.Url);
        }

        [TestMethod]
        public void TestRedirectToRoute()
        {
            //given
            var controller = new ExampleController();
            //when
            var result = controller.RedirectToRoute();
            //then
            Assert.AreEqual(false, result.Permanent);
            Assert.AreEqual(null, result.RouteValues["controller"]);
            Assert.AreEqual("IndexWithViewBag", result.RouteValues["action"]);
        }

        [TestMethod]
        public void TestRedirectToRoutePermanent()
        {
            //given
            var controller = new ExampleController();
            //when
            var result = controller.RedirectToRoutePermanent();
            //then
            Assert.AreEqual(true, result.Permanent);
            Assert.AreEqual("Derived", result.RouteValues["controller"]);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        public void TestStatusCode()
        {
            //given
            var controller = new ExampleController();
            //when
            var result = controller.StatusCode();
            //then
            Assert.AreEqual(401, result.StatusCode);
        }
        [TestMethod]
        public void TestStatusCodeNotFound()
        {
            //given
            var controller = new ExampleController();
            //when
            var result = controller.StatusCodeNotFound();
            //then
            Assert.AreEqual(404, result.StatusCode);
        }
        [TestMethod]
        public void TestStatusCodeNotFoundAlternate()
        {
            //given
            var controller = new ExampleController();
            //when
            var result = controller.StatusCodeNotFoundAlternate();
            //then
            Assert.AreEqual(404, result.StatusCode);
        }
    }
}
