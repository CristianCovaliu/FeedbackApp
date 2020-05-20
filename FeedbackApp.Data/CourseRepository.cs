using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using FeedbackApp.Domain;
using FeedbackApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FeedbackApp.Data
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _appDbContext;
        public CourseRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;                                     
        }

        public void CreateCourse(Course course)
        {
            if (course.PhotoAvatar !=null && course.PhotoAvatar.Length > 0)
            {
                course.ImageMimeType = course.PhotoAvatar.ContentType;
                course.ImageName = Path.GetFileName(course.PhotoAvatar.FileName);
                using (var memoryStream = new MemoryStream())
                {
                    course.PhotoAvatar.CopyTo(memoryStream);
                    course.PhotoFile = memoryStream.ToArray();
                }
                _appDbContext.Add(course);
                _appDbContext.SaveChanges();
            }
        }

        public void DeleteCourse(int id)
        {
            var course = _appDbContext.Courses.SingleOrDefault(c => c.CourseId == id);
            _appDbContext.Courses.Remove(course);
            _appDbContext.SaveChanges();
        }

        public List<Course> GetAllCourses()
        {
            return _appDbContext.Courses.ToList();
        }

        public Course GetCourseById(int courseId)
        {
            return _appDbContext.Courses.Include(t => t.Teacher).FirstOrDefault(c => c.CourseId == courseId);
        }

        public IQueryable<Teacher> PopulateTeachersDropDownList()
        {
            var teachersQuery = from b in _appDbContext.Teachers
                                orderby b.FirstName
                                select b;
            return teachersQuery;
        }

        public void SaveChanges()
        {
            _appDbContext.SaveChanges();
        }
    }
}
