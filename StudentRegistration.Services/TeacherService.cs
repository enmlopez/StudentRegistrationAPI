using StudentRegistration.Data;
using StudentRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    LastName = model.LastName
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
                            LastName = e.LastName
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
                    .Single(e => e.TeacherId == id);
                return new TeacherDetail()
                {
                    TeacherId = entity.TeacherId,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName

                };
            }
        }

        public bool UpdateTeacher(TeacherUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Teachers
                    .Single(e => e.TeacherId == model.TeacherId);

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;

                return ctx.SaveChanges() == 1;
            }
        }
        
        public bool DeleteTeacher(int teacherId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Teachers
                    .Single(e => e.TeacherId == teacherId);

                ctx.Teachers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }

}
