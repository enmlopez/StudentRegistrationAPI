using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Data
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
      //  [Required]
      //  public Guid OwnerId { get; set; }
        [Required]
        public string Title { get; set; }
        public virtual List<Teacher> Teachers { get; set; }
    }
}
