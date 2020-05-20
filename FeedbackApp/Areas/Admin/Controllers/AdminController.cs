using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FeedbackApp.Areas.Admin.Models;
using FeedbackApp.Data;
using FeedbackApp.Domain.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FeedbackApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IWebHostEnvironment _environment;
        private readonly IMapper _mapper;

        public AdminController(ICourseRepository courseRepository, ITeacherRepository teacherRepository, IMapper mapper, IWebHostEnvironment environment)
        {
            _courseRepository = courseRepository;
            _teacherRepository = teacherRepository;
            _environment = environment;
            _mapper = mapper;
        }
        
        public IActionResult Index()
        {
            var courseListFromDb = _courseRepository.GetAllCourses();
            var teacherListFromDb = _teacherRepository.GetTeachers();

            var model = _mapper.Map<IEnumerable<CourseAdminModel>>(courseListFromDb);

            return View(model);
        }
       
        public  IActionResult CourseDetails(int id)
        {
            var course = _courseRepository.GetCourseById(id);
            if (course == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<CourseAdminModel>(course);
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            PopulateTeachersDropDownList();
            return View();
        }


        [HttpPost, ActionName("Create")]
        public IActionResult Create(CourseAdminModel courseAdminModel)
        {
            if (ModelState.IsValid)
            {
                var course = _mapper.Map<Course>(courseAdminModel);
                _courseRepository.CreateCourse(course);
                return RedirectToAction(nameof(Index));
            }
            PopulateTeachersDropDownList(courseAdminModel.TeacherId);
            return View(courseAdminModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var course = _courseRepository.GetCourseById(id);
            if (course == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<CourseAdminModel>(course);
            PopulateTeachersDropDownList();
            return View(model);
        }

        [HttpPost, ActionName("Edit")]
        public async Task<IActionResult> EditCourse(int id)
        {
            var courseToUpdate = _courseRepository.GetCourseById(id);
            bool isUpdated = await TryUpdateModelAsync<Course>(
                courseToUpdate,
                "",
                c => c.CourseId,
                c => c.Title,
                c => c.TeacherId,
                c => c.ShortDescription,
                c => c.LongDescription,
                c => c.Price);
            if (isUpdated == true)
            {
                _courseRepository.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            PopulateTeachersDropDownList(courseToUpdate.TeacherId);
            return View(courseToUpdate);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var course = _courseRepository.GetCourseById(id);
            if (course == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<CourseAdminModel>(course);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _courseRepository.DeleteCourse(id);
            return RedirectToAction(nameof(Index));
        }
        private void PopulateTeachersDropDownList(int? selectTeacher = null)
        {
            var teachears = _courseRepository.PopulateTeachersDropDownList();
            ViewBag.TeacherId = new SelectList(teachears.AsNoTracking(), "TeacherId", "FirstName", selectTeacher);
        }

        public IActionResult GetImage(int id)
        {
            Course requestedCourse = _courseRepository.GetCourseById(id);
            if (requestedCourse != null)
            {
                string webRootpath = _environment.WebRootPath;
                string folderPath = "\\images\\";
                string fullPath = webRootpath + folderPath + requestedCourse.ImageName;
                if (System.IO.File.Exists(fullPath))
                {
                    FileStream fileOnDisk = new FileStream(fullPath, FileMode.Open);
                    byte[] fileBytes;
                    using (BinaryReader br = new BinaryReader(fileOnDisk))
                    {
                        fileBytes = br.ReadBytes((int)fileOnDisk.Length);
                    }
                    return File(fileBytes, requestedCourse.ImageMimeType);
                }
                else
                {
                    if (requestedCourse.PhotoFile.Length > 0)
                    {
                        return File(requestedCourse.PhotoFile, requestedCourse.ImageMimeType);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
            else
            {
                return NotFound();
            }
        }
    }
}