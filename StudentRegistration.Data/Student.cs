using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Data
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        public string Email { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Major { get; set; }
        [Required]
        public string Minor { get; set; }
        [Required]
        public int UnderGradYear { get; set; }
        [ForeignKey(nameof(Class))]
        public int? ClassId { get; set; }
        public virtual Class Class { get; set; }
    }
}
