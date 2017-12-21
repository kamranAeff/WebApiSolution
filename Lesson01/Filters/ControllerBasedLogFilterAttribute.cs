using NLog;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson01.Filters
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class ControllerBasedLogFilterAttribute : FilterAttribute, IActionFilter, IFilter
    {
        override public bool AllowMultiple => false;

        public Task<HttpResponseMessage> ExecuteActionFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        {
            Logger logger = LogManager.GetCurrentClassLogger();

            logger.Warn($"[ControllerBased] : Controller Name: {actionContext.ActionDescriptor.ControllerDescriptor.ControllerName} " +
                $"Action Name: {actionContext.ActionDescriptor.ActionName} -OnActionExecuting");

            var response = continuation.Invoke();

            logger.Info($"[ControllerBased] : Controller Name: {actionContext.ActionDescriptor.ControllerDescriptor.ControllerName} " +
                $"Action Name: {actionContext.ActionDescriptor.ActionName} -OnActionExecuted");

            return response;
        }
    }
}