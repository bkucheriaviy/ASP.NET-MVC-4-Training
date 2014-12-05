using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Controllers;

namespace SportsStore.WebUI.Tests.ControllerTests
{
    [TestClass]
    public class CartControllerTests
    {
        [TestMethod]
        public void CartControllerAddToCart()
        {
            //given
            var mockProductRepository = new Mock<IProductRepository>();
            mockProductRepository.Setup(r => r.Products)
                .Returns(new[] {new Product {ProductId = 1, Name = "Product 1"}});
            var cart = new Cart();
            var cartController = new CartController(mockProductRepository.Object, null);
            //when
            cartController.AddToCart(cart, 1, null);
            //then
            Assert.AreEqual(1, cart.Lines.Count);
            Assert.AreEqual(1, cart.Lines[0].Product.ProductId);
        }

        [TestMethod]
        public void CartControllerAddToCartReturnsRedirectOnIndexAction()
        {
            //given
            var mockProductRepository = new Mock<IProductRepository>();
            mockProductRepository.Setup(r => r.Products)
                .Returns(new[] {new Product {ProductId = 1, Name = "Product 1"}});
            var cart = new Cart();
            var cartController = new CartController(mockProductRepository.Object, null);
            //when
            var redirectResult = cartController.AddToCart(cart, 1, "MyReturnUrl");
            //then
            Assert.AreEqual("Index", redirectResult.RouteValues["action"]);
            Assert.AreEqual("MyReturnUrl", redirectResult.RouteValues["returnUrl"]);
        }

        [TestMethod]
        public void CartControllerRemoveFromCartRemovesProductFromLine()
        {
            var mockProductRepository = new Mock<IProductRepository>();
            mockProductRepository.Setup(r => r.Products)
                .Returns(new[] {new Product {ProductId = 1, Name = "Product 1"}});
            //given
            var cart = new Cart();
            var cartController = new CartController(mockProductRepository.Object, null);
            cartController.AddToCart(cart, 1, null);
            //when
            cartController.RemoveFromCart(cart, 1, null);
            //then
            Assert.AreEqual(0, cart.Lines.Count);
        }

        [TestMethod]
        public void CartControllerRemoveFromCartReturnsRedirectOnIndexAction()
        {
            var mockProductRepository = new Mock<IProductRepository>();
            mockProductRepository.Setup(r => r.Products)
                .Returns(new[] {new Product {ProductId = 1, Name = "Product 1"}});
            //given
            var cart = new Cart();
            var cartController = new CartController(mockProductRepository.Object, null);
            cartController.AddToCart(cart, 1, null);
            //when
            var redirectResult = cartController.RemoveFromCart(cart, 1, "MyReturnUrl");
            //then
            Assert.AreEqual("Index", redirectResult.RouteValues["action"]);
            Assert.AreEqual("MyReturnUrl", redirectResult.RouteValues["returnUrl"]);
        }

        [TestMethod]
        public void CartControllerCheckoutEmptyCart()
        {   
            //given
            var mockOrderProcessor = new Mock<IOrderProcessor>();
            var cart = new Cart();
            var shippingDetails = new ShippingDetails();
            var cartController = new CartController(null, mockOrderProcessor.Object);
            //when
            var result = cartController.Checkout(cart, shippingDetails);
            //then
            mockOrderProcessor.Verify(x => x.ProcessOrder(It.IsAny<Cart>(), It.IsAny<ShippingDetails>()), Times.Never);
            Assert.AreEqual("", result.ViewName);
            Assert.AreEqual(false, result.ViewData.ModelState.IsValid);
        }

        [TestMethod]
        public void CartControllerCheckoutEmptyShippingDetails()
        {
            //given
            var mockOrderProcessor = new Mock<IOrderProcessor>();
            var cart = new Cart();
            cart.AddItem(new Product(), 1);
            var shippingDetails = new ShippingDetails();
            var cartController = new CartController(null, mockOrderProcessor.Object);
            cartController.ModelState.AddModelError("Error", "Error");
            //when
            var result = cartController.Checkout(cart, shippingDetails);
            //then
            mockOrderProcessor.Verify(x => x.ProcessOrder(It.IsAny<Cart>(), It.IsAny<ShippingDetails>()), Times.Never);
            Assert.AreEqual("", result.ViewName);
            Assert.AreEqual(false, result.ViewData.ModelState.IsValid);
        }

        [TestMethod]
        public void CartControllerCheckout()
        {
            //given
            var mockOrderProcessor = new Mock<IOrderProcessor>();
            var cart = new Cart();
            cart.AddItem(new Product(), 1);
            var shippingDetails = new ShippingDetails();
            var cartController = new CartController(null, mockOrderProcessor.Object);

            //when
            var result = cartController.Checkout(cart, shippingDetails);
            //then
            mockOrderProcessor.Verify(x => x.ProcessOrder(It.IsAny<Cart>(), It.IsAny<ShippingDetails>()), Times.Once);
            Assert.AreEqual("Completed", result.ViewName);
            Assert.AreEqual(true, result.ViewData.ModelState.IsValid);
        }
    }
}
