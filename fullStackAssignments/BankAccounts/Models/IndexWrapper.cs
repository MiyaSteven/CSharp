using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BankAccounts.Models
{
    public class IndexWrapper
    {
        public RegUser FormModel { get; set; }
        public List<RegUser> TableModel { get; set; }
    }
}