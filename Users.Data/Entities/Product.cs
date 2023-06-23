using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Users.Data.Entities
{
    public class Product
    {
        public int ID { get; set; }
        public decimal Price { get; set; }
        public decimal OgPrice { get; set; }
        public int Stock { get; set; }
        public int ViewCount { get; set; }
        public DateTime DateCreate { get; set; }
        public List<ProductInCategory> ProductInCategories { get; set;}
        public List<OrderDetail> OrderDetails { get; set; }
        public List<Cart> Carts { get; set; }
        public List<ProductTranslation> ProductTranslations { get; set; }
    }
}
