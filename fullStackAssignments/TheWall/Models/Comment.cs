using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheWall.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        [Required(ErrorMessage = "Nothing to post")]
        [Display(Name = "Post a Comment: ")]
        public string CommentText { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int MessageId { get; set; }
        public Message Message { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
