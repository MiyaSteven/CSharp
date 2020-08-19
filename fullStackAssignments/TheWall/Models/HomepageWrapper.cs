using System.Collections.Generic;

namespace TheWall.Models
{
    public class HomepageWrapper
    {
        public User LoggedUser { get; set; }
        public Message Message { get; set; }
        public List<Message> AllMessages { get; set; }
        public Comment Comment { get; set; }
        public List<Comment> AllComments { get; set; }
    }
}