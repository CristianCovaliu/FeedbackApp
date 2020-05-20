using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FeedbackApp.Data;
using FeedbackApp.Domain.Entities;
using FeedbackApp.Models;
using Microsoft.AspNetCore.Mvc;



namespace FeedbackApp.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IMapper _mapper;
        public FeedbackController(IFeedbackRepository feedbackRepository, IMapper mapper)
        {
            _feedbackRepository = feedbackRepository;
            _mapper = mapper;
        }
        public IActionResult Feedback()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Feedback(FeedbackModel feedbackModel)
        {
            if (ModelState.IsValid)
            {
                var feedback = _mapper.Map<Feedback>(feedbackModel);
                _feedbackRepository.CreateFeedback(feedback);
                return RedirectToAction("FeedbackSubmitted");
            }
            return View(feedbackModel);
        }

        public IActionResult FeedbackSubmitted()
        {
            ViewBag.FeedbackSubmittedMessage = "Thanks for your feedback!";
            return View();
        }
    }
}
