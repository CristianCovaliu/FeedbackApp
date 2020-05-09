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
            var teacherListFromDb = _teacherRepository.GetTeachers();
            //var model = new List<CourseListViewModel>();
            //foreach (var course in courseListFromDb)
            //{
            //    var courseModelItem = new CourseListViewModel();
            //    courseModelItem.CourseId = course.CourseId;
            //    courseModelItem.ImageUrl = course.ImageUrl;
            //    courseModelItem.Title = course.Title;
            //    courseModelItem.Price = course.Price;
            //    courseModelItem.Teacher.FirstName = course.Teacher.FirstName;
            //    courseModelItem.Teacher.LastName = course.Teacher.LastName;
            //    model.Add(courseModelItem);
            //}
            
            var model = _mapper.Map<IEnumerable<CourseListViewModel>>(courseListFromDb);

            return View(model);
        }

        public IActionResult Details(int id)
        {
            var course = _courseRepository.GetCourseById(id);
            //var teacher = _teacherRepository.GetTeachers();
            if (course == null)
            {
                return NotFound();
            }
            //var model = new CourseModel();
            //model.Title = course.Title;
            //model.ImageUrl = course.ImageUrl;
            //model.LongDescription = course.LongDescription;
            //model.Price = course.Price;
            //model.ShortDescription = course.ShortDescription;
            //model.Teacher.FirstName = course.Teacher.FirstName;
            //model.Teacher.LastName = course.Teacher.LastName;

            var model = _mapper.Map<CourseModel>(course);
            return View(model);
        }
    }
}
