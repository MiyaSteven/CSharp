using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TheWall.Models
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }

        [Required(ErrorMessage = "Required Field")]
        [Display(Name = "Post a Message: ")]
        public string MessageText { get; set; }
        public int UserId { get; set; }
        public User Poster { get; set; }
        public List<Comment> ListOfComments { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}