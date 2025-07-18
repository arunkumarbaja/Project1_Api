using BBL.ECommerceServices.CategoryService;
using DTO.CategoryDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Project1_Api.Controllers.EcomerceApis
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly ILogger<CategoriesController> _logger;

        public CategoriesController(ICategoryService categoryService, ILogger<CategoriesController> logger)
        {
            _categoryService = categoryService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Fetching all categories");
            try
            {
                var categories = await _categoryService.GetAllCategoriesAsync();
                _logger.LogInformation("Fetched {Count} categories", categories?.Count() ?? 0);
                return Ok(categories);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error fetching all categories");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            _logger.LogInformation("Fetching category by id: {Id}", id);
            try
            {
                var category = await _categoryService.GetCategoryByIdAsync(id);
                if (category == null)
                {
                    _logger.LogWarning("Category not found: {Id}", id);
                    return NotFound();
                }

                _logger.LogInformation("Fetched category: {Id}", id);
                return Ok(category);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error fetching category by id: {Id}", id);
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] CreateCategoryDto dto)
        {
            _logger.LogInformation("Creating new category: {Name}", dto.Name);
            try
            {
                var created = await _categoryService.AddCategoryAsync(dto);
                _logger.LogInformation("Created category: {Id}", created.Id);
                return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error creating category");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCategoryDto dto)
        {
            _logger.LogInformation("Updating category: {Id}", id);
            try
            {
                var updated = await _categoryService.UpdateCategoryAsync(dto);
                if (!updated)
                {
                    _logger.LogWarning("Category not found for update: {Id}", id);
                    return NotFound();
                }

                _logger.LogInformation("Updated category: {Id}", id);
                return NoContent();
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error updating category: {Id}", id);
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            _logger.LogInformation("Deleting category: {Id}", id);
            try
            {
                var deleted = await _categoryService.DeleteCategoryAsync(id);
                if (!deleted)
                {
                    _logger.LogWarning("Category not found for deletion: {Id}", id);
                    return NotFound();
                }

                _logger.LogInformation("Deleted category: {Id}", id);
                return NoContent();
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error deleting category: {Id}", id);
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
