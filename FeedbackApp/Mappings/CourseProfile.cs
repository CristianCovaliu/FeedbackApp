using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FeedbackApp.Domain.Entities;
using FeedbackApp.ViewModels;

namespace FeedbackApp.Mappings
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseListViewModel>();
        }
    }
}
