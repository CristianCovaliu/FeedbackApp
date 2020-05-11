using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FeedbackApp.Domain.Entities
{
    public partial class Feedback
    {
        [Key]
        public int FeedbackId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Course { get; set; }
        public string Opinion { get; set; }
        public DateTime FeedbackPlaced { get; set; }
    }
}
