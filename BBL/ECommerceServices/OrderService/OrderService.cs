using DAL.Data;
using Domain.Models;
using DTO.OrderDto;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL.ECommerceServices.OrderService
{
    // 2. OrderService Implementation
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<OrderResponseDto> CreateOrderAsync(CreateOrderDto dto)
        {
            decimal totalAmount = 0;
            var orderItems = new List<OrderItem>();

            foreach (var itemDto in dto.OrderItems)
            {
                var product = await _context.Products.FindAsync(itemDto.ProductId);
                if (product == null || !product.IsAvailable)
                    throw new Exception($"Product not available: {itemDto.ProductId}");

                var orderItem = new OrderItem
                {
                    Id = Guid.NewGuid(),
                    ProductId = product.Id,
                    Quantity = itemDto.Quantity,
                    UnitPriceAtPurchase = product.Price
                };

                product.StockQuantity -= 1;

                totalAmount += itemDto.Quantity * product.Price;
                orderItems.Add(orderItem);
            }

            var order = new Order
            {
                Id = Guid.NewGuid(),
                UserId = dto.UserId,
                OrderDate = DateTime.UtcNow,
                Status = Domain.Models.OrderStatus.Pending,
                TotalAmount = totalAmount,
                ShippingAddressStreet = dto.ShippingAddressStreet,
                ShippingAddressCity = dto.ShippingAddressCity,
                ShippingAddressState = dto.ShippingAddressState,
                ShippingAddressPostalCode = dto.ShippingAddressPostalCode,
                ShippingAddressCountry = dto.ShippingAddressCountry,
                OrderItems = orderItems,
                PaymentTransactionId=Guid.NewGuid().ToString()
            };

            await _context.Orders.AddAsync(order);

            try
            {
                int a = await _context.SaveChangesAsync();
                if (a <= 0)
                {
                    Console.WriteLine("⚠ No changes were saved to the database.");
                }
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"❌ Database error: {ex.InnerException?.Message ?? ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Unexpected error: {ex.Message}");
                throw;
            }

            return new OrderResponseDto
            {
                OrderId = order.Id,
                OrderDate = order.OrderDate,
                TotalAmount = order.TotalAmount,
                Status = order.Status
            };
        }

        public async Task<Order> GetOrderByIdAsync(Guid orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order == null)
                return null!;

            return  order;
            
        }

        public async Task<List<OrderResponseDto>> GetOrdersByUserIdAsync(Guid userId)
        {
            return await _context.Orders
                .Where(o => o.UserId == userId)
                .Select(order => new OrderResponseDto
                {
                    OrderId = order.Id,
                    OrderDate = order.OrderDate,
                    TotalAmount = order.TotalAmount,
                    Status = order.Status
                })
                .ToListAsync();
        }
    }

}
