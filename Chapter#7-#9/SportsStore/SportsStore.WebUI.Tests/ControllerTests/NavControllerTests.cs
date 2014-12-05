using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Controllers;

namespace SportsStore.WebUI.Tests.ControllerTests
{
    [TestClass]
    public class NavControllerTests
    {
        [TestMethod]
        public void MenuReturnsCorrectCategories()
        {
            //given
            var mockProductRepository = new Mock<IProductRepository>();
            mockProductRepository.Setup(p => p.Products).Returns(new[]
            {
                new Product {Name = "Kayak", Category = "Watersports", Price = 275M},
                new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.5M},
                new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.5M},
                new Product {Name = "Corner flag", Category = "Soccer", Price = 34.5M}
            });
            //when
            var productController = new NavController(mockProductRepository.Object);

            var result = ((IEnumerable<string>)productController.Menu().Model).ToArray();

            //then
            Assert.AreEqual(result.Count(), 2);
            Assert.AreEqual(result[0], "Soccer");
            Assert.AreEqual(result[1], "Watersports");
        }

        [TestMethod]
        public void MenuReturnsCurrentSelectedCategory()
        {
            //given
            var mockProductRepository = new Mock<IProductRepository>();
            mockProductRepository.Setup(p => p.Products).Returns(new[]
            {
                new Product {Name = "Kayak", Category = "Watersports", Price = 275M},
                new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.5M},
                new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.5M},
                new Product {Name = "Corner flag", Category = "Soccer", Price = 34.5M}
            });
            //when
            var productController = new NavController(mockProductRepository.Object);

            var result = productController.Menu("Soccer").ViewBag.SelectedCategory;

            //then
            Assert.AreEqual(result, "Soccer");
        }
    }
}
