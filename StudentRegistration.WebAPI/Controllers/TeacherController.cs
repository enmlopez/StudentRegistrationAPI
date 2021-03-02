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

            if (teacher is null)
            {
                return BadRequest($"ID #{teacherId} not found in database.");
            }
            return Ok(teacher);
        }

        [HttpPut]
        public IHttpActionResult UpdateTeacher([FromBody]TeacherUpdate teacher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (_teacherService.UpdateTeacher(teacher) is null)
            {
                return BadRequest($"ID #{teacher.TeacherId} does not exist in the database.");
            }
            return Ok();
        }

        [Route("api/Teacher/{teacherId}")]
        [HttpDelete]
        public IHttpActionResult DeleteTeacher([FromUri]int teacherId)
        {
            if (!_teacherService.DeleteTeacher(teacherId))
            {
                return BadRequest($"ID #{teacherId} does not exist.  Cannot Delete");
            }
            return Ok();
        }
    }
}
