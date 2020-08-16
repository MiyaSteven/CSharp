using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProdAndCat.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Product's name must be entered.")]
        [MinLength(3, ErrorMessage = "Product's name must be at least 3 characters long.")]
        [MaxLength(20, ErrorMessage = "Max Length of 20 Characters")]
        [Display(Name = "Name: ")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [MinLength(2, ErrorMessage = "Description must be at least 2 characters long.")]
        [MaxLength(100, ErrorMessage = "Max Length of 100 Characters")]
        [Display(Name = "Description: ")]
        public string Description { get; set; }
        public int Price { get; set; }
        public int ProdCategoryId { get; set; }
        public Category ProdCategory { get; set; }
        public List<Association> ProdAndCatAssoc { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}