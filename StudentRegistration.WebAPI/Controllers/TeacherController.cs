using StudentRegistration.Models;
using StudentRegistration.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentRegistration.WebAPI.Controllers
{
    public class TeacherController : ApiController
    {
        private TeacherService _teacherService = new TeacherService();

        [HttpPost]
        public IHttpActionResult Post(TeacherCreate teacher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_teacherService.CreateTeacher(teacher))
            {
                return InternalServerError();
            }
            return Ok();
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var teachers = _teacherService.GetTeachers();
            return Ok(teachers);
        }

        [Route("api/Teacher/{teacherId}")]
        [HttpGet]
        public IHttpActionResult GetTeacherId([FromUri] int teacherId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var teacher = _teacherService.GetTeacherById(teacherId);

            //if (teacher is null) // need to edit - if teacherId is not found rather than teacher
            //{
            //    throw new HttpResponseException(HttpStatusCode.NotFound);
            //}
            return Ok(teacher);
        }

        [HttpPut]
        public IHttpActionResult UpdateTeacher(TeacherUpdate teacher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_teacherService.UpdateTeacher(teacher))
            {
                return InternalServerError();
            }
            return Ok();
        }

        [Route("api/Teacher/{teacherId}")]
        [HttpDelete]
        public IHttpActionResult DeleteTeacher(int teacherId)
        {
            if (!_teacherService.DeleteTeacher(teacherId))
            {
                return InternalServerError();
            }
            return Ok();
        }
    }
}
