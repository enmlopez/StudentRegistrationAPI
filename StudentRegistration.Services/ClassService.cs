using StudentRegistration.Data;
using StudentRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Services
{
    public class ClassService
    {
        public bool CreateClass (ClassCreate model)
        {
            var entity =
                new Class()
                {
                    Name = model.Name
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Class.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ClassListItems> GetClass()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Class
                        .Select(
                            e =>
                                new ClassListItems
                                {
                                    ClassId = e.ClassId,
                                    Name = e.Name,
                                    TeacherId=e.TeacherId,
                                    CourseId=e.CourseId
                                }
                        );
                return query.ToArray();
            }
        }
        public ClassDetail GetClassById(int id)
        {
            
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx.Class
                        .Single(e => e.ClassId == id);
                    return new ClassDetail()
                    {
                        ClassId = entity.ClassId,
                        Name = entity.Name,
                        TeacherId=entity.TeacherId,
                       CourseId = entity.CourseId,
                       //Course = new CourseListItems() { CourseId = entity.Course.CourseId, Title = entity.Course.Title },
                       //Teacher = new TeacherListItem() { TeacherId = entity.Teacher.TeacherId, FirstName = entity.Teacher.FirstName, LastName = entity.Teacher.LastName },

                    };
                }
            }
        public bool UpdateNote(ClassEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Class
                        .Single(e => e.ClassId == model.ClassId);

                entity.Name = model.Name;
                entity.TeacherId = model.TeacherId;
                entity.CourseId = model.CourseId;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteClass(int noteId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Class
                        .Single(e => e.ClassId == noteId);

                ctx.Class.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
