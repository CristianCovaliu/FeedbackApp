using System;
using System.Collections.Generic;
using System.Text;

namespace FeedbackApp.Domain.Entities
{
    public partial class Teacher
    {
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        
    }
}
