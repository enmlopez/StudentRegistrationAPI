using StudentRegistration.Data;
using StudentRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Services
{
    public class CourseService
    {
       // private readonly Guid _userId;

        //public CourseService(Guid userId)
        //{
        //    _userId = userId;
        //}
        public bool CreateCourse(CourseCreate model)
        {
            var entity =
                new Course()
                {
                    
                    Title = model.Title

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Course.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CourseListItems> GetCourse()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Course
                       
                        .Select(
                            e =>
                                new CourseListItems
                                {
                                    CourseId = e.CourseId,
                                    Title = e.Title
                                }
                        );
                return query.ToArray();
            }
        }
        public CourseDetail GetCoursById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Course
                        .Single(e => e.CourseId == id );
                return
                    new CourseDetail
                    {
                        CourseId = entity.CourseId,
                        Title = entity.Title,
                        Teachers = entity.Teachers
                        .Select(e =>
                        new TeacherListItem
                        {
                            TeacherId = e.TeacherId,
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                            CourseId = e.CourseId,
                            CourseName = e.Course.Title
                        }).ToList()
                    };
            }
        }
        public bool UpdateCourse(CourseEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Course
                        .Single(e => e.CourseId == model.CourseId );

                entity.Title = model.Title;


                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteCourse(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Course
                        .Single(e => e.CourseId == Id);

                ctx.Course.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
