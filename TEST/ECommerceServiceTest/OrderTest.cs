using BBL.ECommerceServices.OrderService;
using DAL.Data;
using Domain.Models;
using DTO.OrderDto;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST.ECommerceServiceTest
{
    public class OrderTest
    {

        private readonly ILogger<OrderTest> _logger;
        public OrderTest(ILogger<OrderTest> logger) 
        {
          _logger = logger;
        }


        public ApplicationDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var context = new ApplicationDbContext(options);
            context.Database.EnsureCreated();

            return context;
        }


        [Fact]
        public async Task CreateOrderAsync_ShouldCreateOrder_ReturnOrderResposneDto()
        {
            //Arrange
            var context = GetDbContext();   
            var orderService = new OrderService(context,null);
            var createOrderDto = new CreateOrderDto
                            {
                UserId = Guid.NewGuid(),
                ShippingAddressStreet = "123 Main St",
                ShippingAddressCity = "Test City",
                ShippingAddressState = "Test State",
                ShippingAddressCountry= "Test Country",
                ShippingAddressPostalCode = "12345",
                OrderItems = new List<OrderItemDto>
                {
                    new OrderItemDto { ProductId = Guid.NewGuid(), Quantity = 2 }
                }
            };

                  // Add a product to the in-memory database for testing
            var product = new Product
            {
                Id = createOrderDto.OrderItems[0].ProductId,
                Name = "Test Product",
                Price = 10.00m,
                StockQuantity = 10,
                IsAvailable = true,
                Description="Test Product Description",
                ImageUrl = "http://example.com/image.jpg",
                Sku= "TEST-PRODUCT-001",

            };
            context.Products.Add(product);
            await context.SaveChangesAsync();

            //Act
            var result = await orderService.CreateOrderAsync(createOrderDto);

            //Assert

            result.Should().NotBeNull();
            result.Should().BeOfType<OrderResponseDto>();
            result.Status.Should().Be(Domain.Models.OrderStatus.Pending);
            result.TotalAmount.Should().Be(20.00m); // 2 * 10.00
        }
        [Fact]
        public async Task GetOrderByIdAsync_ShouldReturnCorrectOrder()
        {
            var _context = GetDbContext();
            var _service = new OrderService(_context,null);
            // Arrange
            var order = new Order
            {
                Id = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                TotalAmount = 300,
                Status = OrderStatus.Paid,
                OrderDate = DateTime.UtcNow,
                PaymentTransactionId=Guid.NewGuid().ToString(),
                ShippingAddressStreet = "123 Main St",
                ShippingAddressCity = "Test City",
                ShippingAddressState = "Test State",
                ShippingAddressPostalCode = "12345",
                ShippingAddressCountry = "Test Country"

            };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            // Act
            var result = await _service.GetOrderByIdAsync(order.Id);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(order.Id);
            result.TotalAmount.Should().Be(300);

        }

        [Fact]
        public async Task GetOrdersByUserIdAsync_ShouldReturnUserOrders()
        {
            var _context = GetDbContext();
            var _service = new OrderService(_context,null);

            // Arrange
            var userId = Guid.NewGuid();
            await _context.Orders.AddRangeAsync(
                new Order {
                    Id = Guid.NewGuid(), UserId = userId, TotalAmount = 100, OrderDate = DateTime.UtcNow,ShippingAddressStreet="xyz",
                    ShippingAddressCity="abc",ShippingAddressState="def",ShippingAddressPostalCode="12345",ShippingAddressCountry= "USA",
                    PaymentTransactionId= Guid.NewGuid().ToString()
                },
                new Order { Id = Guid.NewGuid(), UserId = userId, TotalAmount = 200, OrderDate = DateTime.UtcNow,ShippingAddressStreet="xxx",
                    ShippingAddressCity="yyy",
                    ShippingAddressState = "def",
                    ShippingAddressPostalCode = "12345",
                    ShippingAddressCountry = "USA",
                    PaymentTransactionId= Guid.NewGuid().ToString()
                }
            );
            await _context.SaveChangesAsync();

            // Act
            var result = await _service.GetOrdersByUserIdAsync(userId);

            // Assert
            result.Should().HaveCount(2);
            result.All(o => o.TotalAmount > 0).Should().BeTrue();
        }

        [Fact]
        public async Task CreateOrderAsync_ShouldThrow_WhenProductNotAvailable()
        {
            var _context = GetDbContext();
            var _service = new OrderService(_context,null);

            // Arrange
            var unavailableProductId = Guid.NewGuid();

            var dto = new CreateOrderDto
            {
                UserId = Guid.NewGuid(),
                ShippingAddressStreet = "Street",
                ShippingAddressCity = "City",
                ShippingAddressState = "State",
                ShippingAddressPostalCode = "12345",
                ShippingAddressCountry = "Country",
                OrderItems = new List<OrderItemDto>
            {
                new OrderItemDto { ProductId = unavailableProductId, Quantity = 1 }
            }
            };

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _service.CreateOrderAsync(dto));
        }
    }
}
