using Users.ViewModels.Base;

namespace Users.ViewModels.Catalog.Products
{
    public class GetPublicProductPagingRequest : PagingRequestBase
    {
        public int? CategoryID { get; set; }
    }
}
