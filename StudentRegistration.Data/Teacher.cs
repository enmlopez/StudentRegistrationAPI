using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
<<<<<<< HEAD
using System.ComponentModel.DataAnnotations.Schema;
=======

>>>>>>> ac25254b2a2594b4f04c9be66a3a5bf026d95916
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Data
{
    public class Teacher
    {
<<<<<<< HEAD
        [Key]
        public int TeacherId { get; set; }
        [ForeignKey(nameof(Course))]
        public int? CourseId { get; set; }
        public virtual Course Course { get; set; }
=======

        [Key]
        public int TeacherId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }


>>>>>>> ac25254b2a2594b4f04c9be66a3a5bf026d95916
    }
}
