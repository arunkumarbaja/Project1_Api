using DAL.Data;
using Domain.Models;
using DTO.CategoryDto;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Project1.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL.ECommerceServices.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CategoryService> _logger;

        public CategoryService(ApplicationDbContext context, ILogger<CategoryService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            _logger.LogInformation("Retrieving all categories.");
            var categories = await _context.Categories.Include(c => c.Products).ToListAsync();
            _logger.LogInformation($"Retrieved {categories.Count} categories.");

            return categories.Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                ProductCount = c.Products.Count
            });
        }

        public async Task<CategoryDto?> GetCategoryByIdAsync(Guid id)
        {
            _logger.LogInformation("Retrieving category with ID: {Id}", id);
            var c = await _context.Categories.Include(c => c.Products)
                                             .FirstOrDefaultAsync(c => c.Id == id);

            if (c == null)
            {
                _logger.LogWarning("Category with ID: {Id} not found.", id);
                return null;
            }

            _logger.LogInformation("Category with ID: {Id} retrieved.", id);
            return new CategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                ProductCount = c.Products.Count
            };
        }

        public async Task<CategoryDto> AddCategoryAsync(CreateCategoryDto dto)
        {
            _logger.LogInformation("Adding new category: {Name}", dto.Name);
            var category = new Category
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Description = dto.Description
            };

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            _logger.LogInformation("Category {Name} added with ID: {Id}", category.Name, category.Id);

            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                ProductCount = 0
            };
        }

        public async Task<bool> UpdateCategoryAsync(UpdateCategoryDto dto)
        {
            _logger.LogInformation("Updating category with ID: {Id}", dto.Id);
            var category = await _context.Categories.FindAsync(dto.Id);
            if (category == null)
            {
                _logger.LogWarning("Category with ID: {Id} not found for update.", dto.Id);
                return false;
            }

            category.Name = dto.Name;
            category.Description = dto.Description;

            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            _logger.LogInformation("Category with ID: {Id} updated.", dto.Id);
            return true;
        }

        public async Task<bool> DeleteCategoryAsync(Guid id)
        {
            _logger.LogInformation("Deleting category with ID: {Id}", id);
            var category = await _context.Categories.Include(c => c.Products)
                                                    .FirstOrDefaultAsync(c => c.Id == id);

            if (category == null)
            {
                _logger.LogWarning("Category with ID: {Id} not found for deletion.", id);
                return false;
            }

            if (category.Products.Any())
            {
                _logger.LogError("Cannot delete category with ID: {Id} because it has products.", id);
                throw new InvalidOperationException("Cannot delete category with existing products.");
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            _logger.LogInformation("Category with ID: {Id} deleted.", id);
            return true;
        }

        public async Task<bool> CategoryExistsAsync(Guid id)
        {
            var exists = await _context.Categories.AnyAsync(c => c.Id == id);
            _logger.LogInformation("Category exists check for ID: {Id} - {Exists}", id, exists);
            return exists;
        }
    }
}
