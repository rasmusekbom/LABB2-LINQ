using Labb2_LINQ.Contexts;
using Labb2_LINQ.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labb2_LINQ.Handlers
{
    public class AppHandler
    {
        public static void RunApp()
        {
            try
            {
                Console.WriteLine("Hello. Welcome to the --- School Database ---!" +
                "\nWhat would you like to do?" +
                "\n\n[1] See every teacher in the course Programming 1." +
                "\n[2] See every student and their teachers. " +
                "\n[3] See every student and their teacher in the course Programming 1." +
                "\n[4] Edit the coursename (Programming 2) to (Object Oriented Programming)" +
                "\n[5] Choose a student and change his teacher." +
                "\n[6] Print out all available courses." +
                "\n[7] Exit the application.\n");

                var userChoice = int.Parse(Console.ReadLine());

                switch (userChoice)
                {
                    case 1:
                        GetTeachersProOne();
                        break;
                    case 2:
                        GetStudents();
                        break;
                    case 3:
                        GetStudentsProOne();
                        break;
                    case 4:
                        UpdateCourseName();
                        break;
                    case 5:
                        UpdateTeacher();
                        break;
                    case 6:
                        GetCourses();
                        break;
                    case 7:
                        ExitApplication();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Wrong input. Please enter a valid number followed by Enter.");
                Console.ReadKey();
                Console.Clear();
                RunApp();
            }

        }

        //HÄMTAR ALLA LÄRARE I KURSEN PROGRAMMERING 1//
        public static void GetTeachersProOne()
        {
            try
            {
                using (var db = new SchoolContextDb())
                {
                    List<Course_Teachers> teachers = db.Course_Teachers.ToList();
                    var proOne = from a in db.Course_Teachers
                                 join b in db.Teachers
                                 on a.TeacherId equals b.TeacherId
                                 where a.CourseId == 2
                                 select new
                                 {
                                     TeacherName = b.FullName
                                 };


                    Console.WriteLine("\n\n------- Teachers currently teaching in the Course (Programming 1) -------\n");
                    foreach (var item in proOne)
                    {
                        Console.WriteLine($"Mr. {item.TeacherName}");
                    }
                }
                BackToMenu();
            }
            catch (Exception)
            {

                throw;
            }
        }

        //HÄMTAR OCH SKRIVER UT ALLA STUDENTER SAMT DERAS ID.
        public static void GetStudents()
        {
            try
            {
                using (var db = new SchoolContextDb())
                {
                    List<Student> students = db.Students.ToList();
                    foreach (Student s in students)
                    {
                        Console.WriteLine("Student Name: {0}\t| Id: {1}", s.FullName, s.StudentId);
                    }
                }
                //BackToMenu();
            }
            catch (Exception)
            {
                Console.WriteLine("No students exist in the database.");
                throw;
            }
        }

        //HÄMTAR OCH SKRIVER UT ALLA KURSER.
        public static void GetCourses()
        {
            try
            {
                using (var db = new SchoolContextDb())
                {
                    List<Course> courses = db.Courses.ToList();
                    foreach (Course c in courses)
                    {
                        Console.WriteLine("Course Name: {0}", c.CourseName);
                    }
                    Console.ReadLine();
                }
                BackToMenu();
            }
            catch (Exception)
            {
                Console.WriteLine("No courses exist in the database.");
                throw;
            }
        }

        //HÄMTAR OCH SKRIVER UT ALLA LÄRARE.
        public static void GetTeachers()
        {
            try
            {
                using (var db = new SchoolContextDb())
                {
                    List<Teacher> teachers = db.Teachers.ToList();
                    foreach (Teacher t in teachers)
                    {
                        Console.WriteLine("Teacher Name: {0} | Teacher Id: {1}", t.FullName, t.TeacherId);
                    }
                    Console.ReadLine();
                }
                BackToMenu();
            }
            catch (Exception)
            {
                Console.WriteLine("No courses exist in the database.");
                throw;
            }
        }

        //HÄMTAR ALLA ELEVER I KURSEN PROGRAMMERING 1 SAMT KURSENS LÄRARE//
        public static void GetStudentsProOne()
        {
            try
            {
                using (var db = new SchoolContextDb())
                {
                    var proOne = from a in db.Course_Students
                                 join b in db.Students
                                 on a.StudentId equals b.StudentId
                                 where a.CourseId == 2
                                 select new
                                 {
                                     StudentName = b.FullName
                                 };

                    var proOneTeacher = from a in db.Course_Teachers
                                        join b in db.Teachers
                                        on a.TeacherId equals b.TeacherId
                                        where a.CourseId == 2
                                        select new
                                        {
                                            TeacherName = b.FullName
                                        };

                    Console.WriteLine("\n\n--------- PROGRAMMING 1 ---------");

                    Console.WriteLine($"\n------- Teachers currently teaching in this course: -------\n");
                    foreach (var item in proOneTeacher)
                    {
                        Console.WriteLine($"{item.TeacherName}");

                    }

                    Console.WriteLine("\n------- Students currently studying in this course: -------\n");
                    foreach (var item in proOne)
                    {
                        Console.WriteLine($"{item.StudentName}");
                    }
                }
                BackToMenu();
            }
            catch (Exception)
            {
                RunApp();
                throw;
            }
        }

        public static void UpdateTeacher()
        {
            Console.Clear();
            Console.WriteLine("------ UPDATE TEACHER IN SPECIFIC COURSE ------");
            Console.WriteLine("First choose what student whose teacher you'd like to update.\n" +
                "Choose student by their ID-number.\n");

            GetStudents();

            var chosenStudent = int.Parse(Console.ReadLine());

            using (var db = new SchoolContextDb())
            {

                List<Course_Students> students = db.Course_Students.ToList();
                var courses = from a in db.Course_Students
                              join b in db.Courses
                              on a.CourseId equals b.CourseId
                              where a.StudentId == chosenStudent
                              select new
                              {
                                  CourseName = b.CourseName,
                                  CourseId = b.CourseId
                              };

                Console.Clear();
                Console.WriteLine("The chosen student is in the following courses: \n");
                foreach (var item in courses)
                {
                    Console.WriteLine($"Coursename: {item.CourseName} | Id: {item.CourseId}");
                }
                Console.WriteLine("\nIn which course would you like to update the teacher? Choose with the Id-number.");

                var chosenCourse = int.Parse(Console.ReadLine());

                var courseTeachers = from a in db.Course_Teachers
                                     join b in db.Teachers
                                     on a.TeacherId equals b.TeacherId
                                     where a.CourseId == chosenCourse
                                     select new
                                     {
                                         TeacherName = b.FullName,
                                         TeacherId = b.TeacherId
                                     };
                Console.WriteLine($"The current teacher/s in this course are: \n");
                foreach (var item in courseTeachers)
                {
                    Console.WriteLine($"{item.TeacherName} | Id: {item.TeacherId}");
                }
                Console.WriteLine("\nWhich teacher would you like to update to another teacher? Choose by the Id-number.");

                var oldTeacher = int.Parse(Console.ReadLine());

                var deleteOldTeacher = (from item in db.Course_Teachers where item.TeacherId == oldTeacher && item.CourseId == chosenCourse select item).First();

                if(deleteOldTeacher != null)
                {
                    db.Remove(deleteOldTeacher);
                    db.SaveChanges();
                }

                Console.WriteLine("\nAnd what teacher would you like to have instead? Choose by the Id-number.");

                List<Teacher> teachers = db.Teachers.ToList();
                foreach (Teacher t in teachers)
                {
                    Console.WriteLine("Teacher Name: {0} | Teacher Id: {1}", t.FullName, t.TeacherId);
                }

                var newTeacher = int.Parse(Console.ReadLine());

                db.Course_Teachers.Add(new Course_Teachers()
                {
                    
                    TeacherId = newTeacher, CourseId = chosenCourse
                });
                db.SaveChanges();
                Console.WriteLine("\nThe teacher have successfully been updated.");
                Console.WriteLine("Press any button to get back to main menu.");
                BackToMenu();

            }
            
        }
  
        public static void UpdateCourseName()
        {

            using (var db = new SchoolContextDb())
            {
                var updateCourseName = db.Courses
                .Where(course => course.CourseId == 4)
                .ToList();

                foreach (var item in updateCourseName)
                {
                    item.CourseName = "OOP";
                }

                db.SaveChanges();
            }

            Console.WriteLine("---- CHANGE COURSENAME ----");
            Console.WriteLine("\nThe name of the course Programming Two was successfully changed to Object Oriented Programming.");
            BackToMenu();
        }

        public static void BackToMenu()
        {
            Console.WriteLine("\n\nPress any button to go back to main menu.");
            Console.ReadKey();
            Console.Clear();
            RunApp();
        }

        public static void ExitApplication()
        {
            Environment.Exit(0);
        }
    }
}
