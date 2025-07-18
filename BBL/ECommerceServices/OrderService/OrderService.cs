using DAL.Data;
using Domain.Models;
using DTO.OrderDto;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<OrderService> _logger;

        public OrderService(ApplicationDbContext context, ILogger<OrderService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<OrderResponseDto> CreateOrderAsync(CreateOrderDto dto)
        {
            _logger.LogInformation("Starting CreateOrderAsync for UserId: {UserId}", dto.UserId);

            decimal totalAmount = 0;
            var orderItems = new List<OrderItem>();

            foreach (var itemDto in dto.OrderItems)
            {
                var product = await _context.Products.FindAsync(itemDto.ProductId);
                if (product == null || !product.IsAvailable)
                {
                    _logger.LogWarning("Product not available: {ProductId}", itemDto.ProductId);
                    throw new Exception($"Product not available: {itemDto.ProductId}");
                }

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

                _logger.LogInformation("Added OrderItem for ProductId: {ProductId}, Quantity: {Quantity}", product.Id, itemDto.Quantity);
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
                PaymentTransactionId = Guid.NewGuid().ToString()
            };

            await _context.Orders.AddAsync(order);

            try
            {
                int a = await _context.SaveChangesAsync();
                if (a <= 0)
                {
                    _logger.LogWarning("No changes were saved to the database for OrderId: {OrderId}", order.Id);
                }
                else
                {
                    _logger.LogInformation("Order created successfully. OrderId: {OrderId}", order.Id);
                }
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Database error while creating order. OrderId: {OrderId}", order.Id);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error while creating order. OrderId: {OrderId}", order.Id);
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
            _logger.LogInformation("Fetching order by Id: {OrderId}", orderId);
            var order = await _context.Orders.FindAsync(orderId);
            if (order == null)
            {
                _logger.LogWarning("Order not found. OrderId: {OrderId}", orderId);
                return null!;
            }

            _logger.LogInformation("Order found. OrderId: {OrderId}", orderId);
            return order;
        }

        public async Task<List<OrderResponseDto>> GetOrdersByUserIdAsync(Guid userId)
        {
            _logger.LogInformation("Fetching orders for UserId: {UserId}", userId);
            var orders = await _context.Orders
                .Where(o => o.UserId == userId)
                .Select(order => new OrderResponseDto
                {
                    OrderId = order.Id,
                    OrderDate = order.OrderDate,
                    TotalAmount = order.TotalAmount,
                    Status = order.Status
                })
                .ToListAsync();

            _logger.LogInformation("Found {OrderCount} orders for UserId: {UserId}", orders.Count, userId);
            return orders;
        }
    }

}
