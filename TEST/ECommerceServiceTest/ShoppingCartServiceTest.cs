using BBL.ECommerceServices.ShoppingServices;
using DAL.Data;
using Domain.Models;
using DTO.ShoppingCart;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST.ECommerceServiceTest
{
    public class ShoppingCartServiceTest
    {
        private readonly ApplicationDbContext _context;
        private readonly ShoppingCartService _service;

        public ShoppingCartServiceTest()
        {
            _context = GetDbContext();
            _service = new ShoppingCartService(_context);
        }

        private ApplicationDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new ApplicationDbContext(options);
        }

        [Fact]
        public async Task AddToCartAsync_ShouldAddNewItem()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Test Product",
                Price = 100,
                IsAvailable = true,
                Description= "Test Description",
                ImageUrl= "/test.jpg",
                Sku = "TEST-SKU-001"
            };
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            var dto = new AddToCartDto
            {
                UserId = userId,
                ProductId = product.Id,
                Quantity = 2
            };

            // Act
            await _service.AddToCartAsync(dto);

            // Assert
            var cartItem = await _context.ShoppingCartItems.FirstOrDefaultAsync();
            cartItem.Should().NotBeNull();
            cartItem!.Quantity.Should().Be(2);
        }

        [Fact]
        public async Task AddToCartAsync_ShouldIncreaseQuantityIfExists()
        {
            var userId = Guid.NewGuid();
            var productId = Guid.NewGuid();

            await _context.Products.AddAsync(new Product { Id = productId, Name = "P1", Price = 10, IsAvailable = true ,Description="xxx",ImageUrl="/exaple.jpg",Sku="xx10"});
            await _context.ShoppingCartItems.AddAsync(new ShoppingCartItem
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                ProductId = productId,
                Quantity = 1
            });
            await _context.SaveChangesAsync();

            var dto = new AddToCartDto { UserId = userId, ProductId = productId, Quantity = 2 };

            // Act
            await _service.AddToCartAsync(dto);

            // Assert
            var item = await _context.ShoppingCartItems.FirstAsync();
            item.Quantity.Should().Be(3);
        }

        [Fact]
        public async Task GetCartItemsAsync_ShouldReturnItemsForUser()
        {
            var userId = Guid.NewGuid();
            var product = new Product { Id = Guid.NewGuid(), Name = "Product1", Price = 50, IsAvailable = true, Description="xx",Sku="xx10",ImageUrl="example.jpg" };
            await _context.Products.AddAsync(product);

            await _context.ShoppingCartItems.AddAsync(new ShoppingCartItem
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                ProductId = product.Id,
                Quantity = 1
            });
            await _context.SaveChangesAsync();

            // Act
            var result = await _service.GetCartItemsAsync(userId);

            // Assert
            result.Should().HaveCount(1);
            result.First().ProductName.Should().Be("Product1");
        }

        [Fact]
        public async Task RemoveFromCartAsync_ShouldRemoveItem()
        {
            var userId = Guid.NewGuid();
            var item = new ShoppingCartItem
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                ProductId = Guid.NewGuid(),
                Quantity = 1
            };
            await _context.ShoppingCartItems.AddAsync(item);
            await _context.SaveChangesAsync();

            // Act
            await _service.RemoveFromCartAsync(item.Id, userId);

            // Assert
            var exists = await _context.ShoppingCartItems.AnyAsync();
            exists.Should().BeFalse();
        }

        [Fact]
        public async Task ClearCartAsync_ShouldRemoveAllItems()
        {
            var userId = Guid.NewGuid();
            await _context.ShoppingCartItems.AddRangeAsync(
                new ShoppingCartItem { Id = Guid.NewGuid(), UserId = userId, ProductId = Guid.NewGuid(), Quantity = 1 },
                new ShoppingCartItem { Id = Guid.NewGuid(), UserId = userId, ProductId = Guid.NewGuid(), Quantity = 2 }
            );
            await _context.SaveChangesAsync();

            // Act
            await _service.ClearCartAsync(userId);

            // Assert
            (await _context.ShoppingCartItems.CountAsync()).Should().Be(0);
        }

        [Fact]
        public async Task IncreaseQuantityAsync_ShouldIncrementQuantity()
        {
            var userId = Guid.NewGuid();
            var item = new ShoppingCartItem { Id = Guid.NewGuid(), UserId = userId, ProductId = Guid.NewGuid(), Quantity = 1 };
            await _context.ShoppingCartItems.AddAsync(item);
            await _context.SaveChangesAsync();

            var result = await _service.IncreaseQuantityAsync(item.Id, userId);

            result.Should().BeTrue();
            (await _context.ShoppingCartItems.FindAsync(item.Id))!.Quantity.Should().Be(2);
        }

        [Fact]
        public async Task DecreaseQuantityAsync_ShouldDecrementQuantity()
        {
            var userId = Guid.NewGuid();
            var item = new ShoppingCartItem { Id = Guid.NewGuid(), UserId = userId, ProductId = Guid.NewGuid(), Quantity = 2 };
            await _context.ShoppingCartItems.AddAsync(item);
            await _context.SaveChangesAsync();

            var result = await _service.DecreaseQuantityAsync(item.Id, userId);

            result.Should().BeTrue();
            (await _context.ShoppingCartItems.FindAsync(item.Id))!.Quantity.Should().Be(1);
        }

        [Fact]
        public async Task AddToCartAsync_ShouldThrow_WhenProductNotAvailable()
        {
            // Arrange
            var productId = Guid.NewGuid();
            await _context.Products.AddAsync(new Product { Id = productId,Name="xxyy", IsAvailable = false, Description="xxx",ImageUrl="/xx.jpg",Sku="xx10" });
            await _context.SaveChangesAsync();

            var dto = new AddToCartDto { UserId = Guid.NewGuid(), ProductId = productId, Quantity = 1, };

            // Act
            Func<Task> act = async () => await _service.AddToCartAsync(dto);

            // Assert
            await act.Should().ThrowAsync<Exception>()
                .WithMessage("Product not available.");
        }
    }
}
