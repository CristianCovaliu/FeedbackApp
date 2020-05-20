using System;
using System.Collections.Generic;
using System.Text;
using FeedbackApp.Domain.Entities;

namespace FeedbackApp.Data
{
    public interface ITeacherRepository
    {
        List<Teacher> GetTeachers();
        Teacher GetTeacherById(int teacherId);
        void CreateTeacher(Teacher teacher);
        void DeleteTeacher(int id);
        void SaveChanges();
        IEnumerable<Teacher> AllTeachers { get; }
    }
}
