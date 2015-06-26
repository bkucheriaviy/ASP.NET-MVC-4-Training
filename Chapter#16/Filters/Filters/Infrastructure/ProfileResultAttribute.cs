using System.Diagnostics;
using System.Web.Mvc;

namespace Filters.Infrastructure
{
    public class ProfileResultAttribute : FilterAttribute, IResultFilter
    {
        private Stopwatch _timer;
        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            _timer = Stopwatch.StartNew();
        }

        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            _timer.Stop();
            if (filterContext.Exception == null)
                filterContext.HttpContext.Response.Write(string.Format("<div>Result method elapsed time: {0}</div>",
                    _timer.Elapsed.TotalSeconds));
        }
    }
}