
using Lesson01.Binders;
using Lesson01.Filters;
using Lesson01.Models;
using Lesson01.Utils;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Lesson01.Controllers
{
    [ControllerBasedLogFilter]
    [RoutePrefix("api")]
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

            //return Request.CreateResponse<List<Person>>(HttpStatusCode.OK, list);

            return Request.CreateResponse(HttpStatusCode.OK, list);
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

        /// <summary>
        /// http://localhost:49146/api/ValueDate/20170101
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        [Route("ValueDate/{date}")]
        [HttpGet]
        public IHttpActionResult ValueDate([DateTimeParameter] DateTime? date)
        {
            return Ok(date.DateToText());
        }

        /// <summary>
        /// http://localhost:49146/api/ValueCustomDate/01_02_2017
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        [Route("ValueCustomDate/{date}")]
        [HttpGet]
        public IHttpActionResult ValueCustomDateFormat([DateTimeParameter(DateFormat = "dd_MM_yyyy")] DateTime? date)
        {
            return Ok(date.DateToText());
        }

        /// <summary>
        /// http://localhost:49146/api/ValueCustomDateBind/?date=20.01.2017 00:01:02
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        [Route("ValueCustomDateBind")]
        [HttpGet]
        public IHttpActionResult ValueCustomDateGet(DateTime? date)
        {
            if (date == null)
                return BadRequest();

            return Ok(date.DateToText());
        }

        [Route("ValueCustomDateBind")]
        [HttpPost]
        public IHttpActionResult ValueCustomDatePost([FromBody]string dateString)
        {
            DateTime? date = dateString.ExtractDateFromString();

            if (date == null)
                return BadRequest();

            return Ok(date.DateToText());
        }


        /// <summary>
        /// http://localhost:49146/api/ColorType/123,20,16
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        [Route("ColorType/{color}")]
        [HttpGet]
        public IHttpActionResult ColorType(Color color)
        {
            if (color == null)
                return BadRequest();



                return Ok(color);
        }


        [Route("Person/Add")]
        [HttpPost]
        public IHttpActionResult AddPerson(Person person)
        {
            return Ok(person.ToString());
        }
    }
}
