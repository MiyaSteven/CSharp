using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeddingAssignment.Models
{
    public class Wedding
    {
        [Key]
        public int WeddingId { get; set; }

        [Required(ErrorMessage = "Required Field")]
        [Display(Name = "Wedder One: ")]
        public string WedderOne { get; set; }

        [Required(ErrorMessage = "Required Field")]
        [Display(Name = "Wedder Two: ")]
        public string WedderTwo { get; set; }

        [Required(ErrorMessage = "Required Field")]
        [Display(Name = "Date: ")]
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }

        [Required(ErrorMessage = "Required Field")]
        [Display(Name = "Address: ")]
        public string Address { get; set; }
        public int UserId { get; set; }
        public User Planner { get; set; }
        public List<Guest> ListOfGuests { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}