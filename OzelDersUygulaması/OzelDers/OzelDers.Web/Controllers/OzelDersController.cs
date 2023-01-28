using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OzelDers.Business.Abstract;
using OzelDers.Core;
using OzelDers.Entity.Concrete;
using OzelDers.Web.Models;


namespace OzelDers.Web.Controllers
{
    [Authorize]
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
            List<TeacherListDto> teacherDtos = new List<TeacherListDto>();
            if (branchurl == null)
            {
                return NotFound();
            }
            foreach (var teacher in teachers)
            {
                teacherDtos.Add(new TeacherListDto
                {
                    Id = teacher.Id,
                    UniverstyGraduatedFrom = teacher.UniverstyGraduatedFrom,
                    HourlyPrice = teacher.HourlyPrice,
                    IsFacetoFace = teacher.IsFacetoFace,
                    CertifiedTrainer = teacher.CertifiedTrainer,
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
        public async Task<IActionResult> HomeTeacherDetails(string url)
        {
            if (url == null)
            {
                return NotFound();
            }
            var teacher = await _teacherManager.GetTeacherDetailsByUrlAsync(url);
            HomeTeacherDetailsDto homeTeacherDetailsDtos = new HomeTeacherDetailsDto
            {
                Id = teacher.Id,
                UniverstyGraduatedFrom = teacher.UniverstyGraduatedFrom,
                HourlyPrice = teacher.HourlyPrice,
                IsFacetoFace = teacher.IsFacetoFace,
                CertifiedTrainer = teacher.CertifiedTrainer,
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
            };
            return View(homeTeacherDetailsDtos);
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

    }
}
