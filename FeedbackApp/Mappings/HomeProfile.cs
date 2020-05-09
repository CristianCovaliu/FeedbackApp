using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FeedbackApp.Domain.Entities;
using FeedbackApp.ViewModels;

namespace FeedbackApp.Mappings
{
    public class HomeProfile: Profile
    {
        public HomeProfile()
        {
            CreateMap<Course, HomeViewModel>();
        }
    }
}
