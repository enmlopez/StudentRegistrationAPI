using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Models
{
    public class StudentUpdate
    {

        public int StudentId { get; set; }
        public string FistName { get; set; }
        public string LastName { get; set; }
        public string Year { get; set; }
        public string Major { get; set; }
    }
}
