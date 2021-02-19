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
            CourseService noteService = CreateNoteService();
            var notes = noteService.GetNotes();
            return Ok(notes);
        }
        public IHttpActionResult Post(CourseCreate note)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateNoteService();

            if (!service.CreateCourse(note))
                return InternalServerError();

            return Ok();
        }

        private CourseService CreateNoteService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var noteService = new CourseService(userId);
            return noteService;
        }
    }
}