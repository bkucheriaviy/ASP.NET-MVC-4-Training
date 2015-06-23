using System;
using System.Web.Mvc;
using Filters.Infrastructure;

namespace Filters.Controllers
{
    public class HomeController : Controller
    {
        [CustomAuth(true)]
        public string Index()
        {
            return "This is the Index action on the Home controller";
        }

        [Authorize]
        public string AnotherAction()
        {
            return "This is another action";
        }

        [RangeException]
        public string RangeTest(int id)
        {
            if (id < 100)
                throw new ArgumentOutOfRangeException("id", id, "");
            return string.Format("The id value is : {0}", id);
        }

        [HandleError(ExceptionType = typeof(ArgumentOutOfRangeException), View="RangeError")]
        public string HandleErrorRangeTest(int id)
        {
            if (id < 100)
                throw new ArgumentOutOfRangeException("id", id, "");
            return string.Format("The id value is : {0}", id);
        }
    }
}
