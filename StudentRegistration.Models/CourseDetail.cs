using StudentRegistration.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace StudentRegistration.Models
{
    public class CourseDetail
    {
        public int CourseId { get; set; }
        public string Title { get; set; }       
        public virtual List<TeacherListItem> Teachers { get; set; }
    }
}
