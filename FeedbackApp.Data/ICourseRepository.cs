using System;
using System.Collections.Generic;
using FeedbackApp.Domain.Entities;
using FeedbackApp.Domain;

namespace FeedbackApp.Data
{
    public interface ICourseRepository
    {
        List<Course> GetAllCourses();
        Course GetCourseById(int courseId);
    }
}