using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OzelDers.Business.Abstract;
using OzelDers.Business.Concrete;
using OzelDers.Core;
using OzelDers.Entity.Concrete;
using OzelDers.Web.Areas.Admin.Models.Dtos;
using OzelDers.Web.Models;

namespace OzelDers.Web.Areas.Admin.Controllers
{
    [Authorize(Roles ="Admin")]
    [Area("Admin")]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentManager;
        private readonly ITeacherService _teacherManager;

        public StudentController(IStudentService studentManager, ITeacherService teacherManager)
        {
            _studentManager = studentManager;
            _teacherManager = teacherManager;
        }

        public async Task<IActionResult> Index()
        {
            List<Student> teachers = await _studentManager.GetStudentWithTeacher();
            List<StudentListDto> studentListDtos = new List<StudentListDto>();
            {

                foreach (var teacher in teachers)
                {
                    studentListDtos.Add(new StudentListDto
                    {
                        Id = teacher.Id,                     
                        FirstName = teacher.FirstName,
                        LastName = teacher.LastName,
                        Email= teacher.Email,
                        Phone= teacher.Phone,
                        Description = teacher.Description,
                        Age = teacher.Age,
                        Gender = teacher.Gender,
                        ImageUrl = teacher.ImageUrl,
                        Location = teacher.Location,
                        Url = teacher.Url,
                        Teachers = teacher.StudentAndTeachers
                        .Select(tab => tab.Teacher)
                        .ToList()
                    });
                };

            }
            ViewBag.SelectedMenu = "Student";
            ViewBag.Title = "Öğrenciler";
            return View(studentListDtos);
       
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            StudentAddDto studentAddDto = new StudentAddDto();
            return View(studentAddDto);
        }
        [HttpPost]
        public async Task<IActionResult> Create(StudentAddDto studentAddDto)
        {
            if (ModelState.IsValid)
            {
                var url = Jobs.InitUrL(studentAddDto.FirstName);
                var student = new Student
                {
                  
                   FirstName=studentAddDto.FirstName,
                   LastName=studentAddDto.LastName,
                   Email=studentAddDto.Email,
                   Age=studentAddDto.Age,
                   Gender=studentAddDto.Gender,
                   Phone=studentAddDto.Phone,
                   Description=studentAddDto.Description,
                   Location=studentAddDto.Location,
                   Url=url,
                   ImageUrl = Jobs.UploadImage(studentAddDto.ImageFile)

                };
                await _studentManager.CreateAsync(student);
                return RedirectToAction("Index");
            }
            studentAddDto.ImageUrl = studentAddDto.ImageUrl;
            return View(studentAddDto);
        }

        
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _studentManager.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            _studentManager.Delete(student);
            return RedirectToAction("Index");
        }

    }
}
