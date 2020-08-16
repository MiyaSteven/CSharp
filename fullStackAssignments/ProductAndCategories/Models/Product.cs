using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProductAndCategories.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Required Field")]
        [Display(Name = "Product Name: ")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Required Field")]
        [Display(Name = "Description: ")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Required Field")]
        [Display(Name = "Price: ")]
        public int Price { get; set; }
        public List<Association> CategoryAssociations { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}