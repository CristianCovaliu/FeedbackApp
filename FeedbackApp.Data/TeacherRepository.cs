using System;
using System.Collections.Generic;
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
    }
}
