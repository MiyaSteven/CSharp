using System.Collections.Generic;

namespace ECommerce.Models
{
    public class ProductsWrapper
    {
        public User LoggedUser { get; set; }
        public List<Product> AllProducts { get; set; }
    }
}