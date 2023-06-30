using Microsoft.AspNetCore.Http;

namespace Users.ViewModels.Catalog.ProductsImage
{
    public class ProductImageCreateRequest
    {
        public string Caption { get; set; }

        public bool IsDefault { get; set; }

        public int SortOrder { get; set; }

        public IFormFile ImageFile { get; set; }
    }
}
