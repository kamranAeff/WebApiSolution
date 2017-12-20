using NLog;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Lesson01.Filters
{
    public class ControllerBasedLogFilterAttribute : ActionFilterAttribute
    {
        Logger logger = LogManager.GetCurrentClassLogger();
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            logger.Warn($"[ControllerBased] : Controller Name: {actionContext.ActionDescriptor.ControllerDescriptor.ControllerName} " +
                $"Action Name: {actionContext.ActionDescriptor.ActionName} -OnActionExecuting");
            base.OnActionExecuting(actionContext);
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            logger.Warn($"[ControllerBased] : Controller Name: {actionExecutedContext.ActionContext.ActionDescriptor.ControllerDescriptor.ControllerName} " +
                $"Action Name: {actionExecutedContext.ActionContext.ActionDescriptor.ActionName} -OnActionExecuted");
            base.OnActionExecuted(actionExecutedContext);
        }
    }
}