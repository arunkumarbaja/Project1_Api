using DAL.Data;
using Domain.Models;
using DTO.ProductDTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<ProductService> _logger;

        public ProductService(ApplicationDbContext context, ILogger<ProductService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            _logger.LogInformation("Getting all products.");
            var products = await _context.Products.Include(p => p.Category).ToListAsync();

            _logger.LogInformation("Retrieved {Count} products.", products.Count);
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
            _logger.LogInformation("Getting product by Id: {Id}", id);
            var p = await _context.Products.Include(p => p.Category)
                                           .FirstOrDefaultAsync(p => p.Id == id);

            if (p == null)
            {
                _logger.LogWarning("Product with Id {Id} not found.", id);
                return null;
            }

            _logger.LogInformation("Product with Id {Id} found.", id);
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
            _logger.LogInformation("Getting products by category Id: {CategoryId}", categoryId);
            var products = await _context.Products
                .Include(p => p.Category)
                .Where(p => p.CategoryId == categoryId)
                .ToListAsync();

            _logger.LogInformation("Retrieved {Count} products for category {CategoryId}.", products.Count, categoryId);
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
            _logger.LogInformation("Adding new product: {Name}", dto.Name);
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

            _logger.LogInformation("Product {Name} added with Id {Id}.", product.Name, product.Id);
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
            _logger.LogInformation("Updating product with Id: {Id}", dto.Id);
            var product = await _context.Products.FindAsync(dto.Id);
            if (product == null)
            {
                _logger.LogWarning("Product with Id {Id} not found for update.", dto.Id);
                return false;
            }

            product.Name = dto.Name;
            product.Description = dto.Description;
            product.Price = dto.Price;
            product.Sku = dto.Sku;
            product.StockQuantity = dto.StockQuantity;
            product.IsAvailable = dto.IsAvailable;
            product.CategoryId = dto.CategoryId;

            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Product with Id {Id} updated.", dto.Id);
            return true;
        }

        public async Task<bool> DeleteProductAsync(Guid id)
        {
            _logger.LogInformation("Deleting product with Id: {Id}", id);
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                _logger.LogWarning("Product with Id {Id} not found for deletion.", id);
                return false;
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            _logger.LogInformation("Product with Id {Id} deleted.", id);
            return true;
        }

        public async Task<bool> IsProductAvailable(Guid id)
        {
            _logger.LogInformation("Checking availability for product Id: {Id}", id);
            var product = await _context.Products.FindAsync(id);
            bool available = product?.IsAvailable ?? false;
            _logger.LogInformation("Product Id {Id} is available: {Available}", id, available);
            return available;
        }

        public async Task<int> GetProductStockAsync(Guid id)
        {
            _logger.LogInformation("Getting stock quantity for product Id: {Id}", id);
            var product = await _context.Products.FindAsync(id);
            int stock = product?.StockQuantity ?? 0;
            _logger.LogInformation("Product Id {Id} has stock quantity: {Stock}", id, stock);
            return stock;
        }
    }
}
