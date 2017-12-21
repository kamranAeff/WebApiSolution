using NLog;
using System;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson01.Filters
{
    /// <summary>
    /// Implementation from IActionFilter, IFilter
    /// </summary>
    [AttributeUsage(AttributeTargets.Method,AllowMultiple = false,Inherited = false)]
    public class ActionBasedLogFilterAttribute : Attribute, IActionFilter, IFilter
    {
        public bool AllowMultiple => false;
        

        public Task<HttpResponseMessage> ExecuteActionFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        {
            Logger logger = LogManager.GetCurrentClassLogger();

            logger.Info($"[ActionBased] : Controller Name: {actionContext.ActionDescriptor.ControllerDescriptor.ControllerName} " +
                $"Action Name: {actionContext.ActionDescriptor.ActionName} -OnActionExecuting");

            var response = continuation.Invoke();

            logger.Info($"[ActionBased] : Controller Name: {actionContext.ActionDescriptor.ControllerDescriptor.ControllerName} " +
                $"Action Name: {actionContext.ActionDescriptor.ActionName} -OnActionExecuted");

            return response;
        }
    }
}