
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

        /// <summary>
        /// Send Request for HttpGet*
        /// http://localhost:49146/api/Person/Developer
        /// HeaderValues
        /// {
        /// Accept-Language : en-US                 /*default az-Latn*/
        /// Accept : application/json
        /// }
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage Developer()
        {
            return Request.CreateResponse(HttpStatusCode.OK, Resources.WebApiResource.Programmer);
        }
    }
}
