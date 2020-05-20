using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using FeedbackApp.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace FeedbackApp.Areas.Admin.Models
{
    public class CourseAdminModel
    {
        
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string ImageUrl { get; set; }
        public byte[] PhotoFile { get; set; }
        [NotMapped]
        [Display(Name = "Course Picture:")]
        public IFormFile PhotoAvatar { get; set; }
        public string ImageMimeType { get; set; }
        public string ImageName { get; set; }
        public decimal Price { get; set; }
        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
