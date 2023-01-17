using Microsoft.AspNetCore.Mvc;
using OzelDers.Business.Abstract;
using OzelDers.Core;
using OzelDers.Entity.Concrete;
using OzelDers.Web.Areas.Admin.Models.Dtos;

namespace OzelDers.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeacherController : Controller
    {

        private readonly ITeacherService _teacherManager;
        private readonly IStudentService _studentManager;

        public TeacherController(ITeacherService teacherManager, IStudentService studentManager)
        {
            _teacherManager = teacherManager;
            _studentManager = studentManager;
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
                        Phone= teacher.Phone,
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
                Phone= teacher.Phone,
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
                Students = teacher
                    .StudentAndTeachers
                    .Select(tas => tas.Student)
                    .ToList()
            };
            return View(teacherDetailsDtos);
        }
    }
}
