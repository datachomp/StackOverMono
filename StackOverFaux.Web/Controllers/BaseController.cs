using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMiniProfiler;
//using Profiling;

namespace StackOverFaux.Controllers
{
    public abstract class BaseController : Controller
    {

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var profiler = MiniProfiler.Current;

            using (profiler.Step("OnActionExecuting"))
            {
                base.OnActionExecuting(filterContext);
            }
        }

        
        protected override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            _resultExecutingToExecuted = MiniProfiler.Current.Step("OnResultExecuting");

            base.OnResultExecuting(filterContext);
        }

        private IDisposable _resultExecutingToExecuted;

        protected override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            if (_resultExecutingToExecuted != null)
                _resultExecutingToExecuted.Dispose();

            base.OnResultExecuted(filterContext);
        }
    }
}