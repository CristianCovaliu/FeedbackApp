using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FeedbackApp.Models;
using FeedbackApp.Data;
using FeedbackApp.ViewModels;
using AutoMapper;

namespace FeedbackApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;
        public HomeController(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var courseListFromDb = _courseRepository.GetAllCourses(); 
            var homeViewModel = _mapper.Map<IEnumerable<HomeViewModel>>(courseListFromDb);
            return View(homeViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
