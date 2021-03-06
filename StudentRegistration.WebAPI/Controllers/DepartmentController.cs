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
    public class DepartmentController : ApiController
    {
        private DepartmentService _departmentService = new DepartmentService();

        [HttpPost]
        public IHttpActionResult Post(DepartmentCreate teacher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_departmentService.CreateDepartment(teacher))
            {
                return InternalServerError();
            }
            return Ok("Department created.");
        }

        [HttpGet]
        public IHttpActionResult GetDepartments()
        {
            var teachers = _departmentService.GetDepartments();
            return Ok(teachers);
        }

        [Route("api/Department/{DepartmentId}")]
        [HttpGet]
        public IHttpActionResult GetDepartmentById([FromUri] int departmentId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var department = _departmentService.GetDepartmentById(departmentId);

            if (department is null)
            {
                return BadRequest($"ID #{departmentId} not found in database.");
            }
            return Ok(department);
        }

        [HttpPut]
        public IHttpActionResult UpdateDepartment([FromBody] DepartmentUpdate department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_departmentService.UpdateDepartment(department))
            {
                return BadRequest($"ID #{department.DepartmentId} does not exist in the database.");
            }
            return Ok("Department updated.");
        }

        [Route("api/Department/{departmentId}")]
        [HttpDelete]
        public IHttpActionResult DeleteTeacher([FromUri] int departmentId)
        {
            if (!_departmentService.DeleteDepartment(departmentId))
            {
                return BadRequest($"ID #{departmentId} does not exist.  Cannot Delete");
            }
            return Ok("Department deleted.");
        }



    }
}
