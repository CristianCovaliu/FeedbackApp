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

        public IEnumerable<Course> AllCourses
        {
            get
            {
                return _appDbContext.Courses.Include(c => c.Teacher);
            }
        }

        public Course GetCourseById(int courseId)
        {
            return _appDbContext.Courses.Include(t => t.Teacher).FirstOrDefault(c => c.CourseId == courseId);
        }
    }
}
