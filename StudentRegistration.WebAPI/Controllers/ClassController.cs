using Microsoft.AspNet.Identity;
using StudentRegistration.Models;
using StudentRegistration.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace StudentRegistration.WebAPI.Controllers
{
    public class ClassController:ApiController
    {
        //Erase if not working
        private ClassService _classService = new ClassService();

        [HttpPost]
        public IHttpActionResult Post(ClassCreate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (model == null)
            {
                return BadRequest("Are you putting all the class information correctly?  Model cannot be null.");
            }
            if (!_classService.CreateClass(model))
            {
                return InternalServerError();
            }
            return Ok();
        }
        [HttpGet]
        public IHttpActionResult Get()
        {
            var getClass = _classService.GetClass();
            return Ok(getClass);
        }
        [Route("api/Class/{classId}")]
        [HttpGet]
        public IHttpActionResult GetClassById(int classId)
        {
            var getClass = _classService.GetClassById(classId);
            return Ok(getClass);
        }
        [HttpPut]
        public IHttpActionResult UpdateClass(ClassEdit model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_classService.UpdateClass(model))
            {
                return InternalServerError();
            }
            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult DeleteClass (int classId)
        {
            if (!_classService.DeleteClass(classId))
            {
                return InternalServerError();
            }
            return Ok();
        }
        //Erase above if not working

        //[Authorize]
        //public IHttpActionResult Get()
        //{
        //    ClassService classService = CreateClassService();
        //    var classs = classService.GetClass();
        //    return Ok(classs);
        //}
        //public IHttpActionResult Post(ClassCreate note)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var service = CreateClassService();

        //    if (!service.CreateClass(note))
        //        return InternalServerError();

        //    return Ok();
        //}
        //public IHttpActionResult Get(int id)
        //{
        //    ClassService classService = CreateClassService();
        //    var cla = classService.GetClassById(id);
        //    return Ok(cla);
        //}
        //public IHttpActionResult Put(ClassEdit note)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var service = CreateClassService();

        //    if (!service.UpdateNote(note))
        //        return InternalServerError();

        //    return Ok();
        //}
        //public IHttpActionResult Delete(int id)
        //{
        //    var service = CreateClassService();

        //    if (!service.DeleteClass(id))
        //        return InternalServerError();

        //    return Ok();
        //}
        //private ClassService CreateClassService()
        //{
        //    //var userId = Guid.Parse(User.Identity.GetUserId());
        //    var noteService = new ClassService();
        //    return noteService;
        //}
    }
}
