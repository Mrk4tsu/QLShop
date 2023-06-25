
using Microsoft.AspNetCore.Http;

namespace Users.ViewModels.Catalog.Products.Manage
{
    public class ProductCreateRequest
    {
        public decimal Price { get; set; }
        public decimal OgPrice { get; set; }
        public int Stock { get; set; }
        public string Name { set; get; }
        public string Description { get; set; }
        public string Details { get; set; }
        public string SeoDescription { get; set; }
        public string SeoTitle { get; set; }
        public string SeoAlias { get; set; }
        public string LanguageId { get; set; }
        public IFormFile ThumnailImage { get; set; }
    }
}
