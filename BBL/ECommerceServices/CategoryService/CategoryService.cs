using DAL.Data;
using Domain.Models;
using DTO.CategoryDto;
using Microsoft.EntityFrameworkCore;
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

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            var categories = await _context.Categories.Include(c => c.Products).ToListAsync();

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
            var c = await _context.Categories.Include(c => c.Products)
                                             .FirstOrDefaultAsync(c => c.Id == id);

            if (c == null) 
                return null;

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
            var category = new Category
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Description = dto.Description
            };

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

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
            var category = await _context.Categories.FindAsync(dto.Id);
            if (category == null) return false;

            category.Name = dto.Name;
            category.Description = dto.Description;

            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCategoryAsync(Guid id)
        {
            var category = await _context.Categories.Include(c => c.Products)
                                                    .FirstOrDefaultAsync(c => c.Id == id);

            if (category == null) return false;

            // Optional: Check if category has products before deleting
            if (category.Products.Any())
                throw new InvalidOperationException("Cannot delete category with existing products.");

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CategoryExistsAsync(Guid id)
        {
            return await _context.Categories.AnyAsync(c => c.Id == id);
        }
    }
}
