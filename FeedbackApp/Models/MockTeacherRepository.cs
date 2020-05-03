using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackApp.Models
{
    public class MockTeacherRepository: ITeacherRepository
    {
        public IEnumerable<Teacher> AllTeachers =>
            new List<Teacher>
            {
                new Teacher{TeacherId=1, FirstName="Adrian", LastName="Popescu", Description="Lorem ipsum"},
                new Teacher{TeacherId=2, FirstName="Alin", LastName="Filipescu", Description="Lorem ipsum"},
                new Teacher{TeacherId=3, FirstName="Ana", LastName="Radulescu", Description="Lorem ipsum"}
            };
    }
}
