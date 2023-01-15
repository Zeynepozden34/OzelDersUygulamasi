using OzelDers.Entity.Concrete;

namespace OzelDers.Web.Areas.Admin.Models.Dtos
{
    public class StudentListDto
    {
        public int Id { get; set; }       
        public List<Teacher> Teachers { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string ImageUrl { get; set; }
        public string Location { get; set; }
        public string Url { get; set; }
    }
}
