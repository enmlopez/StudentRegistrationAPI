using StudentRegistration.Data;
using StudentRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace StudentRegistration.Services
{
    public class StudentService
    {
        private readonly Guid _userId;

        public StudentService(Guid userId)
        {
            _userId = userId;
        }

        public StudentDetail GetStudentById(int studentid)
        {
            using (var ctx = new ApplicationDbContext())
            {

                ApplicationUser student = ctx.Users.FirstOrDefault(x => x.StudentId == studentid);

                return new StudentDetail()
                {
                    FistName = student.First,
                    LastName = student.Last,
                    Year = student.Year,
                    Major = student.Major

                };
            }

        }
    }

}
