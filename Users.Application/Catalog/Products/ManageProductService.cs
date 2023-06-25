using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Users.Application.Common;
using Users.Data.EF;
using Users.Data.Entities;
using Users.Utilities.Exceptions;
using Users.ViewModels.Base;
using Users.ViewModels.Catalog.Products;
using Users.ViewModels.Catalog.Products.Manage;
using Users.ViewModels.Catalog.ProductsImage;
using static System.Net.Mime.MediaTypeNames;

namespace Users.Application.Catalog.Products
{
    public class ManageProductService : IManageProductService
    {
        private readonly UsersDbContext _context;
        private readonly IStorageService _storageService;
        public ManageProductService(UsersDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public async Task<int> AddImage(int productId, ProductImageCreateRequest request)
        {
            var productImage = new ProductImage()
            {
                Caption = request.Caption,
                DateCreate = DateTime.Now,
                IsDefault = request.IsDefault,
                ProductID = productId,
                SortOrder = request.SortOrder
            };

            if (request.ImageFile != null)
            {
                productImage.ImagePath = await this.SaveFile(request.ImageFile);
                productImage.FileSize = request.ImageFile.Length;
            }
            _context.ProductImages.Add(productImage);
            await _context.SaveChangesAsync();
            return productImage.ID;
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
            //Save file
            if (create.ThumnailImage != null)
            {               
                pr.ProductImages = new List<ProductImage>()
                {
                    new ProductImage()
                    {
                        Caption = "Thumnail Image",
                        DateCreate = DateTime.Now,
                        FileSize = create.ThumnailImage.Length,
                        ImagePath = await SaveFile(create.ThumnailImage),
                        IsDefault = true,
                        SortOrder = 1
                    }
                };
            }
            _context.Products.Add(pr);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var prd = await _context.Products.FindAsync(id);
            if (prd == null)
                throw new UserException($"Can't find product: {id}");
            var images = _context.ProductImages.Where(i => i.IsDefault == true && i.ProductID == id);
            foreach (var image in images)
            {
                await _storageService.DeleteFileAsync(image.ImagePath);
            }
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

        public async Task<int> RemoveImages(int imageID)
        {
            var productImage = await _context.ProductImages.FindAsync(imageID);
            if (productImage == null)
                throw new UserException($"Cannot find an image with id {imageID}");
            _context.ProductImages.Remove(productImage);
            return await _context.SaveChangesAsync();
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
            //Save file
            if (edit.ThumbnailImage != null)
            {
                var thumbnailImage = _context.ProductImages.FirstOrDefault(i => i.IsDefault == true && i.ProductID == edit.ID);
                if (thumbnailImage != null)
                {
                    thumbnailImage.FileSize = edit.ThumbnailImage.Length;
                    thumbnailImage.ImagePath = await SaveFile(edit.ThumbnailImage);
                    _context.ProductImages.Update(thumbnailImage);
                }
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateImage(int imageId, ProductImageUpdateRequest request)
        {
            var productImage = await _context.ProductImages.FindAsync(imageId);
            if (productImage == null)
                throw new UserException($"Cannot find an image with id {imageId}");

            if (request.ImageFile != null)
            {
                productImage.ImagePath = await this.SaveFile(request.ImageFile);
                productImage.FileSize = request.ImageFile.Length;
            }
            _context.ProductImages.Update(productImage);
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

        public async Task<List<ProductImageViewModel>> GetListImage(int productID)
        {
            return await _context.ProductImages.Where(x => x.ProductID == productID)
               .Select(i => new ProductImageViewModel()
               {
                   Caption = i.Caption,
                   DateCreated = i.DateCreate,
                   FileSize = i.FileSize,
                   Id = i.ID,
                   ImagePath = i.ImagePath,
                   IsDefault = i.IsDefault,
                   ProductId = i.ProductID,
                   SortOrder = i.SortOrder
               }).ToListAsync();
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var ogFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(ogFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }
    }
}
