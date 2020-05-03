using System;
using System.Collections.Generic;
using System.Text;
using FeedbackApp.Domain.Entities;

namespace FeedbackApp.Data
{
    public interface ITeacherRepository
    {
        IEnumerable<Teacher> AllTeachers { get; }
    }
}
