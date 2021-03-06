using StudentRegistration.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Models
{
    public class ClassDetail
    {
        public int ClassId { get; set; }
        public string Name { get; set; }
        public virtual TeacherClassDetail Teacher { get; set; }
        public virtual CourseClassDetail Course { get; set; }
        public virtual StudentClassDetail Student { get; set; }
        public virtual DepartmentClassDetail Department { get; set; }
    }
}
