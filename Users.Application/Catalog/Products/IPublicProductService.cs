﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Users.ViewModels.Base;
using Users.ViewModels.Catalog.Products;

namespace Users.Application.Catalog.Products
{
    public interface IPublicProductService
    {
        Task<PagedResult<ProductViewModel>> GetAllByCategoryID(string languageID, GetPublicProductPagingRequest request);
        Task<List<ProductViewModel>> GetAll(string languageID);
    }
}
