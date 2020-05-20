using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackApp.Areas.Admin.Models
{
    public class FeedbackAdminModel
    {
        public int FeedbackId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Course { get; set; }
        public string Opinion { get; set; }
        public DateTime FeedbackPlaced { get; set; }
    }
}
