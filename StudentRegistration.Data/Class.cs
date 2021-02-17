using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentRegistration.Data
{


    public class Class
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [ForeignKey(nameof(Teacher))]
        public int? TeacherId { get; set; }
        [ForeignKey(nameof(Student))]
        public int? StudentId { get; set; }
        [ForeignKey(nameof(Course))]
        public int? CourseId { get; set; }


    }
}