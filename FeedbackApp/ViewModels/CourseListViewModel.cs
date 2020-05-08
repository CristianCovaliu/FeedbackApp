using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FeedbackApp.Models;

namespace FeedbackApp.ViewModels
{
    public class CourseListViewModel
    {
        public int CourseId { get; set; }
        public string Title { get; set;}
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public Teacher Teacher { get; set; }
    }
}
