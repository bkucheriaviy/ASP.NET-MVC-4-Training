using System.Threading.Tasks;
using System.Web.Mvc;
using ControllerExtensibility.Infrastructure;

namespace ControllerExtensibility.Controllers
{
    public class RemoteDataController : AsyncController
    {
        public async Task<ActionResult> Data()
        {
            var service = new RemoteService();
            return View((object) (await Task<string>.Factory.StartNew(service.GetRemoteData)));
        }

        public async Task<ActionResult> ConsumeAsyncMethod()
        {
            return View("Data", (object) (await new RemoteService().GetRemoteDataAsync()));
        }
    }
}
