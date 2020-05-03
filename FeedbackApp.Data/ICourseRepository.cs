using System;
using System.Collections.Generic;
using FeedbackApp.Domain.Entities;
using FeedbackApp.Domain;

namespace FeedbackApp.Data
{
    public interface ICourseRepository
    {
        IEnumerable<Course> AllCourses { get; }
        Course GetCourseById(int courseId);
    }
}