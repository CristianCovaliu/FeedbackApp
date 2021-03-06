﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace FeedbackApp.Domain.Entities
{
    public partial class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string ImageUrl { get; set; }
        public byte[] PhotoFile { get; set; }
        [NotMapped]
        public IFormFile PhotoAvatar { get; set; }
        public string ImageMimeType { get; set; }
        public string ImageName { get; set; }
        public decimal Price { get; set; }
        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
