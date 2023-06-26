using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Users.Data.EF;
using Users.ViewModels.Base;
using Users.ViewModels.Catalog.Products;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Users.Application.Catalog.Products
{
    public class PublicProductService : IPublicProductService
    {
        private readonly UsersDbContext _context;
        public PublicProductService(UsersDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductViewModel>> GetAll(string languageID)
        {
            //Select Join
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.ID equals pt.ProductId
                        join pic in _context.ProductInCategories on p.ID equals pic.ProductId
                        join c in _context.Categories on pic.CategoryId equals c.Id
                        where pt.LanguageId == languageID
                        select new { p, pt, pic };
            var data = await query.Select(x => new ProductViewModel()
                {
                    ID = x.p.ID,
                    Name = x.pt.Name,
                    DateCreate = x.p.DateCreate,
                    Description = x.pt.Description,
                    Details = x.pt.Details,
                    LanguageId = x.pt.LanguageId,
                    OgPrice = x.p.OgPrice,
                    Price = x.p.Price,
                    SeoAlias = x.pt.SeoAlias,
                    SeoDescription = x.pt.SeoDescription,
                    SeoTitle = x.pt.SeoTitle,
                    Stock = x.p.Stock,
                    ViewCount = x.p.ViewCount
                }).ToListAsync();
            return data;
        }

        public async Task<PagedResult<ProductViewModel>> GetAllByCategoryID(string languageID, GetPublicProductPagingRequest request)
        {
            //Select Join
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.ID equals pt.ProductId
                        join pic in _context.ProductInCategories on p.ID equals pic.ProductId
                        join c in _context.Categories on pic.CategoryId equals c.Id
                        where pt.LanguageId == languageID
                        select new { p, pt, pic };
            //Filter
            if (request.CategoryID.HasValue && request.CategoryID.Value > 0)
            {
                query = query.Where(p => p.pic.CategoryId == request.CategoryID);
            }
            //Paging
            int totalRow = await query.CountAsync();


            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ProductViewModel()
                {
                    ID = x.p.ID,
                    Name = x.pt.Name,
                    DateCreate = x.p.DateCreate,
                    Description = x.pt.Description,
                    Details = x.pt.Details,
                    LanguageId = x.pt.LanguageId,
                    OgPrice = x.p.OgPrice,
                    Price = x.p.Price,
                    SeoAlias = x.pt.SeoAlias,
                    SeoDescription = x.pt.SeoDescription,
                    SeoTitle = x.pt.SeoTitle,
                    Stock = x.p.Stock,
                    ViewCount = x.p.ViewCount
                }).ToListAsync();

            //Select
            var pageResult = new PagedResult<ProductViewModel>()
            {
                TotalRecord = totalRow,
                Items = data
            };
            return pageResult;
        }
    }
}
