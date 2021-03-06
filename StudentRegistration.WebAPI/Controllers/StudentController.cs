using Microsoft.AspNet.Identity;
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
    [Authorize]
    public class StudentController : ApiController
    {
        [Route ("api/Student/{studentId}")]
        [HttpGet]
        public IHttpActionResult GetStudentById(int studentId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var student = CreateStudentService().GetStudentById(studentId);

            if (student != null)
                return Ok(student);
            else
                return BadRequest("Could not find student");
        }

        [HttpGet]
        public IHttpActionResult GetAllStudents()
        {
            var students = CreateStudentService().GetStudents();
            return Ok(students);
        }

        [HttpPut]
        public IHttpActionResult UpdateStudent(StudentUpdate student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (! CreateStudentService().UpdateStudent(student))
            {
                return InternalServerError();
            }
            return Ok("Student updated");
        }

        private StudentService CreateStudentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var studentService = new StudentService(userId);
            return studentService;
        }
    }
}
