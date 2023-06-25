using System;

namespace Users.ViewModels.Catalog.Products
{
    public class ProductViewModel
    {
        public int ID { get; set; }
        public decimal Price { get; set; }
        public decimal OgPrice { get; set; }
        public int Stock { get; set; }
        public int ViewCount { get; set; }
        public DateTime DateCreate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public string SeoDescription { get; set; }
        public string SeoTitle { get; set; }
        public string SeoAlias { get; set; }
        public string LanguageId { get; set; }
    }
}
