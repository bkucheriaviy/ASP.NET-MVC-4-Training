using System;
using System.Web.Mvc;

namespace Views.Infrastrucutre
{
    public class DebugDataViewEngine: IViewEngine
    {
        public ViewEngineResult FindPartialView(ControllerContext controllerContext, string partialViewName, bool useCache)
        {
            return new ViewEngineResult(new[] { "No view (Debug Data View Engine" });
        }

        public ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName,
            bool useCache)
        {
            if (viewName != "DebugData") 
                return new ViewEngineResult(new[] {"No view (Debug Data View Engine"});

            return new ViewEngineResult(new DebugDataView(), this);
        }

        public void ReleaseView(ControllerContext controllerContext, IView view)
        {
            
        }
    }
}