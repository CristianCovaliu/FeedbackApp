using System;
using System.Collections.Generic;
using System.Text;
using FeedbackApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FeedbackApp.Domain
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed teachers

            modelBuilder.Entity<Teacher>().HasData(new Teacher { TeacherId = 1, FirstName = "Adriana", LastName = "Radulescu", Description = "Lorem ipsum" });
            modelBuilder.Entity<Teacher>().HasData(new Teacher { TeacherId = 2, FirstName = "Ioana", LastName = "Popescu", Description = "Lorem ipsum" });
            modelBuilder.Entity<Teacher>().HasData(new Teacher { TeacherId = 3, FirstName = "Georgiana", LastName = "Timofte", Description = "Lorem ipsum" });

            //seed pies

            modelBuilder.Entity<Course>().HasData(new Course
            {
                CourseId = 1,
                Title = "English Course",
                Price = 200.00M,
                ImageUrl = "/images/englishCourse.jpg",
                TeacherId = 1,
                ShortDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                LongDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam in mi erat. Nam id dui vel felis imperdiet posuere."
            });

            modelBuilder.Entity<Course>().HasData(new Course
            {
                CourseId = 2,
                Title = "French Course",
                Price = 250.00M,
                ImageUrl = "/images/frenchCourse.jpg",
                TeacherId = 2,
                ShortDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                LongDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam in mi erat. Nam id dui vel felis imperdiet posuere."
            });

            modelBuilder.Entity<Course>().HasData(new Course
            {
                CourseId = 3,
                Title = "Italian Course",
                Price = 250.00M,
                ImageUrl = "/images/italianCourse.jpg",
                TeacherId = 3,
                ShortDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                LongDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam in mi erat. Nam id dui vel felis imperdiet posuere."
            });
        }
    }
}
