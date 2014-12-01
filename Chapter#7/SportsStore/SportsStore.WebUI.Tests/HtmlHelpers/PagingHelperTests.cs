using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.WebUI.HtmlHelpers;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Tests.HtmlHelpers
{
    [TestClass]
    public class PagingHelperTests
    {
        [TestMethod]
        public void Can_Generate_Page_Links()
        {
            //given
            var pagingInfo = new PagingInfo
            {
                CurrentPage = 2,
                ItemsPerPage = 3,
                TotalItems = 9
            };
            var pageUrlFunc = new Func<int, string>(pageNumber => "Page" + pageNumber);
            //when
            var result =
                new HtmlHelper(new Mock<ViewContext>().Object, new Mock<IViewDataContainer>().Object).PageLinks(pagingInfo,
                    pageUrlFunc);
            //then
            Assert.AreEqual(result.ToString(), @"<a href=""Page1"">1</a><a class=""selected"" href=""Page2"">2</a><a href=""Page3"">3</a>");
        }
    }
}
