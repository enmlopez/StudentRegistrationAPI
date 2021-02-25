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
        public IHttpActionResult Post (TeacherCreate teacher)
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

        [HttpGet]
        public IHttpActionResult GetTeacherId(int teacherId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var teacher = _teacherService.GetTeacherById(teacherId);
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

        [HttpDelete]
        public IHttpActionResult DeleteTeacher(int teacherId)
        {
            if (!_teacherService.DeleteTeacher(teacherId))
            {
                return InternalServerError();
            }
            return Ok();
        }
        //test ignore comment
    }
}
