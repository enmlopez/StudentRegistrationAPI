﻿using StudentRegistration.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Models
{
    public class DepartmentCreate
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Building { get; set; }
    }
}
