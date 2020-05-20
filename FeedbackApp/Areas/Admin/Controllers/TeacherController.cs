using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FeedbackApp.Areas.Admin.Models;
using FeedbackApp.Data;
using FeedbackApp.Domain.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace FeedbackApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeacherController : Controller
    {
        private readonly ITeacherRepository _teacherRepository; 
        private readonly IMapper _mapper;

        public TeacherController(ITeacherRepository teacherRepository, IMapper mapper)
        {
            _teacherRepository = teacherRepository;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var teacherListFromDb = _teacherRepository.GetTeachers();
            var model = _mapper.Map<IEnumerable<TeacherAdminModel>>(teacherListFromDb);
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost, ActionName("Create")]
        public IActionResult Create(TeacherAdminModel teacherAdminModel)
        {
            if (ModelState.IsValid)
            {
                var teacher = _mapper.Map<Teacher>(teacherAdminModel);
                _teacherRepository.CreateTeacher(teacher);
                return RedirectToAction(nameof(Index));
            }
            return View(teacherAdminModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var teacher = _teacherRepository.GetTeacherById(id);
            if (teacher == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<TeacherAdminModel>(teacher);
            return View(model);
        }

        [HttpPost, ActionName("Edit")]
        public async Task<IActionResult> EditTeacher(int id)
        {
            var teacherToUpdate = _teacherRepository.GetTeacherById(id);
            bool isUpdated = await TryUpdateModelAsync<Teacher>(
                teacherToUpdate,
                "",
                c => c.TeacherId,
                c => c.FirstName,
                c => c.LastName,
                c => c.Description);
            if (isUpdated == true)
            {
                _teacherRepository.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(teacherToUpdate);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var teacher = _teacherRepository.GetTeacherById(id);
            if (teacher == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<TeacherAdminModel>(teacher);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _teacherRepository.DeleteTeacher(id);
            return RedirectToAction(nameof(Index));
        }
    }
}