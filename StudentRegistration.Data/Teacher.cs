using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Data
{
    public class Teacher
    {
        [ForeignKey(nameof(Course))]
        public int? CourseId { get; set; }
        public virtual Course Course { get; set; }
    }
}
