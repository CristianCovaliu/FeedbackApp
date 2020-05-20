using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FeedbackApp.Areas.Admin.Models;
using FeedbackApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace FeedbackApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeedbackController : Controller
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IMapper _mapper;

        public FeedbackController(IFeedbackRepository feedbackRepository, IMapper mapper)
        {
            _feedbackRepository = feedbackRepository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var feedbackListFromDb = _feedbackRepository.GetAllFeedbacks();
            var model = _mapper.Map<IEnumerable<FeedbackAdminModel>>(feedbackListFromDb);
            return View(model);
        }
    }
}