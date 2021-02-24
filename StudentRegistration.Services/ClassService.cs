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
        private readonly Guid _userId;

        public ClassService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateClass (ClassCreate model)
        {
            var entity =
                new Class()
                {
                   
                    Name = model.Name,
                   
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
                                    Name = e.Name
                                }
                        );
                return query.ToArray();
            }
        }
    }
}
