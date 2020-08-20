using System;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Must Select Quantity to Order")]
        [Range(1, 100)]
        public int OrderQuantity { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Display(Name = "Choose a Customer: ")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}