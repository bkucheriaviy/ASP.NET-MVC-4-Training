using System;
using System.Collections.Generic;
using System.Linq;
using EssentialTool.Models;
using EssentialTool.Models.DiscountHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EssentialTool.Tests
{
    [TestClass]
    public class LinqValueCalculatorTests
    {
        private readonly Product[] _products =
        {
            new Product {Name = "Kayak", Category = "Watersports", Price = 275M},
            new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.5M},
            new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.5M},
            new Product {Name = "Corner flag", Category = "Soccer", Price = 34.5M}
        };

        [TestMethod]
        public void SumProductsCorrectly()
        {
            //given
            var mockDiscounter = new Mock<IDiscountHelper>();
            mockDiscounter.Setup(d => d.ApplyDiscount(It.IsAny<decimal>()))
                .Returns<decimal>(total => total);
            var target = new LinqValueCalculator(mockDiscounter.Object);
            //when
            var result = target.ValueProduct(_products);
            //then
            Assert.AreEqual(_products.Sum(p => p.Price), result);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void PassThroughVariableDiscounts()
        {
            //given
            var mockDiscounter = new Mock<IDiscountHelper>();
            mockDiscounter.Setup(d => d.ApplyDiscount(It.IsAny<decimal>()))
                .Returns<decimal>(total => total);
            mockDiscounter.Setup(d => d.ApplyDiscount(It.Is<decimal>(v => v == 0)))
                .Throws<ArgumentOutOfRangeException>();
            mockDiscounter.Setup(d => d.ApplyDiscount(It.Is<decimal>(v => v > 100)))
                .Returns<decimal>(total => total*0.9M);
            mockDiscounter.Setup(d => d.ApplyDiscount(It.IsInRange<decimal>(10, 100, Range.Inclusive)))
                .Returns<decimal>(total => total - 5);

            var target = new LinqValueCalculator(mockDiscounter.Object);
            //when
            var fiveDollarDiscount = target.ValueProduct(CreateProduct(5));
            var tenDollarDiscount = target.ValueProduct(CreateProduct(10));
            var fiftyDollarDiscount = target.ValueProduct(CreateProduct(50));
            var hundredDollarDiscount = target.ValueProduct(CreateProduct(100));
            var fiveHundredDollarDiscount = target.ValueProduct(CreateProduct(500));
            //then
            Assert.AreEqual(5, fiveDollarDiscount, "$5 Fail");
            Assert.AreEqual(5, tenDollarDiscount, "$10 Fail");
            Assert.AreEqual(45, fiftyDollarDiscount, "$50 Fail");
            Assert.AreEqual(95, hundredDollarDiscount, "$100 Fail");
            Assert.AreEqual(450, fiveHundredDollarDiscount, "$500 Fail");
            target.ValueProduct(CreateProduct(0));
        }

        private IEnumerable<Product> CreateProduct(decimal value)
        {
            return new[] {new Product {Price = value}};
        }
    }
}
