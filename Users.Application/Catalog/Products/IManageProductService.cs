using System.Collections.Generic;
using System.Threading.Tasks;
using Users.Application.Catalog.Products.Dtos;
using Users.Application.Catalog.Products.Dtos.Manage;
using Users.Application.Dtos;

namespace Users.Application.Catalog.Products
{
    public interface IManageProductService
    {
        Task<int> Create(ProductCreateRequest create);
        Task<int> Update(ProductUpdateRequest edit);
        Task<bool> UpdatePrice(int procductID, decimal newPrice);
        Task AddViewCount(int productID);
        Task<bool> UpdateStock(int productID, int addQuantity);
        Task<int> Delete(int id);     
        Task<PagedResult<ProductViewModel>> GetAllPageing(GetProductPagingRequest get);
    }
}
