using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FeedbackApp.Models
{
    public class FeedbackModel
    {
        [BindNever]
        public int FeedbackId { get; set; }

        [Required(ErrorMessage = "Please enter your first name")]
        [Display(Name = "First name")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name")]
        [Display(Name = "Last name")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter course")]
        [StringLength(50)]
        [Display(Name = "Course")]
        public string Course { get; set; }

        [Required(ErrorMessage = "Please enter your feedback")]
        [StringLength(1000)]
        [Display(Name = "Your feedback:")]
        public string Opinion { get; set; }
    }
}
