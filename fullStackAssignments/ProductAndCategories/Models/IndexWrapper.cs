using System.Collections.Generic;

namespace ProductAndCategories.Models
{
    public class IndexWrapper
    {
        public Association Form { get; set; }
        public List<Product> AllProducts { get; set; }
        public List<Category> AllCategories { get; set; }
    }
}