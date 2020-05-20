using System;
using System.Collections.Generic;
using FeedbackApp.Domain.Entities;
using FeedbackApp.Domain;
using System.Linq;

namespace FeedbackApp.Data
{
    public interface ICourseRepository
    {
        List<Course> GetAllCourses();
        Course GetCourseById(int courseId);
        void CreateCourse(Course course);
        void DeleteCourse(int id);
        void SaveChanges();
        IQueryable<Teacher> PopulateTeachersDropDownList();
    }
}