using System;
using EssentialTool.Models.DiscountHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EssentialTool.Tests
{
    [TestClass]
    public class MinimumDiscountHelperTests
    {
        [TestMethod]
        public void DiscountAbove100()
        {
            //given
            var target = new MinimumDiscountHelper();
            const decimal total = 200m;
            //when
            var discountedTotal = target.ApplyDiscount(total);
            //then
            Assert.AreEqual(total*0.9m, discountedTotal);
        }
        [TestMethod]
        public void DiscountBetween10And100()
        {
            //given
            var target = new MinimumDiscountHelper();
            //when
            var tenDollarDiscount = target.ApplyDiscount(10);
            var hundredDollarDiscount = target.ApplyDiscount(100);
            var fiftyDollarDiscount = target.ApplyDiscount(50);
            //then
            Assert.AreEqual(5, tenDollarDiscount,"10$ discount is wrong");
            Assert.AreEqual(95, hundredDollarDiscount, "100$ discount is wrong");
            Assert.AreEqual(45, fiftyDollarDiscount, "50$ discount is wrong");
        }
        [TestMethod]
        public void DiscountLessThan10()
        {
            //given
            var target = new MinimumDiscountHelper();
            //when
            var discountFive = target.ApplyDiscount(5);
            var discountZero = target.ApplyDiscount(0);
            //then
            Assert.AreEqual(5, discountFive);
            Assert.AreEqual(0, discountZero);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void DiscountNegativeTotal()
        {
            //given
            var target = new MinimumDiscountHelper();
            //when
            target.ApplyDiscount(-1);
        }
    }
}
