using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Models
{
    public class ClassEdit
    {
        public int ClassId { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string Name { get; set; }
        public int? TeacherId { get; set; }
        public int? CourseId { get; set; }
        public int? DepartmentId { get; set; }
        public string StudentId { get; set; }

    }
}
