using AutoMapper;
using Lesson01.Models;
using Lesson01.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Lesson01.Controllers
{
    [RoutePrefix("api/dictionary")]
    public class DictionaryController : ApiController
    {
        LanguageLearnContext db = new LanguageLearnContext();
        
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var data = Mapper.Map<List<BookletOfTalkingDto>>(db.BookletOfTalking.ToList());
            return Ok(data);
        }
        

        [HttpGet]
        [Route("random/{top}")]
        public IHttpActionResult GetRandom(int top)
        {
            var data = Mapper.Map<List<BookletOfTalkingDto>>(db.BookletOfTalking.OrderBy(r => Guid.NewGuid()).Take(top).ToList());
            return Ok(data);
        }

        [HttpPost]
        [Route("add")]
        public IHttpActionResult AddWord(BookletOfTalkingDto word)
        {
            var bookletOfTalking = Mapper.Map<BookletOfTalking>(word);
            db.BookletOfTalking.Add(bookletOfTalking);
            db.SaveChanges();
            return Ok();
        }

        [HttpPut]
        [Route("edit")]
        public IHttpActionResult EditWord(int id,BookletOfTalkingDto word)
        {
            var bookletOfTalking = Mapper.Map<BookletOfTalking>(word);
            if (bookletOfTalking != null)
            {
                db.Entry(bookletOfTalking).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return Ok(bookletOfTalking);
        }
    }
}
