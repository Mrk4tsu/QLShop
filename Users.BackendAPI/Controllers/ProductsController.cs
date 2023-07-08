using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Users.Application.Catalog.Products;
using Users.ViewModels.Catalog.Products;
using Users.ViewModels.Catalog.ProductsImage;

namespace Users.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        //https://localhost:port/product/public-paging
        [HttpGet("{languageID}")]
        public async Task<IActionResult> Get(string languageID, [FromQuery] GetPublicProductPagingRequest request)
        {
            var product = await _productService.GetAllByCategoryId(languageID, request);
            return Ok(product);
        }
        //https://localhost:port/product/1
        [HttpGet("{productID}/{LanguageID}")]
        public async Task<IActionResult> GetByID(int productID, string LanguageID)
        {
            var product = await _productService.GetByID(productID, LanguageID);
            if (product == null)
                return BadRequest($"Không tìm thấy sản phẩm có ID: {productID}");
            return Ok(product);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ProductCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _productService.Create(request);
            if (result == 0)
                return BadRequest();

            var product = await _productService.GetByID(result, request.LanguageId);

            return CreatedAtAction(nameof(GetByID), new { id = result }, product);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] ProductUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var affectedResult = await _productService.Update(request);
            if (affectedResult == 0)
                return BadRequest();

            return Ok();
        }
        [HttpPatch("{productID}/{newPrice}")]
        public async Task<IActionResult> UpdatePrice(int productID, decimal newPrice)
        {
            var isSuccesfull = await _productService.UpdatePrice(productID, newPrice);
            if (isSuccesfull == true)
                return Ok();

            return BadRequest();
        }
        [HttpDelete("{productID}")]
        public async Task<IActionResult> Delete(int productID)
        {
            var affectedResult = await _productService.Delete(productID);
            if (affectedResult == 0)
                return BadRequest();

            return Ok();
        }
        //https://localhost:port/product/1
        [HttpGet("{productID}/images/{imageID}")]
        public async Task<IActionResult> GetImageByID(int productID, int imageID)
        {
            var image = await _productService.GetImageByID(imageID);
            if (image == null)
                return BadRequest($"Không tìm thấy sản phẩm có ID: {productID}");
            return Ok(image);
        }
        //
        [HttpPost("{productID}/images")]
        public async Task<IActionResult> CreateImage(int productID,[FromForm] ProductImageUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var imageID = await _productService.UpdateImage(productID, request);
            if (imageID == 0)
                return BadRequest();

            var image = await _productService.GetImageByID(imageID);

            return CreatedAtAction(nameof(GetImageByID), new { id = imageID }, image);
        }
        //
        [HttpPut("{productID}/images/{imageID}")]
        public async Task<IActionResult> UpdateImage(int imageID,[FromForm] ProductImageUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _productService.UpdateImage(imageID, request);
            if (result == 0)
                return BadRequest();           

            return Ok();
        }
        [HttpDelete("{productID}/images/{imageID}")]
        public async Task<IActionResult> RemoveImage(int imageID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _productService.RemoveImages(imageID);
            if (result == 0)
                return BadRequest();

            return Ok();
        }
    }
}
