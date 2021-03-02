using StudentRegistration.Data;
using StudentRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace StudentRegistration.Services
{
    public class TeacherService
    {
        public bool CreateTeacher(TeacherCreate model)
        {
            var entity =
                new Teacher()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    CourseId = model.CourseId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Teachers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<TeacherListItem> GetTeachers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Teachers
                    .Select(
                        e =>
                        new TeacherListItem
                        {
                            TeacherId = e.TeacherId,
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                            CourseId = e.CourseId,
                            CourseName = e.Course.Title
                        });
                return query.ToArray();
            }
        }
        public TeacherDetail GetTeacherById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Teachers
                    .SingleOrDefault(e => e.TeacherId == id);
                if (entity != null)
                {
                    return new TeacherDetail()
                    {
                        TeacherId = entity.TeacherId,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        Course = new CourseListItems() { CourseId = entity.Course.CourseId, Title = entity.Course.Title }
                    };
                }
                return null;
            }
        }
        public Teacher UpdateTeacher(TeacherUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Teachers
                    .SingleOrDefault(e => e.TeacherId == model.TeacherId);

                if (entity != null)
                {
                    entity.FirstName = model.FirstName;
                    entity.LastName = model.LastName;
                    entity.CourseId = model.CourseId;

                    ctx.SaveChanges();
                }
                return null;
            }
        }
        public bool DeleteTeacher(int teacherId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Teachers
                    .SingleOrDefault(e => e.TeacherId == teacherId);

                if (entity != null)
                {
                    ctx.Teachers.Remove(entity);

                    return ctx.SaveChanges() == 1;
                }
                return false;
            }
        }
    }

}
