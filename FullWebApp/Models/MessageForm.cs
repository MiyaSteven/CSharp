using System;
using System.ComponentModel.DataAnnotations;

namespace FullWebApp.Models
{
    public class MessageForm
    {
        [Required(ErrorMessage = "Required Field")]
        [MinLength(3, ErrorMessage = "Name must be at least 3 Characters")]
        [Display(Name = "Name: ")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Required Field")]
        [Display(Name = "Email: ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Required Field")]
        [MinLength(3, ErrorMessage = "Company must be at least 3 Characters")]
        [MaxLength(20, ErrorMessage = "Company must not exceed 20 Characters")]
        [Display(Name = "Company: ")]
        public string Company { get; set; }

        [Required(ErrorMessage = "Required Field")]
        [MinLength(10, ErrorMessage = "Message must be at least 10 Characters")]
        [Display(Name = "Message: ")]
        public string Message { get; set; }

        [Required]
        [Range(1, Double.PositiveInfinity)]
        [Display(Name = "Priority Level: ")]
        public int PriorityLevel { get; set; }
    }
}
