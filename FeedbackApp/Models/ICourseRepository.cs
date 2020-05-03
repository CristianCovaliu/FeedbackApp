using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackApp.Models
{
    public interface ICourseRepository
    {
        IEnumerable<Course> AllCourses { get; }
        Course GetCourseById(int courseId);
    }
}
