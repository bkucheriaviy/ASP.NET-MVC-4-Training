using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.Tests.DomainTests.Entities
{
    [TestClass]
   public class CartTests
    {
        [TestMethod]
        public void CartAddItemInCollection()
        {
            //given
            var product = new Product {ProductId = 1, Price = 10};
            var product2 = new Product { ProductId = 2, Price = 20 };
            var cart = new Cart();
            //when
            cart.AddItem(product, 1);
            cart.AddItem(product2, 1);
            //then
            Assert.AreEqual(2, cart.Lines.Count);
            Assert.AreEqual(product, cart.Lines[0].Product);
            Assert.AreEqual(product2, cart.Lines[1].Product);
        }
        [TestMethod]
        public void CartAddItemAndIncreaseQuantity()
        {
            //given
            var product = new Product { ProductId = 1, Price = 10 };
            var product2 = new Product { ProductId = 2, Price = 20 };
            var cart = new Cart();
            //when
            cart.AddItem(product, 1);
            cart.AddItem(product2, 2);
            cart.AddItem(product, 10);
            //then
            Assert.AreEqual(2, cart.Lines.Count);
            Assert.AreEqual(2, cart.Lines[1].Quantity);
            Assert.AreEqual(11, cart.Lines[0].Quantity);
        }

        [TestMethod]
        public void CartRemoveLineFromCollection()
        {
            //given
            var product = new Product {ProductId = 1, Price = 10};
            var product2 = new Product {ProductId = 2, Price = 20};
            var cart = new Cart();
            cart.AddItem(product, 1);
            cart.AddItem(product2, 2);
            //when
            cart.RemoveLine(new Product {ProductId = 2});
            //then
            Assert.AreEqual(1, cart.Lines.Count);
            Assert.AreEqual(0, cart.Lines.Count(l => l.Product.ProductId == product2.ProductId));
        }

        [TestMethod]
        public void CartComputeTotalValue()
        {
            //given
            var product = new Product {ProductId = 1, Price = 10};
            var product2 = new Product {ProductId = 2, Price = 20};
            var cart = new Cart();
            cart.AddItem(product, 1);
            cart.AddItem(product2, 2);
            cart.AddItem(product, 3);
            //when
            var result = cart.ComputeTotalValue();
            //then
            Assert.AreEqual(80, result);
        }

        [TestMethod]
        public void CartClearCollection()
        {
            //given
            var product = new Product {ProductId = 1, Price = 10};
            var product2 = new Product {ProductId = 2, Price = 20};
            var cart = new Cart();
            cart.AddItem(product, 1);
            cart.AddItem(product2, 2);
            cart.AddItem(product, 3);
            //when
            cart.Clear();
            //then
            Assert.AreEqual(0, cart.Lines.Count);
        }
    }
}
