using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Lesson01.Filters
{
    public class CustomAuthorize : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            HttpRequestMessage request = actionContext.Request;
            AuthenticationHeaderValue authorization = request.Headers.Authorization;

            if (authorization == null)
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, Resources.WebApiResource.AutorizeErrorMessage);

            return;
            base.OnAuthorization(actionContext);
        }
    }
}