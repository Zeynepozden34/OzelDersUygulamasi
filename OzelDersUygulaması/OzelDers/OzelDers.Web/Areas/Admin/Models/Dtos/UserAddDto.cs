using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using OzelDers.Entity.Concrete;

namespace OzelDers.Web.Areas.Admin.Models.Dtos
{
    public class UserAddDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public IList<string> SelectedRoles { get; set; }
        public List<RoleDto> Roles { get; set; }
        public UserDto UserDto { get; set; }
        public List<Teacher> Teacher { get; set; }
        public List<Student> Student { get; set; }



    }
}
