using Microsoft.AspNetCore.Mvc;
using OzelDers.Business.Abstract;
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
            return View(teacherListDtos);

        }
    }
}
