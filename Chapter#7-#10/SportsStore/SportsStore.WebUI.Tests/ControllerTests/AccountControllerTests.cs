using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.WebUI.Controllers;
using SportsStore.WebUI.Infrastructure.Abstract;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Tests.ControllerTests
{
    [TestClass]
    public class AccountControllerTests
    {
        [TestMethod]
        public void AccountControllerLoginCanLogin()
        {
            //given
            var authProvider = new Mock<IAuthProvider>();
            authProvider.Setup(p => p.Authenticate("admin", "secret")).Returns(true);
            var model = new LoginViewModel {UserName = "admin", Password = "secret"};
            var accountController = new AccountController(authProvider.Object);
            //when
            var result = accountController.Login(model, "/MyUrl");
            //then
            Assert.IsInstanceOfType(result, typeof (RedirectResult));
            Assert.AreEqual("/MyUrl", ((RedirectResult) result).Url);
        }

        [TestMethod]
        public void AccountControllerLoginCantLoginWithBadUsernameAndPassword()
        {
            //given
            var authProvider = new Mock<IAuthProvider>();
            authProvider.Setup(p => p.Authenticate("admin", "secret")).Returns(true);
            var model = new LoginViewModel { UserName = "BadAdmin", Password = "BadSecret" };
            var accountController = new AccountController(authProvider.Object);
            //when
            var result = accountController.Login(model, "/MyUrl");
            //then
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.AreEqual(false, ((ViewResult) result).ViewData.ModelState.IsValid);
        }
    }
}
