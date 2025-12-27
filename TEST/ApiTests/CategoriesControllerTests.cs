using BBL.ECommerceServices.CategoryService;
using DTO.CategoryDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Project1_Api.Controllers.EcomerceApis;

namespace TEST.ApiTests
{
    public class CategoriesControllerTests
    {
        private readonly Mock<ICategoryService> _categoryServiceMock;
        private readonly Mock<ILogger<CategoriesController>> _loggerMock;
        private readonly CategoriesController _controller;

        public CategoriesControllerTests()
        {
            _categoryServiceMock = new Mock<ICategoryService>();
            _loggerMock = new Mock<ILogger<CategoriesController>>();
            _controller = new CategoriesController(_categoryServiceMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task GetAll_ReturnsOk_WithCategories()
        {
            // Arrange
            var categories = new List<CategoryDto>
            {
                new CategoryDto { Id = Guid.NewGuid(), Name = "Cat1" },
                new CategoryDto { Id = Guid.NewGuid(), Name = "Cat2" }
            };
            _categoryServiceMock.Setup(s => s.GetAllCategoriesAsync())
                .ReturnsAsync(categories);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<CategoryDto>>(okResult.Value);
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public async Task GetById_ReturnsOk_WhenCategoryExists()
        {
            // Arrange
            var id = Guid.NewGuid();
            var category = new CategoryDto { Id = id, Name = "Cat" };
            _categoryServiceMock.Setup(s => s.GetCategoryByIdAsync(id))
                .ReturnsAsync(category);

            // Act
            var result = await _controller.GetById(id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<CategoryDto>(okResult.Value);
            Assert.Equal(id, model.Id);
        }

        [Fact]
        public async Task GetById_ReturnsNotFound_WhenCategoryDoesNotExist()
        {
            // Arrange
            var id = Guid.NewGuid();
            _categoryServiceMock.Setup(s => s.GetCategoryByIdAsync(id))
                .ReturnsAsync((CategoryDto?)null);

            // Act
            var result = await _controller.GetById(id);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Create_ReturnsCreatedAt_WithCreatedCategory()
        {
            // Arrange
            var dto = new CreateCategoryDto { Name = "New Category", Description = "Desc" };
            var created = new CategoryDto { Id = Guid.NewGuid(), Name = dto.Name, Description = dto.Description };
            _categoryServiceMock.Setup(s => s.AddCategoryAsync(dto))
                .ReturnsAsync(created);

            // Act
            var result = await _controller.Create(dto);

            // Assert
            var createdAt = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(nameof(CategoriesController.GetById), createdAt.ActionName);
            Assert.Equal(created.Id, ((CategoryDto)createdAt.Value!).Id);
        }

        [Fact]
        public async Task Update_ReturnsNoContent_WhenUpdateSucceeds()
        {
            // Arrange
            var id = Guid.NewGuid();
            var dto = new UpdateCategoryDto { Id = id, Name = "Updated", Description = "Desc" };
            _categoryServiceMock.Setup(s => s.UpdateCategoryAsync(dto)).ReturnsAsync(true);

            // Act
            var result = await _controller.Update(id, dto);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Update_ReturnsNotFound_WhenUpdateFails()
        {
            // Arrange
            var id = Guid.NewGuid();
            var dto = new UpdateCategoryDto { Id = id, Name = "Updated", Description = "Desc" };
            _categoryServiceMock.Setup(s => s.UpdateCategoryAsync(dto)).ReturnsAsync(false);

            // Act
            var result = await _controller.Update(id, dto);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Delete_ReturnsNoContent_WhenDeleteSucceeds()
        {
            // Arrange
            var id = Guid.NewGuid();
            _categoryServiceMock.Setup(s => s.DeleteCategoryAsync(id)).ReturnsAsync(true);

            // Act
            var result = await _controller.Delete(id);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Delete_ReturnsNotFound_WhenDeleteFails()
        {
            // Arrange
            var id = Guid.NewGuid();
            _categoryServiceMock.Setup(s => s.DeleteCategoryAsync(id)).ReturnsAsync(false);

            // Act
            var result = await _controller.Delete(id);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
