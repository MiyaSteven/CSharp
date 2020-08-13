using System;
using System.ComponentModel.DataAnnotations;

namespace CRUDelicious.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Must enter full name.")]
        [Display(Name = "Full Name: ")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Please enter your age")]
        [Display(Name = "Age: ")]
        public int? Age { get; set; }

        [Display(Name = "Are you Verified: ")]
        public bool IsVerified { get; set; }

        [Required(ErrorMessage = "You must enter your catch phrase so we know what you're about")]
        [Display(Name = "Catch Phrase: ")]
        public string CatchPhrase { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}