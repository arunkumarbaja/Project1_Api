using DAL.Data;
using Domain;
using Domain.Models;
using DTO.ShoppingCart;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL.ECommerceServices.ShoppingServices
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ShoppingCartService> _logger;

        public ShoppingCartService(ApplicationDbContext context, ILogger<ShoppingCartService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task AddToCartAsync(AddToCartDto dto)
        {
            _logger.LogInformation($"Adding product {dto.ProductId} to cart for user {dto.UserId} (qty: {dto.Quantity})");
            var product = await _context.Products.FindAsync(dto.ProductId);
            if (product == null || !product.IsAvailable)
            {
                _logger.LogWarning("Product {ProductId} not available for user {UserId}", dto.ProductId, dto.UserId);
                throw new Exception("Product not available.");
            }

            var existingItem = await _context.ShoppingCartItems
                .FirstOrDefaultAsync(x => x.UserId == dto.UserId && x.ProductId == dto.ProductId);

            if (existingItem != null)
            {
                existingItem.Quantity += dto.Quantity;
                _logger.LogInformation("Increased quantity of product {ProductId} in cart for user {UserId} to {Quantity}", dto.ProductId, dto.UserId, existingItem.Quantity);
            }
            else
            {
                var newItem = new ShoppingCartItem
                {
                    Id = Guid.NewGuid(),
                    UserId = dto.UserId,
                    ProductId = dto.ProductId,
                    Quantity = dto.Quantity
                };
                await _context.ShoppingCartItems.AddAsync(newItem);
                _logger.LogInformation("Added new product {ProductId} to cart for user {UserId} (qty: {Quantity})", dto.ProductId, dto.UserId, dto.Quantity);
            }

            await _context.SaveChangesAsync();
            _logger.LogInformation("Cart updated for user {UserId}", dto.UserId);
        }

        public async Task<List<CartItemDto>> GetCartItemsAsync(Guid userId)
        {
            _logger.LogInformation("Retrieving cart items for user {UserId}", userId);
            var items = await _context.ShoppingCartItems
                .Include(x => x.Product)
                .Where(x => x.UserId == userId)
                .ToListAsync();

            _logger.LogInformation("Found {Count} cart items for user {UserId}", items.Count, userId);
            return items.Select(item => new CartItemDto
            {
                Id = item.Id,
                ProductId = item.ProductId,
                ProductName = item.Product.Name,
                Quantity = item.Quantity,
                Price = item.Product.Price
            }).ToList();
        }

        public async Task RemoveFromCartAsync(Guid itemId, Guid userId)
        {
            _logger.LogInformation("Removing item {ItemId} from cart for user {UserId}", itemId, userId);
            var item = await _context.ShoppingCartItems.FirstOrDefaultAsync(i => i.Id == itemId && i.UserId == userId);
            if (item != null)
            {
                _context.ShoppingCartItems.Remove(item);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Item {ItemId} removed from cart for user {UserId}", itemId, userId);
            }
            else
            {
                _logger.LogWarning("Item {ItemId} not found in cart for user {UserId}", itemId, userId);
            }
        }

        public async Task ClearCartAsync(Guid userId)
        {
            _logger.LogInformation("Clearing cart for user {UserId}", userId);
            var items = await _context.ShoppingCartItems.Where(x => x.UserId == userId).ToListAsync();
            _context.ShoppingCartItems.RemoveRange(items);
            await _context.SaveChangesAsync();
            _logger.LogInformation("Cart cleared for user {UserId}", userId);
        }

        public async Task<bool> IncreaseQuantityAsync(Guid itemId, Guid userId)
        {
            _logger.LogInformation("Increasing quantity for item {ItemId} in cart for user {UserId}", itemId, userId);
            var item = await _context.ShoppingCartItems.FirstOrDefaultAsync(i => i.Id == itemId && i.UserId == userId);

            if (item == null)
            {
                _logger.LogWarning("Item {ItemId} not found in cart for user {UserId}", itemId, userId);
                return false;
            }

            item.Quantity += 1;
            await _context.SaveChangesAsync();
            _logger.LogInformation("Quantity increased for item {ItemId} in cart for user {UserId} to {Quantity}", itemId, userId, item.Quantity);
            return true;
        }

        public async Task<bool> DecreaseQuantityAsync(Guid itemId, Guid userId)
        {
            _logger.LogInformation("Decreasing quantity for item {ItemId} in cart for user {UserId}", itemId, userId);
            var item = await _context.ShoppingCartItems.FirstOrDefaultAsync(i => i.Id == itemId && i.UserId == userId);

            if (item == null)
            {
                _logger.LogWarning("Item {ItemId} not found in cart for user {UserId}", itemId, userId);
                return false;
            }

            item.Quantity -= 1;
            await _context.SaveChangesAsync();
            _logger.LogInformation("Quantity decreased for item {ItemId} in cart for user {UserId} to {Quantity}", itemId, userId, item.Quantity);
            return true;
        }
    }

}
