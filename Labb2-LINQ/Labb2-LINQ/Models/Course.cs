using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Labb2_LINQ.Models
{
    public class Course
    {

        public Course()
        {
        }

        [Key]
        public int CourseId { get; set; }
        public string CourseName { get; set; }

        public ICollection<Course_Students> Course_Students{ get; set; }
        public ICollection<Course_Teachers> Course_Teachers{ get; set; }
    }
}
