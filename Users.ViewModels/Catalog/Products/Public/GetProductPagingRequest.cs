using Users.ViewModels.Base;

namespace Users.ViewModels.Catalog.Products.Public
{
    public class GetProductPagingRequest : PagingRequestBase
    {
        public int? CategoryID { get; set; }
    }
}
