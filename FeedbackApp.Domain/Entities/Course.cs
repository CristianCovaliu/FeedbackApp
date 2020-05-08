using System;
using System.Collections.Generic;
using System.Text;

namespace FeedbackApp.Domain.Entities
{
    public partial class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
