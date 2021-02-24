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
        [Authorize]
        public IHttpActionResult Get()
        {
            ClassService classService = CreateClassService();
            var classs = classService.GetClass();
            return Ok(classs);
        }
        public IHttpActionResult Post(ClassCreate note)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateClassService();

            if (!service.CreateClass(note))
                return InternalServerError();

            return Ok();
        }
        private ClassService CreateClassService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var noteService = new ClassService(userId);
            return noteService;
        }
    }
}
