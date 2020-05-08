using System;
using System.Collections.Generic;
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

        public List<Course> GetAllCourses()
        {
            return _appDbContext.Courses.ToList();
        }

        public Course GetCourseById(int courseId)
        {
            return _appDbContext.Courses.Include(t => t.Teacher).FirstOrDefault(c => c.CourseId == courseId);
        }
    }
}
