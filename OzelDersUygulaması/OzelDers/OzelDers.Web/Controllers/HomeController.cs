using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OzelDers.Business.Abstract;
using OzelDers.Data.Config;
using OzelDers.Entity.Concrete;
using OzelDers.Web.Models;

namespace OzelDers.Web.Controllers;

public class HomeController : Controller
{
    private readonly IBranchService _branchManager;
    private readonly ITeacherService _teacherManager;

    public HomeController(IBranchService branchManager, ITeacherService teacherManager)
    {
        _branchManager = branchManager;
        _teacherManager = teacherManager;
    }

    public async Task<IActionResult> Index()
    {
        #region BranchCommenti
        //;       List<Branch> branches = await _branchManager.GetHomePageProductsAsync();
        //        List<BranchDto> branchDtos= new List<BranchDto>();
        //        foreach (var branch in branches)
        //        {
        //            branchDtos.Add(new BranchDto
        //            {
        //                Id = branch.Id,
        //                Name = branch.Name
        //            });

        //        }
        //        return View(branchDtos);
        #endregion

        List<Teacher> teachers  = await _teacherManager.GetHomePageTeachersAsync();
        List<TeacherDto> teacherDtos = new List<TeacherDto>();
        foreach (var teacher in teachers)
        {
            teacherDtos.Add(new TeacherDto
            {
                Id = teacher.Id,
                UniverstyGraduatedFrom = teacher.UniverstyGraduatedFrom,
                HourlyPrice = teacher.HourlyPrice,
                IsFacetoFace = teacher.IsFacetoFace,
                CertifiedTrainer = teacher.CertifiedTrainer,
                Email = teacher.Email,
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
                .ToList()

            }) ;
        }
        return View(teacherDtos);
    }
}
