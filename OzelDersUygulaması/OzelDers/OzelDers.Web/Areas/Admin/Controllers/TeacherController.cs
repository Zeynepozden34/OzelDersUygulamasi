﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OzelDers.Business.Abstract;
using OzelDers.Core;
using OzelDers.Entity.Concrete;
using OzelDers.Entity.Concrete.Identity;
using OzelDers.Web.Areas.Admin.Models.Dtos;
using OzelDers.Web.Models;
using System;
using System.Numerics;
using System.Reflection;
using TeacherListDto = OzelDers.Web.Areas.Admin.Models.Dtos.TeacherListDto;

namespace OzelDers.Web.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class TeacherController : Controller
    {

        private readonly ITeacherService _teacherManager;
        private readonly IStudentService _studentManager;
        private readonly IBranchService _branchManager;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public TeacherController(ITeacherService teacherManager, IStudentService studentManager, IBranchService branchManager, UserManager<User> userManager = null, RoleManager<Role> roleManager = null)
        {
            _teacherManager = teacherManager;
            _studentManager = studentManager;
            _branchManager = branchManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            List<Teacher> teachers = await _teacherManager.GetTeacherWithAll();
            List<TeacherListDto> teacherListDtos = new List<TeacherListDto>();
            {

                foreach (var teacher in teachers)
                {
                    teacherListDtos.Add(new TeacherListDto
                    {
                        Id = teacher.Id,
                        UniverstyGraduatedFrom = teacher.UniverstyGraduatedFrom,
                        HourlyPrice = teacher.HourlyPrice,
                        IsFacetoFace = teacher.IsFacetoFace,
                        CertifiedTrainer = teacher.CertifiedTrainer,
                        Email = teacher.Email,
                        Phone = teacher.Phone,
                        FirstName = teacher.FirstName,
                        LastName = teacher.LastName,
                        Description = teacher.Description,
                        Age = teacher.Age,
                        Gender = teacher.Gender,
                        ImageUrl = teacher.ImageUrl,
                        Location = teacher.Location,
                        Url = teacher.Url,
                        Branch = teacher
                            .TeacherAndBranches
                            .Select(tab => tab.Branch)
                            .ToList(),
                        Students = teacher.StudentAndTeachers
                        .Select(tab => tab.Student)
                        .ToList()
                    });
                };

            }
            ViewBag.SelectedMenu = "Teacher";
            ViewBag.Title = "Öğretmenler";
            return View(teacherListDtos);

        }
        public async Task<IActionResult> TeacherDetails(string url)
        {
            if (url == null)
            {
                return NotFound();
            }
            var teacher = await _teacherManager.GetTeacherDetailsByUrlAsync(url);
            TeacherDetailsDto teacherDetailsDtos = new TeacherDetailsDto
            {
                Id = teacher.Id,
                UniverstyGraduatedFrom = teacher.UniverstyGraduatedFrom,
                HourlyPrice = teacher.HourlyPrice,
                IsFacetoFace = teacher.IsFacetoFace,
                CertifiedTrainer = teacher.CertifiedTrainer,
                Email = teacher.Email,
                Phone = teacher.Phone,
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                Description = teacher.Description,
                Age = teacher.Age,
                Gender = teacher.Gender,
                ImageUrl = teacher.ImageUrl,
                Location = teacher.Location,
                Url = Jobs.InitUrL(teacher.FirstName),
                Branch = teacher
                    .TeacherAndBranches
                    .Select(tab => tab.Branch)
                    .ToList(),
                Students=teacher
                .StudentAndTeachers
                .Select(tas=>tas.Student)
                .ToList()
            };
            return View(teacherDetailsDtos);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var branchs = await _branchManager.GetAllAsync();
            var teacherAddDto = new TeacherAddDto
            {
                Branchs = branchs
            };
            return View(teacherAddDto);
        }
        [HttpPost]
        public async Task<IActionResult> Create(TeacherAddDto teacherAddDto)
        {
            if (ModelState.IsValid)
            {

                var url = Jobs.InitUrL(teacherAddDto.FirstName);
                var teacher = new Teacher
                {

                    FirstName = teacherAddDto.FirstName,
                    LastName = teacherAddDto.LastName,
                    UniverstyGraduatedFrom = teacherAddDto.UniverstyGraduatedFrom,
                    HourlyPrice = teacherAddDto.HourlyPrice,
                    Email = teacherAddDto.Email,
                    Age = teacherAddDto.Age,
                    Gender = teacherAddDto.Gender,
                    Phone = teacherAddDto.Phone,
                    Description = teacherAddDto.Description,
                    Location = teacherAddDto.Location,
                    Url = url,
                    ImageUrl = Jobs.UploadImage(teacherAddDto.ImageFile),


                };
                await _teacherManager.CreateTeacherAsync(teacher, teacherAddDto.SelectedBranchId);
                return RedirectToAction("Index");
            }
            var branchs = await _branchManager.GetAllAsync();
            teacherAddDto.Branchs = branchs;
            teacherAddDto.ImageUrl = teacherAddDto.ImageUrl;

            return View(teacherAddDto);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var teacher = await _teacherManager.GetByIdAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }
            _teacherManager.Delete(teacher);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var teacher = await _teacherManager.GetTeacherWithAll(id);
            TeacherUpdateDto teacherUpdateDto = new TeacherUpdateDto
            {
                Id = teacher.Id,
                UniverstyGraduatedFrom = teacher.UniverstyGraduatedFrom,
                HourlyPrice = teacher.HourlyPrice,
                IsFacetoFace = teacher.IsFacetoFace,
                CertifiedTrainer = teacher.CertifiedTrainer,
                Email = teacher.Email,
                Phone = teacher.Phone,
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                Description = teacher.Description,
                Age = teacher.Age,
                Gender = teacher.Gender,
                ImageUrl = teacher.ImageUrl,
                Location = teacher.Location,
                Url = Jobs.InitUrL(teacher.FirstName),
                SelectedBranchId = teacher
                    .TeacherAndBranches
                    .Select(pc => pc.BranchId).ToArray(),
                SelectedStudentId = teacher
                .StudentAndTeachers
                .Select(pc => pc.StudentId).ToArray()
                

            };
            var branchs = await _branchManager.GetAllAsync();
            teacherUpdateDto.Branchs = branchs;
            var students = await _studentManager.GetAllAsync();
            teacherUpdateDto.Students = students;
            return View(teacherUpdateDto);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(TeacherUpdateDto teacherUpdateDto, int[] selectedBranchId, int[] selectedStudentId)
        {
            if (ModelState.IsValid)
            {
                var teacher = await _teacherManager.GetByIdAsync(teacherUpdateDto.Id);
                if (teacher==null)
                {
                    return NotFound();
                }
                var url = Jobs.InitUrL(teacherUpdateDto.FirstName);
                var imageUrl = teacherUpdateDto.ImageFile != null ? Jobs.UploadImage(teacherUpdateDto.ImageFile) : teacher.ImageUrl;
                teacher.Id = teacherUpdateDto.Id;
                teacher.UniverstyGraduatedFrom = teacherUpdateDto.UniverstyGraduatedFrom;
                teacher.HourlyPrice = teacherUpdateDto.HourlyPrice;
                teacher.IsFacetoFace = teacherUpdateDto.IsFacetoFace;
                teacher.CertifiedTrainer = teacherUpdateDto.CertifiedTrainer;
                teacher.Email = teacherUpdateDto.Email;
                teacher.Phone = teacherUpdateDto.Phone;
                teacher.FirstName = teacherUpdateDto.FirstName;
                teacher.LastName = teacherUpdateDto.LastName;
                teacher.Description = teacherUpdateDto.Description;
                teacher.Age = teacherUpdateDto.Age;
                teacher.Gender = teacherUpdateDto.Gender;
                teacher.ImageUrl =imageUrl;
                teacher.Location = teacherUpdateDto.Location;
                teacher.Url = url;
                await _teacherManager.UpdateTeacherAsync(teacher, selectedBranchId, selectedStudentId);

            }
            var branchs = await _branchManager.GetAllAsync();
            teacherUpdateDto.Branchs = branchs;
            var students = await _studentManager.GetAllAsync();
            teacherUpdateDto.Students = students;
            return RedirectToAction("Index");
        }
    }
}
