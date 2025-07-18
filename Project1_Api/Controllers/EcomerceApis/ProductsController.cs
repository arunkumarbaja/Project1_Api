using BBL.ECommerceServices.ProductService;
using DTO.ProductDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Project1_Api.Controllers.EcomerceControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IProductService productService, ILogger<ProductsController> logger)
        {
            _productService = productService;
            _logger = logger;
        }
            
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var products = await _productService.GetAllProductsAsync();
                return Ok(products);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error fetching all products");
                return StatusCode(500, "An error occurred while fetching products.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var product = await _productService.GetProductByIdAsync(id);
                if (product == null)
                    return NotFound();

                return Ok(product);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, $"Error fetching product with ID {id}");
                return StatusCode(500, "An error occurred while retrieving the product.");
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] CreateProductDto dto)
        {
            try
            {
                var created = await _productService.AddProductAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error creating product");
                return StatusCode(500, "An error occurred while creating the product.");
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateProductDto dto)
        {
            try
            {
                var updated = await _productService.UpdateProductAsync(dto);
                if (!updated)
                    return NotFound();

                return NoContent();
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, $"Error updating product with ID {id}");
                return StatusCode(500, "An error occurred while updating the product.");
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var deleted = await _productService.DeleteProductAsync(id);
                if (!deleted)
                    return NotFound();

                return NoContent();
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, $"Error deleting product with ID {id}");
                return StatusCode(500, "An error occurred while deleting the product.");
            }
        }
    }
}
