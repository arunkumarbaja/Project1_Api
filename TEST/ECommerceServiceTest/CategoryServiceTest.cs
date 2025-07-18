using BBL.ECommerceServices.CategoryService;
using DAL.Data;
using Domain.Models;
using DTO.CategoryDto;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;


namespace TEST.ECommerceServiceTest
{
    public class CategoryServiceTest
    {

        private ApplicationDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new ApplicationDbContext(options);
           // context.Database.EnsureCreated();

            return context;
        }

        [Fact]
        public async Task AddCategoryAsync_ShouldAddCategory()
        {
            // Arrange
            var context = GetDbContext();
            var service = new CategoryService(context, null);
            var dto = new CreateCategoryDto { Name = "Electronics", Description = "Devices" };

            // Act
            var result = await service.AddCategoryAsync(dto);

            // Assert
            var categoryInDb = await context.Categories.FirstOrDefaultAsync();
            categoryInDb.Should().NotBeNull();
            result.Name.Should().Be("Electronics");
        }

        [Fact]
        public async Task GetAllCategoriesAsync_ShouldReturnAll()
        {
            var context = GetDbContext();
            context.Categories.Add(new Category { Id = Guid.NewGuid(), Name = "Books", Description = "Readables" });
            await context.SaveChangesAsync();

            var service = new CategoryService(context, null);

            var result = await service.GetAllCategoriesAsync();

            result.Should().HaveCount(1);
            result.First().Name.Should().Be("Books");
        }

        [Fact]
        public async Task DeleteCategoryAsync_ShouldDeleteIfNoProducts()
        {
            var context = GetDbContext();
            var id = Guid.NewGuid();
            context.Categories.Add(new Category { Id = id, Name = "Temp", Description = "To Delete" });
            await context.SaveChangesAsync();

            var service = new CategoryService(context, null);
            var result = await service.DeleteCategoryAsync(id);

            result.Should().BeTrue();
            (await context.Categories.AnyAsync()).Should().BeFalse();
        }

        [Fact]
        public async Task DeleteCategoryAsync_ShouldThrowIfProductsExist()
        {
            var context = GetDbContext();
            var id = Guid.NewGuid();
            var category = new Category
            {
                Id = Guid.NewGuid(),
                Name = "TestCategory",
                Description = "This is a test category.",
                Products = new List<Product>
                {
                   new Product
                   {
                     Id = Guid.NewGuid(),
                     Name = "TestProduct",
                     Description = "Test product",
                     Price = 100,
                     Sku = "SKU001",
                     StockQuantity = 10,
                     IsAvailable = true,
                     DateCreated = DateTime.UtcNow,
                     ImageUrl="http://example.com/image.jpg",
                    
                   }
                }
            };

            context.Categories.Add(category);
            await context.SaveChangesAsync();

            var service = new CategoryService(context,null);

            Func<Task> action = async () => await service.DeleteCategoryAsync(category.Id);

            await Assert.ThrowsAsync<InvalidOperationException>(action);
        }
    }
}
