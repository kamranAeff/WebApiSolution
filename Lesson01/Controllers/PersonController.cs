
using Lesson01.Filters;
using Lesson01.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Lesson01.Controllers
{
    [ControllerBasedLogFilter]
    public class PersonController : ApiController
    {
        [CustomAuthorize]
        [ActionBasedLogFilter]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK,"Developer");
        }

        [ActionBasedLogFilter]
        [ResponseType(typeof(List<Person>))]
        public HttpResponseMessage GetAll()
        {
            var list = new List<Person>
            {
                new Person("Kamran","Abdullayev"),
                new Person("Pərviz","Eminov")
            };

            return Request.CreateResponse<List<Person>>(HttpStatusCode.OK, list);
        }
    }
}
