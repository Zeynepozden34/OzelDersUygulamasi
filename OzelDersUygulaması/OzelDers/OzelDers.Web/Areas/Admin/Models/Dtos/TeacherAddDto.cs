using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using OzelDers.Entity.Concrete;
using OzelDers.Entity.Concrete.Identity;

namespace OzelDers.Web.Areas.Admin.Models.Dtos
{
    public class TeacherAddDto
    {
        [DisplayName("Öğretmen Adı")]
        [Required(ErrorMessage = "{0} boş bırakılmamalıdır.")]
        public string FirstName { get; set; }

        [DisplayName("Kullanıcı Adı")]
        [Required(ErrorMessage = "{0} boş bırakılmamalıdır.")]
        public string UserName { get; set; }


        [DisplayName("Öğretmen Soyadı")]
        [Required(ErrorMessage = "{0} boş bırakılmamalıdır.")]
        public string LastName { get; set; }



        [DisplayName("Mezun Olduğu Üniversite")]
        [Required(ErrorMessage = "{0} boş bırakılmamalıdır.")]
        public string UniverstyGraduatedFrom { get; set; }



        [Required(ErrorMessage = "En az bir Ders seçilmelidir.")]
        public int[] SelectedBranchId { get; set; }



        [DisplayName("Dersler")]
        public List<Branch> Branchs { get; set; }



        [DisplayName("Saatlik Ücret")]
        public int HourlyPrice { get; set; }



        [DisplayName("Email")]
        [Required(ErrorMessage = "{0} boş bırakılmamalıdır.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        [DisplayName("Telefon Numarası")]
        [Required(ErrorMessage = "{0} boş bırakılmamalıdır.")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }



        [DisplayName("Açıklama")]
        [Required(ErrorMessage = "{0} boş bırakılmamalıdır.")]
        public string Description { get; set; }



        [DisplayName("Yaş")]
        [Required(ErrorMessage = "{0} boş bırakılmamalıdır.")]
        public int Age { get; set; }



        [DisplayName("Cinsiyet")]
        [Required(ErrorMessage = "{0} boş bırakılmamalıdır.")]
        public string Gender { get; set; }


        [DisplayName("Resim")]
        [Required(ErrorMessage = "{0} seçilmelidir.")]
        public IFormFile ImageFile { get; set; }


        public string ImageUrl { get; set; }


        [DisplayName("Lokasyon")]
        [Required(ErrorMessage = "{0} boş bırakılmamalıdır.")]
        public string Location { get; set; }

        public int UserId { get; set; }
        public User user { get; set; }


    }
}
