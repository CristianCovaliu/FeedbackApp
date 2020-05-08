using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FeedbackApp.Data;
using FeedbackApp.Domain;
using FeedbackApp.Models;
using FeedbackApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FeedbackApp.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IMapper _mapper;

        public CourseController(ICourseRepository courseRepository, ITeacherRepository teacherRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _teacherRepository = teacherRepository;
            _mapper = mapper;
        }

        public IActionResult List()
        {
            var courseListFromDb = _courseRepository.GetAllCourses();
            var model = _mapper.Map<IEnumerable<CourseListViewModel>>(courseListFromDb);
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var course = _courseRepository.GetCourseById(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }
    }
}
