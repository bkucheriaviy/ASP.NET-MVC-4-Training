using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Controllers;

namespace SportsStore.WebUI.Tests.ControllerTests
{
    [TestClass]
    public class AdminControllerTests
    {
        [TestMethod]
        public void AdminControllerIndexViewHaveCorrectProductModel()
        {
            //given
            var mockProductRepostiroy = new Mock<IProductRepository>();
            mockProductRepostiroy.Setup(p => p.Products)
                .Returns(new[]
                {
                    new Product {ProductId = 1, Name = "Product 1"},
                    new Product {ProductId = 2, Name = "Product 2"}
                });
            //when

            var result =
                ((IEnumerable<Product>) new AdminController(mockProductRepostiroy.Object).Index().ViewData.Model)
                    .ToArray();
            //then
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("Product 1", result[0].Name);
            Assert.AreEqual("Product 2", result[1].Name);
        }
        [TestMethod]
        public void AdminControllerEditCanEditExistingProduct()
        {
            //given
            var mockProductRepostiroy = new Mock<IProductRepository>();
            mockProductRepostiroy.Setup(p => p.Products)
                .Returns(new[]
                {
                    new Product {ProductId = 1, Name = "Product 1"},
                    new Product {ProductId = 2, Name = "Product 2"}
                });
            var adminController = new AdminController(mockProductRepostiroy.Object);
            //when

            var product1 = adminController.Edit(1).Model as Product;
            var product2 = adminController.Edit(2).Model as Product;
                
            //then
            Assert.AreEqual(1, product1.ProductId);
            Assert.AreEqual(2, product2.ProductId);
        }

        [TestMethod]
        public void AdminControllerEditCantEditNonExistentProduct()
        {
            //given
            var mockProductRepostiroy = new Mock<IProductRepository>();
            mockProductRepostiroy.Setup(p => p.Products)
                .Returns(new[]
                {
                    new Product {ProductId = 1, Name = "Product 1"},
                    new Product {ProductId = 2, Name = "Product 2"}
                });
            var adminController = new AdminController(mockProductRepostiroy.Object);
            //when

            var product = adminController.Edit(12).Model as Product;

            //then
            Assert.IsNull(product);
        }

        [TestMethod]
        public void AdminControllerEditSavesValidChanges()
        {
            //given
            var mockProductRepostiroy = new Mock<IProductRepository>();
            var adminController = new AdminController(mockProductRepostiroy.Object);
            var product = new Product {ProductId = 1, Name = "Product 1"};
            //when

            var result = adminController.Edit(product);

            //then
            mockProductRepostiroy.Verify(p => p.SaveProduct(product), Times.Once);
            Assert.IsNotInstanceOfType(result, typeof (ViewResult));
        }

        [TestMethod]
        public void AdminControllerEditDontSavesInValidChanges()
        {
            //given
            var mockProductRepostiroy = new Mock<IProductRepository>();
            var adminController = new AdminController(mockProductRepostiroy.Object);
            var product = new Product { ProductId = 1, Name = "Product 1" };
            //when
            adminController.ModelState.AddModelError("error", "some error");
            var result = adminController.Edit(product);

            //then
            mockProductRepostiroy.Verify(p => p.SaveProduct(product), Times.Never);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void AdminControllerDeleteProduct()
        {
            //given
            var mockProductRepostiroy = new Mock<IProductRepository>();
            mockProductRepostiroy.Setup(p => p.Products);

            var adminController = new AdminController(mockProductRepostiroy.Object);
            //when

            adminController.Delete(1);

            //then
            mockProductRepostiroy.Verify(p => p.Delete(1));
        }
    }
}
