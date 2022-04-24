using System;
using System.Collections.Generic;
using System.Text;

namespace Labb2_LINQ.Models
{
    public class Course_Teachers
    {
        public int CourseId { get; set; }
        public Course Courses { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teachers { get; set; }
    }
}
