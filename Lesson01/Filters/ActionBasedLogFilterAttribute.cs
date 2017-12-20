using NLog;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Lesson01.Filters
{
    public class ActionBasedLogFilterAttribute : ActionFilterAttribute
    {
        Logger logger = LogManager.GetCurrentClassLogger();
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            logger.Info($"[ActionBased] : Controller Name: {actionContext.ActionDescriptor.ControllerDescriptor.ControllerName} " +
                $"Action Name: {actionContext.ActionDescriptor.ActionName} -OnActionExecuting");
            base.OnActionExecuting(actionContext);
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            logger.Info($"[ActionBased] : Controller Name: {actionExecutedContext.ActionContext.ActionDescriptor.ControllerDescriptor.ControllerName} " +
                $"Action Name: {actionExecutedContext.ActionContext.ActionDescriptor.ActionName} -OnActionExecuted");
            base.OnActionExecuted(actionExecutedContext);
        }
    }
}