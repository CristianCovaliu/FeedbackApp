using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FeedbackApp.Domain;
using FeedbackApp.Domain.Entities;

namespace FeedbackApp.Data
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly AppDbContext _appDbContext;
        public TeacherRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Teacher> AllTeachers => _appDbContext.Teachers;

        public void CreateTeacher(Teacher teacher)
        {
            _appDbContext.Teachers.Add(teacher);
            _appDbContext.SaveChanges();
        }

        public void DeleteTeacher(int id)
        {
            var teacher = _appDbContext.Teachers.SingleOrDefault(c => c.TeacherId == id);
            _appDbContext.Teachers.Remove(teacher);
            _appDbContext.SaveChanges();
        }

        public Teacher GetTeacherById(int teacherId)
        {
            return _appDbContext.Teachers.FirstOrDefault(c => c.TeacherId == teacherId);
        }

        public List<Teacher> GetTeachers()
        {
            return _appDbContext.Teachers.ToList();
        }

        public void SaveChanges()
        {
            _appDbContext.SaveChanges();
        }
    }
}
