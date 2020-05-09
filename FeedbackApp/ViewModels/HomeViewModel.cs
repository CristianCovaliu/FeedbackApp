using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FeedbackApp.Domain.Entities;

namespace FeedbackApp.ViewModels
{
    public class HomeViewModel
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
    }
}
