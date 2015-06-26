using System.Web.Mvc;
using Filters.Infrastructure;

namespace Filters.Controllers
{
    public class CustomerController : Controller
    {

        [SimpleMessage(Message = "Message A", Order = 2)]
        [SimpleMessage(Message = "Message B", Order = 1)]
        public string Index()
        {
            return "This is Customer Controller";
        }
    }
}
