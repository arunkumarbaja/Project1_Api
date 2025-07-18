using BBL.ECommerceServices.ProductService;
using DAL.Data;
using Domain.Models;
using DTO.ProductDTO;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST.ECommerceServiceTest
{
    public class ProductTest
    {
        public ApplicationDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var context = new ApplicationDbContext(options);

            return context;
        }



        [Fact]
        public async Task AddProductAsync_ShouldAddAndReturnProduct()
        {
            var _context = GetDbContext();
            var _service = new ProductService(_context, null);
            // Arrange
            var category = new Category { Id = Guid.NewGuid(), Name = "Electronics", Description = "Gadgets" };
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            var dto = new CreateProductDto
            {
                Name = "Phone",
                Description = "Smartphone",
                Price = 500,
                Sku = "PH001",
                StockQuantity = 10,
                IsAvailable = true,
                ImageUrl = "img.png",
                CategoryId = category.Id
            };

            // Act
            var result = await _service.AddProductAsync(dto);

            // Assert
            result.Should().NotBeNull();
            result.Name.Should().Be("Phone");
            result.CategoryId.Should().Be(category.Id);
        }


        [Fact]
        public async Task GetAllProductsAsync_ShouldReturnAllPeoducts()
        {
            // Arrange
            var _context = GetDbContext();
            var productService = new ProductService(_context, null);

            var categoty =
                new Domain.Models.Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Test Category",
                    Description = "Test Description"
                };

            _context.Categories.Add(categoty);

           await _context.Products.AddRangeAsync(
                new List<Product>
                 {
                    new Product
                    {
                    Id = Guid.NewGuid(),
                    Name = "Test Product",
                    Description = "Test Description",
                    Price = 100.00m,
                    Sku = "TEST-SKU-001",
                    StockQuantity = 10,
                    IsAvailable = true,
                    ImageUrl = "http://example.com/image.jpg",
                    CategoryId = categoty.Id,
                    DateCreated = DateTime.UtcNow
                   },
                new Product
                  {
                    Id=Guid.NewGuid(),
                    Name="test",
                    Description = "Test Description",
                    Price = 100.00m,
                    Sku = "TEST-SKU-002",
                    StockQuantity = 20,
                    IsAvailable = true,
                    ImageUrl = "http://example.com/image1.jpg",
                    CategoryId = categoty.Id,
                    DateCreated = DateTime.UtcNow
                  }
                    });
            await _context.SaveChangesAsync();

            // Act
            var result = await productService.GetAllProductsAsync();

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(2);

        }

        [Fact]
        public async Task GetProductByIdAsync_ShouldReturnProduct()
        {
            var _context = GetDbContext();
            var productService = new ProductService(_context, null);
            var _service = productService;

            var category = new Category
            {
                Id = Guid.NewGuid(),
                Name = "Computers",
                Description = "All about computers"
            };

            _context.Categories.Add(category);

            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Laptop",
                Description = "Gaming laptop",
                Price = 1000,
                Sku = "LT100",
                StockQuantity = 5,
                IsAvailable = true,
                CategoryId = category.Id,
                ImageUrl = "http://example.com/laptop.jpg",

                
            };
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            // Act
            var result = await _service.GetProductByIdAsync(product.Id);

            // Assert
            result.Should().NotBeNull();
            result!.Name.Should().Be("Laptop");
        }

        [Fact]
        public async Task UpdateProductAsync_ShouldUpdateSuccessfully()
        {
            var _context = GetDbContext();
            var productService = new ProductService(_context, null);
            var _service = productService;
            // Arrange
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Tablet",
                Description = "Android Tablet",
                Price = 200,
                Sku = "TAB01",
                StockQuantity = 3,
                IsAvailable = true,
                CategoryId = Guid.NewGuid(),
                ImageUrl = "http://example.com/tablet.jpg"
            };
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            var updateDto = new UpdateProductDto
            {
                Id = product.Id,
                Name = "Tablet Updated",
                Description = "Updated Description",
                Price = 250,
                Sku = "TAB02",
                StockQuantity = 5,
                IsAvailable = false,
                CategoryId = product.CategoryId,
                ImageUrl = "http://example.com/tablet_updated.jpg"
            };

            // Act
            var result = await _service.UpdateProductAsync(updateDto);

            // Assert
            result.Should().BeTrue();
            var updated = await _context.Products.FindAsync(product.Id);
            updated!.Name.Should().Be("Tablet Updated");
        }

        [Fact]
        public async Task DeleteProductAsync_ShouldRemoveProduct()
        {
            var _context = GetDbContext();
            var productService = new ProductService(_context, null);
            var _service = productService;
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = "TV",
                Price = 300,
                CategoryId = Guid.NewGuid(),
                IsAvailable = true,
                DateCreated = DateTime.UtcNow,
                Description = "Smart TV",
                Sku = "TV001",
                ImageUrl= "http://example.com/tv.jpg"
            };
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            // Act
            var result = await _service.DeleteProductAsync(product.Id);

            // Assert
            result.Should().BeTrue();
            (await _context.Products.FindAsync(product.Id)).Should().BeNull();
        }

        [Fact]
        public async Task IsProductAvailable_ShouldReturnCorrectStatus()
        {
            var _context = GetDbContext();
            var productService = new ProductService(_context, null);
            var _service = productService;
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Camera",
                IsAvailable = true,
                CategoryId = Guid.NewGuid(),
                Description = "Digital Camera",
                ImageUrl = "http://example.com/camera.jpg",
                Sku = "CAM001",
            };
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            var status = await _service.IsProductAvailable(product.Id);

            status.Should().BeTrue();
        }

        [Fact]
        public async Task GetProductStockAsync_ShouldReturnQuantity()
        {
            var _context = GetDbContext();
            var productService = new ProductService(_context, null);
            var _service = productService;
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Speaker",
                StockQuantity = 15,
                CategoryId = Guid.NewGuid(),
                ImageUrl = "http://example.com/speaker.jpg",
                Description = "Bluetooth Speaker",
                Sku = "SPK001"
            };
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            var stock = await _service.GetProductStockAsync(product.Id);

            stock.Should().Be(15);
        }
    }

}

