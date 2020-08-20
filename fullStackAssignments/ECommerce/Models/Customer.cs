using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Customer name is required.")]
        [MinLength(2, ErrorMessage = "Customer name must be at least 2 characters long.")]
        [Display(Name = "Customer Name: ")]
        public string CustomerName { get; set; }
        public List<Order> Orders { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}