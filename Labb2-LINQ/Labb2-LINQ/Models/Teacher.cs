using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Labb2_LINQ.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }
        public string FullName { get; set; }

        public ICollection<Course_Teachers> Course_Teachers { get; set; }
    }
}
