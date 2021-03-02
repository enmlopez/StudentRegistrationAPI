using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentRegistration.Data
{
    public class Class
    {
        [Key]
        public int ClassId { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey(nameof(Teacher))]
        public int? TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }

        [ForeignKey(nameof(Course))]
        public int? CourseId { get; set; }
        public virtual Course Course { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        public string Id { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

    }

}
