using System;
using System.Collections.Generic;

namespace ProdAndCat.Models
{
    public class AssociationWrapper
    {
        public Product ToDisplay { get; set; }
        public List<Product> ProductDropdown { get; set; }
        public Category CatDisplay { get; set; }
        public List<Category> CategoryDropdown { get; set; }
        public Association AssociationForm { get; set; }
    }
}