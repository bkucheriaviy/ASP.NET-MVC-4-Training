using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Controllers;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Tests.ControllerTests
{
    [TestClass]
    public class ProductControllerTests
    {
        [TestMethod]
        public void ProductControllerListReturnsProductsPerPage()
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
            var productController = new ProductController(mockProductRepository.Object) {PageSize = 3};

            var result = ((ProductListViewModel)productController.List(null,2).Model).Products.ToList();

            //then
            Assert.AreEqual(result.Count(), 1);
            Assert.AreEqual(result[0].Name, "Corner flag");
        }

        [TestMethod]
        public void ProductControllerListReturnsCorrectPageInfo()
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
            var productController = new ProductController(mockProductRepository.Object) { PageSize = 3 };

            var result = ((ProductListViewModel) productController.List(null, 2).Model).PagingInfo;

            //then
            Assert.AreEqual(result.TotalItems, 4);
            Assert.AreEqual(result.TotalPages, 2);
            Assert.AreEqual(result.ItemsPerPage, 3);
            Assert.AreEqual(result.CurrentPage, 2);
        }

        [TestMethod]
        public void ProductControllerListReturnsProductByCategory()
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
            var productController = new ProductController(mockProductRepository.Object) {PageSize = 3};

            var result = ((ProductListViewModel) productController.List("Watersports").Model).Products.ToList();

            //then
            Assert.AreEqual(result.Count, 2);
            Assert.AreEqual(result[0].Name, "Kayak");
            Assert.AreEqual(result[0].Category, "Watersports");
            Assert.AreEqual(result[1].Name, "Lifejacket");
            Assert.AreEqual(result[0].Category, "Watersports");
        }

        [TestMethod]
        public void ProductControllerListReturnsCOrrectPageInfoForCategory()
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
            var productController = new ProductController(mockProductRepository.Object) { PageSize = 3 };

            var result = ((ProductListViewModel)productController.List("Soccer").Model).PagingInfo;

            //then
            Assert.AreEqual(result.TotalItems, 2);
            Assert.AreEqual(result.TotalPages, 1);
            Assert.AreEqual(result.ItemsPerPage, 3);
            Assert.AreEqual(result.CurrentPage, 1);
        }
    }
}
