using System.ComponentModel.DataAnnotations;

namespace TheWall.Models
{
    public class LoginUser
    {
        [Required(ErrorMessage = "Required Field")]
        [EmailAddress(ErrorMessage = "Please log in with an email address.")]
        [Display(Name = "Email: ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Required Field")]
        [DataType(DataType.Password)]
        [Display(Name = "Password: ")]
        public string Password { get; set; }
    }
}
