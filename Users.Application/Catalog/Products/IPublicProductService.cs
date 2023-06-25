using System.Threading.Tasks;
using Users.ViewModels.Base;
using Users.ViewModels.Catalog.Products;
using Users.ViewModels.Catalog.Products.Public;

namespace Users.Application.Catalog.Products
{
    public interface IPublicProductService
    {
        Task<PagedResult<ProductViewModel>> GetAllByCategoryID(GetProductPagingRequest request);
    }
}
