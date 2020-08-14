using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BankAccounts
{
    public class Companies
    {
        [Key]
        public int CompaniesId { get; set; }
        public int RegUserId { get; set; }
        public int BankAccountsId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}