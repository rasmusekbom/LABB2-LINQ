using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Labb2_LINQ.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string FullName { get; set; }

        [ForeignKey("ClassId")]
        public int ClassId { get; set; }

        public ICollection<Course_Students> Course_Students { get; set; }

    }
}
