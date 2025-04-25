using Microsoft.AspNetCore.Mvc;
using Service.Abstraction;
using Shared.Dtos;

namespace Presentation
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController(IServiceManager serviceManager): ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProducts()
        {
            var products = await serviceManager.ProductService.GetAllAsync();
            return Ok(products);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {
            var product = await serviceManager.ProductService.GetByIdAsync(id);
            return Ok(product);
        }
    }
}
