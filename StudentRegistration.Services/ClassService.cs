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
        public bool CreateClass(ClassCreate model)
        {
            var entity =
                new Class()
                {
                    Name = model.Name,
                    TeacherId = model.TeacherId,
                    CourseId = model.CourseId,
                    Id = model.StudentId,
                    DepartmentId = model.DepartmentId
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
                                    CourseId = e.CourseId,
                                    TeacherId = e.TeacherId,
                                    StudentId = e.ApplicationUser.StudentId,
                                    DepartmentId = e.DepartmentId
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
                    Teacher = new TeacherClassDetail() { TeacherId = entity.Teacher.TeacherId, FirstName = entity.Teacher.FirstName, LastName = entity.Teacher.LastName },
                    Course = new CourseClassDetail() { CourseId = entity.Course.CourseId, Title = entity.Course.Title },
                    Student = new StudentClassDetail() { FirstName = entity.ApplicationUser.First, LastName = entity.ApplicationUser.Last, StudentId = entity.ApplicationUser.Id },
                    Department = new DepartmentClassDetail() { DepartmentId=entity.Department.DepartmentId,Name = entity.Department.Name,Building = entity.Department.Building}
                };
            }
        }
        public bool UpdateClass(ClassEdit model)
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
                entity.Id = model.StudentId;
                entity.DepartmentId = model.DepartmentId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteClass(int classId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Class
                        .Single(e => e.ClassId == classId);

                ctx.Class.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
