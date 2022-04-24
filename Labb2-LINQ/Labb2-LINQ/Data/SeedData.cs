using Labb2_LINQ.Contexts;
using Labb2_LINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labb2_LINQ.Data
{
    public class SeedData
    {
        public static void Initialize()
        {
            using SchoolContextDb myContext = new SchoolContextDb();
            {

                if (!myContext.Classes.Any())
                {
                    myContext.Classes.AddRange(new List<Class>()
                    {
                        new Class(){ ClassName = "Systemutvecklare .NET"},
                        new Class(){ ClassName = "Databasutvecklare"},
                        new Class(){ ClassName = "Javautvecklare"},
                    });

                    myContext.SaveChanges();
                }

                //Studenter
                if (!myContext.Students.Any())
                {
                    myContext.Students.AddRange(new List<Student>()
                    {
                        new Student(){ FullName = "Rasmus Ekbom", ClassId = 1},
                        new Student(){ FullName = "Fredrik Olsson", ClassId = 1},
                        new Student(){ FullName = "Anitra Ngoensuwan", ClassId = 1},
                        new Student(){ FullName = "Daniel Ekbom", ClassId = 1},

                        new Student(){ FullName = "Weerayut Groth", ClassId = 2},
                        new Student(){ FullName = "Kim Tikkanen", ClassId = 2},
                        new Student(){ FullName = "Albin Andersson", ClassId = 2},
                        new Student(){ FullName = "Fredrik Svedin", ClassId = 2},

                        new Student(){ FullName = "Jan Jansson", ClassId = 3},
                        new Student(){ FullName = "Per Persson", ClassId = 3},
                        new Student(){ FullName = "Karl Karlsson", ClassId = 3},
                        new Student(){ FullName = "Ragnar Ragnarasson", ClassId = 3}
                    });

                    myContext.SaveChanges();
                }

                if (!myContext.Teachers.Any())
                {
                    myContext.Teachers.AddRange(new List<Teacher>()
                    {
                        new Teacher() { FullName = "Anas Alhussain" },
                        new Teacher() { FullName = "Reidar Nilsen" },
                        new Teacher() { FullName = "Tobias Landén" },
                    });
                    myContext.SaveChanges();
                }

                if (!myContext.Courses.Any())
                {
                    myContext.Courses.AddRange(new List<Course>()
                    {
                        new Course() { CourseName = "Agile Methods"},
                        new Course() { CourseName = "Frontend HTML & CSS"},
                        new Course() { CourseName = "Programming One"},
                        new Course() { CourseName = "Programming Two"},
                        new Course() { CourseName = "OOP"},
                        new Course() { CourseName = "Databases and SQL"},
                        new Course() { CourseName = "Design patterns and Architectures"},
                    });
                    myContext.SaveChanges();
                }

                if (!myContext.Course_Students.Any())
                {
                    myContext.Course_Students.AddRange(new List<Course_Students>()
                    {
                        new Course_Students() { StudentId = 1, CourseId = 1},
                        new Course_Students() { StudentId = 1, CourseId = 2},
                        new Course_Students() { StudentId = 1, CourseId = 3},
                        new Course_Students() { StudentId = 2, CourseId = 2},
                        new Course_Students() { StudentId = 2, CourseId = 3},
                        new Course_Students() { StudentId = 3, CourseId = 1},
                        new Course_Students() { StudentId = 3, CourseId = 2},
                        new Course_Students() { StudentId = 4, CourseId = 4},
                        new Course_Students() { StudentId = 4, CourseId = 5},
                        new Course_Students() { StudentId = 5, CourseId = 6},
                        new Course_Students() { StudentId = 5, CourseId = 3},
                        //new Course_Students() { StudentId = 6, CourseId = 4},
                        //new Course_Students() { StudentId = 6, CourseId = 5},
                        //new Course_Students() { StudentId = 7, CourseId = 6},
                        //new Course_Students() { StudentId = 7, CourseId = 4},
                        //new Course_Students() { StudentId = 8, CourseId = 3},
                        //new Course_Students() { StudentId = 8, CourseId = 5},
                        //new Course_Students() { StudentId = 9, CourseId = 3},
                        //new Course_Students() { StudentId = 9, CourseId = 1},
                        //new Course_Students() { StudentId = 10, CourseId = 2},
                        //new Course_Students() { StudentId = 10, CourseId = 3},
                        //new Course_Students() { StudentId = 11, CourseId = 4},
                        //new Course_Students() { StudentId = 12, CourseId = 5},
                        //new Course_Students() { StudentId = 11, CourseId = 6},
                        //new Course_Students() { StudentId = 12, CourseId = 7},
                        //new Course_Students() { StudentId = 12, CourseId = 1},
                    });
                    myContext.SaveChanges();
                }

                if (!myContext.Course_Teachers.Any())
                {
                    myContext.Course_Teachers.AddRange(new List<Course_Teachers>()
                    {
                        new Course_Teachers() { TeacherId = 1, CourseId = 1},
                        new Course_Teachers() { TeacherId = 2, CourseId = 2},
                        new Course_Teachers() { TeacherId = 3, CourseId = 3},
                        new Course_Teachers() { TeacherId = 3, CourseId = 4},
                        new Course_Teachers() { TeacherId = 1, CourseId = 5},
                        new Course_Teachers() { TeacherId = 2, CourseId = 6},
                        new Course_Teachers() { TeacherId = 3, CourseId = 7},
                        new Course_Teachers() { TeacherId = 1, CourseId = 2},
                    });
                    myContext.SaveChanges();
                }
               
                }

            }
        }
    }
