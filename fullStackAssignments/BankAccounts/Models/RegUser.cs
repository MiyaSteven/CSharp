using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BankAccounts.Models
{
    public class RegUser
    {
        [Key]
        public int RegUserId { get; set; }

        [Required(ErrorMessage = "Required Field")]
        [Display(Name = "First Name: ")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Required Field")]
        [Display(Name = "Last Name: ")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Required Field")]
        [Display(Name = "Email: ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Required Field")]
        [Display(Name = "Password: ")]
        public string Password { get; set; }
        public BankAccount AccountType { get; set; }
        public List<Companies> CompaniesPaid { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
