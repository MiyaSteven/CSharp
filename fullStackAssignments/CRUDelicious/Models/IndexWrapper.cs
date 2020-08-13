using System.Collections.Generic;

namespace CRUDelicious.Models
{
    public class IndexWrapper
    {
        public User FormModel { get; set; }
        public List<User> TableModel { get; set; }
    }
}