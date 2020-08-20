using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ECommerce.Extensions;

namespace ECommerce.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Product Name is required.")]
        [MinLength(2, ErrorMessage = "Product title must be at least 2 characters long.")]
        [Display(Name = "Product Name: ")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Release date is required.")]
        [PastDate]
        [Display(Name = "Release Date: ")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [MinLength(10, ErrorMessage = "Description must be at least 10 characters long.")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description: ")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Must set a initial quantity between 1 and 10000")]
        [Range(1, 10000)]
        [Display(Name = "Initial Quantity: ")]
        public int Quantity { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<Order> Orders { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}