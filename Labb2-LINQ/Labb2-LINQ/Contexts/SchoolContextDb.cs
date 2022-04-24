using Labb2_LINQ.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Labb2_LINQ.Contexts
{
    public class SchoolContextDb : DbContext
    {

        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Course_Students> Course_Students{ get; set; }
        public DbSet<Course_Teachers> Course_Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=msi\sqlexpress;Initial Catalog=SchoolDB;Integrated Security=True;Pooling=False");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course_Students>()
              .HasKey(cs => new { cs.CourseId, cs.StudentId });

            modelBuilder.Entity<Course_Students>()
              .HasOne(cs => cs.Students)
              .WithMany(s => s.Course_Students)
              .HasForeignKey(cs => cs.StudentId);

            modelBuilder.Entity<Course_Students>()
               .HasOne(cs => cs.Courses)
               .WithMany(c => c.Course_Students)
               .HasForeignKey(cs => cs.StudentId);


            modelBuilder.Entity<Class>()
                .HasMany(x => x.Students)
                .WithOne()
                .HasForeignKey("ClassId");
                

            modelBuilder.Entity<Course_Teachers>()
              .HasKey(cs => new { cs.CourseId, cs.TeacherId });

            modelBuilder.Entity<Course_Teachers>()
              .HasOne(cs => cs.Teachers)
              .WithMany(s => s.Course_Teachers)
              .HasForeignKey(cs => cs.TeacherId);

            modelBuilder.Entity<Course_Teachers>()
               .HasOne(cs => cs.Courses)
               .WithMany(c => c.Course_Teachers)
               .HasForeignKey(cs => cs.TeacherId);

        }
    }
}
