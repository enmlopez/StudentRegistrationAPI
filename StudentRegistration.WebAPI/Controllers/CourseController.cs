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
    [Authorize]
    public class CourseController:ApiController
    {
        public IHttpActionResult Get()
        {
            CourseService courseService = CreateCourseService();
            var course = courseService.GetCourse();
            return Ok(course);
        }
        public IHttpActionResult Post(CourseCreate course)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCourseService();

            if (!service.CreateCourse(course))
                return InternalServerError();

            return Ok();
        }
        private CourseService CreateCourseService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var courseService = new CourseService(userId);
            return courseService;
        }

        public IHttpActionResult Get(int id)
        {
            CourseService courseService = CreateCourseService();
            var course = courseService.GetCourseeById(id);
            return Ok(course);
        }
        public IHttpActionResult Put(CourseEdit course)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCourseService();

            if (!service.UpdateCourse(course))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateCourseService();

            if (!service.DeleteCourse(id))
                return InternalServerError();

            return Ok();
        }

    }
}