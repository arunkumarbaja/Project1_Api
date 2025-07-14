using DAL.Data;
using Domain.Models;
using DTO.ProductDTO;
using Microsoft.EntityFrameworkCore;
using Project1.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL.ECommerceServices.ProductService
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var products = await _context.Products.Include(p => p.Category).ToListAsync();

            return products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Sku = p.Sku,
                StockQuantity = p.StockQuantity,
                IsAvailable = p.IsAvailable,
                ImageUrl = p.ImageUrl,
                CategoryId = p.CategoryId,
                CategoryName = p.Category?.Name,
                DateCreated = p.DateCreated
            });
        }

        public async Task<ProductDto?> GetProductByIdAsync(Guid id)
        {
            var p = await _context.Products.Include(p => p.Category)
                                           .FirstOrDefaultAsync(p => p.Id == id);

            if (p == null)
                return null;

            return new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Sku = p.Sku,
                StockQuantity = p.StockQuantity,
                IsAvailable = p.IsAvailable,
                ImageUrl = p.ImageUrl,
                CategoryId = p.CategoryId,
                CategoryName = p.Category?.Name,
                DateCreated = p.DateCreated
            };
        }

        public async Task<IEnumerable<ProductDto>> GetProductsByCategoryAsync(Guid categoryId)
        {
            var products = await _context.Products
                .Include(p => p.Category)
                .Where(p => p.CategoryId == categoryId)
                .ToListAsync();

            return products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Sku = p.Sku,
                StockQuantity = p.StockQuantity,
                IsAvailable = p.IsAvailable,
                ImageUrl = p.ImageUrl,
                CategoryId = p.CategoryId,
                CategoryName = p.Category?.Name,
                DateCreated = p.DateCreated
            });
        }

        public async Task<ProductDto> AddProductAsync(CreateProductDto dto)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                Sku = dto.Sku,
                StockQuantity = dto.StockQuantity,
                IsAvailable = dto.IsAvailable,
                ImageUrl = dto.ImageUrl,
                CategoryId = dto.CategoryId,
                DateCreated = DateTime.UtcNow
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Sku = product.Sku,
                StockQuantity = product.StockQuantity,
                IsAvailable = product.IsAvailable,
                ImageUrl = product.ImageUrl,
                CategoryId = product.CategoryId,
                DateCreated = product.DateCreated
            };
        }

        public async Task<bool> UpdateProductAsync(UpdateProductDto dto)
        {
            var product = await _context.Products.FindAsync(dto.Id);
            if (product == null)
                return false;

            product.Name = dto.Name;
            product.Description = dto.Description;
            product.Price = dto.Price;
            product.Sku = dto.Sku;
            product.StockQuantity = dto.StockQuantity;
            product.IsAvailable = dto.IsAvailable;
            product.CategoryId = dto.CategoryId;

            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteProductAsync(Guid id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> IsProductAvailable(Guid id)
        {
            var product = await _context.Products.FindAsync(id);
            return product?.IsAvailable ?? false;
        }

        public async Task<int> GetProductStockAsync(Guid id)
        {
            var product = await _context.Products.FindAsync(id);
            return product?.StockQuantity ?? 0;
        }
    }
}
