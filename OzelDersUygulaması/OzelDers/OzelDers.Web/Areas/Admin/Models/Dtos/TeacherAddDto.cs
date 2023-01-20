using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OzelDers.Web.Areas.Admin.Models.Dtos
{
    public class TeacherAddDto
    {
        [DisplayName("Öğretmen Adı")]
        [Required(ErrorMessage = "{0} boş bırakılmamalıdır.")]

        public string FirstName { get; set; }

        [DisplayName("Öğretmen Soyadı")]
        [Required(ErrorMessage = "{0} boş bırakılmamalıdır.")]

        public string LastName { get; set; }

        [DisplayName("Mezun Olduğu Üniversite")]
        [Required(ErrorMessage = "{0} boş bırakılmamalıdır.")]
        public string UniverstyGraduatedFrom { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "{0} boş bırakılmamalıdır.")]
        [DataType(DataType.EmailAddress)]

        public string Email { get; set; }

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
    }
}
