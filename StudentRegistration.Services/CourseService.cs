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
        private readonly Guid _userId;

        public CourseService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateCourse(CourseCreate model)
        {
            var entity =
                new Course()
                {
                    OwnerId = _userId,
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
                        .Where(e => e.OwnerId == _userId)
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
        public CourseDetail GetCourseeById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Course
                        .Single(e => e.CourseId == id && e.OwnerId == _userId);
                return
                    new CourseDetail
                    {
                        CourseId = entity.CourseId,
                        Title = entity.Title,
                        //TeacherId = entity.TeacherId,
                        //Teachers = new TeacherListItem() { TeacherId = entity.Teacher., Name = entity.Category.Name }
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
                        .Single(e => e.CourseId == model.CourseId && e.OwnerId == _userId);

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
                        .Single(e => e.CourseId == Id && e.OwnerId == _userId);

                ctx.Course.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
