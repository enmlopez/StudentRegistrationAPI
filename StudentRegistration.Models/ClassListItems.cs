using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Models
{
    public class ClassListItems
    {
        public int ClassId { get; set; }
        public string Name { get; set; }
        public int? TeacherId { get; set; }
        public int? CourseId { get; set; }


    }
}
