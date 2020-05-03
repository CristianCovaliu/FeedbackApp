using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackApp.Models
{
    public interface ITeacherRepository
    {
        IEnumerable<Teacher> AllTeachers{ get; }
    }
}
