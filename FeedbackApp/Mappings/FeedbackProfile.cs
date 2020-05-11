using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FeedbackApp.Domain.Entities;
using FeedbackApp.Models;

namespace FeedbackApp.Mappings
{
    public class FeedbackProfile: Profile
    {
        public FeedbackProfile()
        {
            CreateMap<FeedbackModel, Feedback>();
        }
    }
}
