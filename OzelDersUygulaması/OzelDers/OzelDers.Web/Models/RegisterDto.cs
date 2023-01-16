using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OzelDers.Web.Models
{
    public class RegisterDto
    {
        public string SelectedUser { get; set; }

        [DisplayName("Ad")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        public string FirstName { get; set; }

        [DisplayName("Soyad")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        public string LastName { get; set; }

        [DisplayName("Kullanıcı Adı")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        public string UserName { get; set; }

        [DisplayName("Resim")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        public IFormFile ImageFile { get; set; }

        public string ImageUrl { get; set; }

        [DisplayName("Eposta")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Telefon No")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [DisplayName("Açıklama")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        public string Description { get; set; }

        [DisplayName("Cinsiyet")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        public string Gender { get; set; }


        [DisplayName("Yaş")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        public string Age { get; set; }

        [DisplayName("Lokasyon")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        public string Location { get; set; }


        [DisplayName("Parola")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Parola Tekrar")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Parola ile {0} aynı olmalıdır.")]
        public string RePassword { get; set; }
    }
}
