using System;
using System.Web.Mvc;

namespace Filters.Infrastructure
{
    public class RangeExceptionAttribute: FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled && filterContext.Exception is ArgumentOutOfRangeException)
            {
                var value = (int)(filterContext.Exception as ArgumentOutOfRangeException).ActualValue;
                filterContext.Result = new ViewResult
                {
                    ViewName = "RangeError",
                    ViewData = new ViewDataDictionary<int>(value)
                };
                filterContext.ExceptionHandled = true;
            }
        }
    }
}
