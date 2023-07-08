using System.Collections.Generic;
using System.Threading.Tasks;
using Users.ViewModels.Base;
using Users.ViewModels.Catalog.Products;
using Users.ViewModels.Catalog.ProductsImage;

namespace Users.Application.Catalog.Products
{
    public interface IProductService
    {
        Task<int> Create(ProductCreateRequest create);
        Task<int> Update(ProductUpdateRequest edit);
        Task<bool> UpdatePrice(int procductID, decimal newPrice);
        Task AddViewCount(int productID);
        Task<bool> UpdateStock(int productID, int addQuantity);
        Task<int> Delete(int id);
        Task<ProductViewModel> GetByID(int productID, string languageID);
        Task<PagedResult<ProductViewModel>> GetAllPageing(GetManageProductPagingRequest get);
        Task<int> AddImage(int productId, ProductImageCreateRequest request);
        Task<int> RemoveImages(int imageID);
        Task<int> UpdateImage(int imageId, ProductImageUpdateRequest request);
        Task<List<ProductImageViewModel>> GetListImage(int productID);
        Task<ProductImageViewModel> GetImageByID(int imageID);
        Task<PagedResult<ProductViewModel>> GetAllByCategoryId(string languageId, GetPublicProductPagingRequest request);
    }
}
