using StudentRegistration.Data;
using StudentRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Services
{
    public class DepartmentService
    {
        public bool CreateDepartment(DepartmentCreate model)
        {
            var entity =
                new Department()
                {
                    Name = model.Name,
                    Building = model.Building
                    
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Departments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<DepartmentListItem> GetDepartments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Departments
                    .Select(
                        e =>
                        new DepartmentListItem
                        {
                            DepartmentId = e.DepartmentId,
                            Name = e.Name,
                            Building = e.Building
                            
                        });
                return query.ToArray();
            }
        }

        public DepartmentDetail GetDepartmentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Departments
                    .SingleOrDefault(e => e.DepartmentId == id);
                if (entity != null)
                {
                    return new DepartmentDetail()
                    {
                        DepartmentId = entity.DepartmentId,
                        Name = entity.Name,
                        Building = entity.Building
                       
                    };
                }
                return null;
            }
        }


        public bool UpdateDepartment(DepartmentUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Departments
                    .SingleOrDefault(e => e.DepartmentId == model.DepartmentId);

                if (entity != null)
                {
                    entity.Name = model.Name;
                    entity.Building = model.Building;
                    return ctx.SaveChanges() >= 1;
                }
                return false;
            }
        }

        public bool DeleteDepartment(int departmentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Departments
                    .SingleOrDefault(e => e.DepartmentId == departmentId);

                if (entity != null)
                {
                    ctx.Departments.Remove(entity);

                    return ctx.SaveChanges() == 1;
                }
                return false;
            }
        }


    }
}
