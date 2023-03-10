using OzelDers.Entity.Concrete;

namespace OzelDers.Web.Areas.Admin.Models.Dtos
{
    public class TeacherListDto
    {
        public int Id { get; set; }
        public string UniverstyGraduatedFrom { get; set; }
        public int HourlyPrice { get; set; }
        public bool IsFacetoFace { get; set; }
        public bool CertifiedTrainer { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<Branch> Branch { get; set; }
        public List<Student> Students { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string ImageUrl { get; set; }
        public string Location { get; set; }
        public string Url { get; set; }


    }
}
