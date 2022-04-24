using System;
using System.Collections.Generic;
using System.Text;

namespace Labb2_LINQ.Models
{
    public class Course_Students
    {
        public int CourseId { get; set; }
        public Course Courses { get; set; }
        public int StudentId { get; set; }
        public Student Students { get; set; }

    }
}
