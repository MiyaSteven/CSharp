using System;
using System.ComponentModel.DataAnnotations;

namespace FullWebApp.Models
{
    public class Person
    {
        [Required(ErrorMessage = "Name must be entered")]
        [MinLength(2, ErrorMessage = "Name must be 2 Characters long")]
        [MaxLength(18, ErrorMessage = "Location must not exceed 18 Characters")]
        [Display(Name = "Name: ")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Location must be entered")]
        [MinLength(3, ErrorMessage = "Location must be at least 3 Characters")]
        [MaxLength(20, ErrorMessage = "Location must not exceed 20 Characters")]
        [Display(Name = "Location: ")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Required Field")]
        [Display(Name = "Email: ")]
        public string Email { get; set; }

        [Required]
        [Range(1, Double.PositiveInfinity)]
        [Display(Name = "Skills: ")]
        public int Skills { get; set; }

        [Display(Name = "Total Exp: ")]
        public int TotalExperience { get; set; }
    }
}
