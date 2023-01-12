using Microsoft.AspNetCore.Mvc;
using OzelDers.Business.Abstract;
using OzelDers.Data.Abstract;
using OzelDers.Entity.Concrete;
using OzelDers.Web.Models;

namespace OzelDers.Web.Controllers
{
    public class OzelDersController : Controller
    {
        private readonly IBranchService _branchManager;
        private readonly ITeacherService _teacherManager;

        public OzelDersController(IBranchService branchManager, ITeacherService teacherManager)
        {
            _branchManager = branchManager;
            _teacherManager = teacherManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> TeacherList(string branchurl)
        {
            List<Teacher> teachers = await _teacherManager.GetTeacherByBranchAsync(branchurl);
            List<TeacherDto> teacherDtos = new List<TeacherDto>();
            if (branchurl == null)
            {
                return NotFound();
            }
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

                });
            }
            return View(teacherDtos);
        }

    }
}
