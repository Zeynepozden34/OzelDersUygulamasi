using Microsoft.AspNetCore.Mvc;
using OzelDers.Business.Abstract;
using OzelDers.Business.Concrete;
using OzelDers.Entity.Concrete;
using OzelDers.Web.Areas.Admin.Models.Dtos;

namespace OzelDers.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentManager;

        public StudentController(IStudentService studentManager)
        {
            _studentManager = studentManager;
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
            return View(studentListDtos);
       
        }
    }
}
