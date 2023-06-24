using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Application.Catalog.Products.Dtos;
using Users.Application.Catalog.Products.Dtos.Manage;
using Users.Application.Dtos;
using Users.Data.EF;
using Users.Data.Entities;
using Users.Utilities.Exceptions;

namespace Users.Application.Catalog.Products
{
    public class ManageProductService : IManageProductService
    {
        private readonly UsersDbContext _context;
        public ManageProductService(UsersDbContext context)
        {
            _context = context;
        }

        public async Task AddViewCount(int productID)
        {
            var prd = await _context.Products.FindAsync(productID);
            prd.ViewCount += 1;
            await _context.SaveChangesAsync();
        }

        public async Task<int> Create(ProductCreateRequest create)
        {
            var pr = new Product
            {
                Price = create.Price,
                OgPrice = create.OgPrice,
                Stock = create.Stock,
                ViewCount = 0,
                DateCreate = DateTime.Now,
                ProductTranslations = new List<ProductTranslation>() 
                { 
                    new ProductTranslation()
                    {
                        Name = create.Name,
                        Description = create.Description,
                        Details = create.Details,
                        SeoDescription = create.SeoDescription,
                        SeoAlias = create.SeoAlias,
                        SeoTitle = create.SeoTitle,
                        LanguageId = create.LanguageId
                    }
                }
            };
            _context.Products.Add(pr);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var prd = await _context.Products.FindAsync(id);
            if (prd == null)
                throw new UserException($"Can't find product: {id}");
            _context.Products.Remove(prd);
            return await _context.SaveChangesAsync();
        }

        public async Task<PagedResult<ProductViewModel>> GetAllPageing(GetProductPagingRequest get)
        {
            //Select Join
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.ID equals pt.ProductId
                        join pic in _context.ProductInCategories on p.ID equals pic.ProductId
                        join c in _context.Categories on pic.CategoryId equals c.Id
                        select new {p, pt, pic};
            //Filter
            if (string.IsNullOrEmpty(get.KeyWord))
                query = query.Where(x => x.pt.Name.Contains(get.KeyWord));
            if (get.CategoryIDs.Count > 0)
                query = query.Where(p => get.CategoryIDs.Contains(p.pic.CategoryId));
            //Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((get.PageIndex - 1) * get.PageSize)
                .Take(get.PageSize)
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

        public async Task<int> Update(ProductUpdateRequest edit)
        {
            var product = await _context.Products.FindAsync(edit.ID);
            var productTranslation = await _context.ProductTranslations.FirstOrDefaultAsync(x => x.ProductId == edit.ID && x.LanguageId == edit.LanguageId);

            if (product == null || productTranslation == null)
                throw new UserException($"Cannot find a product with ID: {edit.ID}");

            productTranslation.Name = edit.Name;
            productTranslation.SeoAlias = edit.SeoAlias;
            productTranslation.SeoDescription = edit.SeoDescription;
            productTranslation.SeoTitle = edit.SeoTitle;
            productTranslation.Details = edit.Details;
            productTranslation.Description = edit.Description;

            return await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdatePrice(int procductID, decimal newPrice)
        {
            var product = await _context.Products.FindAsync(procductID);
            if (product == null)
                throw new UserException($"Cannot find a product with ID: {procductID}");
            product.Price = newPrice;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateStock(int productID, int addQuantity)
        {
            var product = await _context.Products.FindAsync(productID);
            if (product == null)
                throw new UserException($"Cannot find a product with ID: {productID}");
            product.Stock += addQuantity;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
