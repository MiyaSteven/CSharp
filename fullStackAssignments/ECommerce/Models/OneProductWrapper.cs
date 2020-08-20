using System.Collections.Generic;

namespace ECommerce.Models
{
    public class OneProductWrapper
    {
        public int LoggedId { get; set; }
        public Product Product { get; set; }
        public Order AddOrderForm { get; set; }
        public List<Customer> AllCustomers { get; set; }
    }
}