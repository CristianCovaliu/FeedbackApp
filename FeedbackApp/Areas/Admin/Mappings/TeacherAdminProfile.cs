﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FeedbackApp.Areas.Admin.Models;
using FeedbackApp.Domain.Entities;

namespace FeedbackApp.Areas.Admin.Mappings
{
    public class TeacherAdminProfile : Profile
    {
        public TeacherAdminProfile()
        {
            CreateMap<Teacher, TeacherAdminModel>();
            CreateMap<TeacherAdminModel, Teacher>();
        }
    }
}
