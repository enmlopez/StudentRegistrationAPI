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
        public IEnumerable<CourseListItems> GetNotes()
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
                                    Id = e.Id,
                                    Title = e.Title,
                                    
                                }
                        );

                return query.ToArray();
            }
        }

    }
}
