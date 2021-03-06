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

        public IEnumerable<StudentListItem> GetStudents()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Users
                    .Select(
                        e =>
                        new StudentListItem
                        {
                            FistName = e.First,
                            LastName = e.Last,
                            Email = e.Email,
                            Year = e.Year,
                            Major = e.Major,
                        });
                return query.ToArray();
            }
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
                    Major = student.Major,
                    Class = student.Classes
                    .Select(e =>
                    new ClassStudentListItem
                    {
                        ClassId = e.ClassId,
                        Name = e.Name,
                        CourseId = e.CourseId,
                        TeacherId = e.TeacherId,
                        DepartmentId = e.DepartmentId
                    }).ToList()
                };
            }
        }

        public bool UpdateStudent(StudentUpdate model)
        {
            if (model is null)
                return false;

            using (var ctx = new ApplicationDbContext())
            {
                ApplicationUser student = ctx.Users.FirstOrDefault(x => x.StudentId == model.StudentId);

                student.First = model.FirstName;
                student.Last = model.LastName;
                student.Year = model.Year;
                student.Major = model.Major;

                return ctx.SaveChanges() >= 1;
            }
        }
    }

}
