using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OzelDers.Web.Models
{
    public class ResetPasswordDto
    {
        [Required]
        public string Token { get; set; }

        [DisplayName("Email Adresi")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Yeni Parola")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
