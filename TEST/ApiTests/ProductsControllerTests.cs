using BBL.ECommerceServices.ProductService;
using DTO.ProductDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Project1_Api.Controllers.EcomerceControllers;

namespace TEST.ApiTests
{
    public class ProductsControllerTests
    {
        private readonly Mock<IProductService> _productServiceMock;
        private readonly Mock<ILogger<ProductsController>> _loggerMock;
        private readonly ProductsController _controller;

        public ProductsControllerTests()
        {
            _productServiceMock = new Mock<IProductService>();
            _loggerMock = new Mock<ILogger<ProductsController>>();
            _controller = new ProductsController(_productServiceMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task GetAll_ReturnsOk_WithProducts()
        {
            // Arrange
            var products = new List<ProductDto>
            {
                new ProductDto { Id = Guid.NewGuid(), Name = "P1" },
                new ProductDto { Id = Guid.NewGuid(), Name = "P2" }
            };
            _productServiceMock.Setup(s => s.GetAllProductsAsync())
                .ReturnsAsync(products);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<ProductDto>>(okResult.Value);
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public async Task GetById_ReturnsOk_WhenProductExists()
        {
            // Arrange
            var id = Guid.NewGuid();
            var product = new ProductDto { Id = id, Name = "P1" };
            _productServiceMock.Setup(s => s.GetProductByIdAsync(id))
                .ReturnsAsync(product);

            // Act
            var result = await _controller.GetById(id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<ProductDto>(okResult.Value);
            Assert.Equal(id, model.Id);
        }

        [Fact]
        public async Task GetById_ReturnsNotFound_WhenProductDoesNotExist()
        {
            // Arrange
            var id = Guid.NewGuid();
            _productServiceMock.Setup(s => s.GetProductByIdAsync(id))
                .ReturnsAsync((ProductDto?)null);

            // Act
            var result = await _controller.GetById(id);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Create_ReturnsCreatedAt_WithCreatedProduct()
        {
            // Arrange
            var dto = new CreateProductDto { Name = "New Product" };
            var created = new ProductDto { Id = Guid.NewGuid(), Name = dto.Name };
            _productServiceMock.Setup(s => s.AddProductAsync(dto))
                .ReturnsAsync(created);

            // Act
            var result = await _controller.Create(dto);

            // Assert
            var createdAt = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(nameof(ProductsController.GetById), createdAt.ActionName);
            Assert.Equal(created.Id, ((ProductDto)createdAt.Value!).Id);
        }

        [Fact]
        public async Task Update_ReturnsNoContent_WhenUpdateSucceeds()
        {
            // Arrange
            var id = Guid.NewGuid();
            var dto = new UpdateProductDto { Id = id, Name = "Updated" };
            _productServiceMock.Setup(s => s.UpdateProductAsync(dto)).ReturnsAsync(true);

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
            var dto = new UpdateProductDto { Id = id, Name = "Updated" };
            _productServiceMock.Setup(s => s.UpdateProductAsync(dto)).ReturnsAsync(false);

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
            _productServiceMock.Setup(s => s.DeleteProductAsync(id)).ReturnsAsync(true);

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
            _productServiceMock.Setup(s => s.DeleteProductAsync(id)).ReturnsAsync(false);

            // Act
            var result = await _controller.Delete(id);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
