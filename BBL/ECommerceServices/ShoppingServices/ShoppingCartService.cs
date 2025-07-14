using DAL.Data;
using Domain;
using Domain.Models;
using DTO.ShoppingCart;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL.ECommerceServices.ShoppingServices
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly ApplicationDbContext _context;

        public ShoppingCartService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddToCartAsync(AddToCartDto dto)
        {
            var product = await _context.Products.FindAsync(dto.ProductId);
            if (product == null || !product.IsAvailable)
                throw new Exception("Product not available.");

            var existingItem = await _context.ShoppingCartItems
                .FirstOrDefaultAsync(x => x.UserId == dto.UserId && x.ProductId == dto.ProductId);

            if (existingItem != null)
            {
                existingItem.Quantity += dto.Quantity;
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
            }

            await _context.SaveChangesAsync();
        }

        public async Task<List<CartItemDto>> GetCartItemsAsync(Guid userId)
        {
            var items = await _context.ShoppingCartItems
                .Include(x => x.Product)
                .Where(x => x.UserId == userId)
                .ToListAsync();

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
            var item = await _context.ShoppingCartItems.FirstOrDefaultAsync(i => i.Id == itemId && i.UserId == userId);
            if (item != null)
            {
                _context.ShoppingCartItems.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task ClearCartAsync(Guid userId)
        {
            var items = await _context.ShoppingCartItems.Where(x => x.UserId == userId).ToListAsync();
            _context.ShoppingCartItems.RemoveRange(items);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IncreaseQuantityAsync(Guid itemId, Guid userId)
        {
            var item = await _context.ShoppingCartItems.FirstOrDefaultAsync(i => i.Id == itemId && i.UserId == userId);

            if (item == null)
                return false;

            item.Quantity += 1;
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<bool> DecreaseQuantityAsync(Guid itemId, Guid userId)
        {
            var item = await _context.ShoppingCartItems.FirstOrDefaultAsync(i => i.Id == itemId && i.UserId == userId);

            if (item == null)
                return false;

            item.Quantity -= 1;
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
