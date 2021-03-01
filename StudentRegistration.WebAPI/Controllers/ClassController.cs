﻿using Microsoft.AspNet.Identity;
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
        public IHttpActionResult Post(ClassCreate cla)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateClassService();

            if (!service.CreateClass(cla))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Get(int id)
        {
            ClassService classService = CreateClassService();
            var cla = classService.GetClassById(id);
            return Ok(cla);
        }
        public IHttpActionResult Put(ClassEdit cla)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateClassService();

            if (!service.UpdateNote(cla))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateClassService();

            if (!service.DeleteClass(id))
                return InternalServerError();

            return Ok();
        }
        private ClassService CreateClassService()
        {
            //var userId = Guid.Parse(User.Identity.GetUserId());
            var classService = new ClassService();
            return classService;
        }
    }
}
