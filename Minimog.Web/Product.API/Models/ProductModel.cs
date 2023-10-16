using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Product.API.Models
{
    public class ProductModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string ColorName { get; set; }
        public string ColorCode { get; set; }
        public string Size { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl1 { get; set; }
    }
}