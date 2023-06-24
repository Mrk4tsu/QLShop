using System.Threading.Tasks;
using Users.Application.Catalog.Products.Dtos;
using Users.Application.Catalog.Products.Dtos.Public;
using Users.Application.Dtos;

namespace Users.Application.Catalog.Products
{
    public interface IPublicProductService
    {
        Task<PagedResult<ProductViewModel>> GetAllByCategoryID(GetProductPagingRequest request);
    }
}
