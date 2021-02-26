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
        public int? TeacherId { get; set; }
        public virtual TeacherListItem Teacher { get; set; }
        public int? CourseId { get; set; }
        public virtual Course Course { get; set; }
        //public virtual CourseListItems Course { get; set; }
        //public virtual List<Teacher> Teachers { get; set; }
        //public virtual List<Student> Students { get; set; }
    }
}
