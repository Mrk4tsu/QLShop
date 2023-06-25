using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users.Application.Catalog.Products.Dtos.Manage
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

    }
}
