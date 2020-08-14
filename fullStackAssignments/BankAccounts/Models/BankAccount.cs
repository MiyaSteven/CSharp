using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BankAccounts
{
    public class BankAccount
    {
        [Key]
        public int BankAccountId { get; set; }
        public string Name { get; set; }
        public List<RegUser> RegUsers { get; set; }
        public List<Companies> CompaniesPay { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}