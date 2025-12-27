using BBL.ECommerceServices.ShoppingServices;
using DTO.ShoppingCart;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Project1_Api.Controllers.EcomerceControllers;

namespace TEST.ApiTests
{
    public class ShoppingCartControllerTests
    {
        private readonly Mock<IShoppingCartService> _shoppingCartServiceMock;
        private readonly Mock<IHttpContextAccessor> _contextAccessorMock;
        private readonly Mock<ILogger<ShoppingCartController>> _loggerMock;
        private readonly ShoppingCartController _controller;

        public ShoppingCartControllerTests()
        {
            _shoppingCartServiceMock = new Mock<IShoppingCartService>();
            _contextAccessorMock = new Mock<IHttpContextAccessor>();
            _loggerMock = new Mock<ILogger<ShoppingCartController>>();
            _controller = new ShoppingCartController(_shoppingCartServiceMock.Object, _contextAccessorMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task AddToCart_ReturnsOk_WhenSuccessful()
        {
            // Arrange
            var dto = new AddToCartDto { UserId = Guid.NewGuid(), ProductId = Guid.NewGuid(), Quantity = 1 };

            // Act
            var result = await _controller.AddToCart(dto);

            // Assert
            var ok = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(ok.Value);
            _shoppingCartServiceMock.Verify(s => s.AddToCartAsync(dto), Times.Once);
        }

        [Fact]
        public async Task GetCartForLoggedInUser_ReturnsUnauthorized_WhenUserIdMissing()
        {
            // Act
            var result = await _controller.GetCartForLoggedInUser(string.Empty);

            // Assert
            var unauthorized = Assert.IsType<UnauthorizedObjectResult>(result);
        }

        [Fact]
        public async Task GetCartForLoggedInUser_ReturnsBadRequest_WhenUserIdInvalid()
        {
            // Act
            var result = await _controller.GetCartForLoggedInUser("not-a-guid");

            // Assert
            var badRequest = Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task IncreaseQuantity_ReturnsOk_WhenSuccessful()
        {
            // Arrange
            var itemId = Guid.NewGuid();
            var userId = Guid.NewGuid().ToString();
            _shoppingCartServiceMock.Setup(s => s.IncreaseQuantityAsync(itemId, It.IsAny<Guid>()))
                .ReturnsAsync(true);

            // Act
            var result = await _controller.IncreaseQuantity(itemId, userId);

            // Assert
            var ok = Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task IncreaseQuantity_ReturnsNotFound_WhenServiceReturnsFalse()
        {
            // Arrange
            var itemId = Guid.NewGuid();
            var userId = Guid.NewGuid().ToString();
            _shoppingCartServiceMock.Setup(s => s.IncreaseQuantityAsync(itemId, It.IsAny<Guid>()))
                .ReturnsAsync(false);

            // Act
            var result = await _controller.IncreaseQuantity(itemId, userId);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async Task DecreaseQuantity_ReturnsOk_WhenSuccessful()
        {
            // Arrange
            var itemId = Guid.NewGuid();
            var userId = Guid.NewGuid().ToString();
            _shoppingCartServiceMock.Setup(s => s.DecreaseQuantityAsync(itemId, It.IsAny<Guid>()))
                .ReturnsAsync(true);

            // Act
            var result = await _controller.DecreaseQuantity(itemId, userId);

            // Assert
            var ok = Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task DecreaseQuantity_ReturnsNotFound_WhenServiceReturnsFalse()
        {
            // Arrange
            var itemId = Guid.NewGuid();
            var userId = Guid.NewGuid().ToString();
            _shoppingCartServiceMock.Setup(s => s.DecreaseQuantityAsync(itemId, It.IsAny<Guid>()))
                .ReturnsAsync(false);

            // Act
            var result = await _controller.DecreaseQuantity(itemId, userId);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async Task RemoveFromCart_ReturnsOk_WhenSuccessful()
        {
            // Arrange
            var itemId = Guid.NewGuid();
            var userId = Guid.NewGuid().ToString();

            // Act
            var result = await _controller.RemoveFromCart(itemId, userId);

            // Assert
            var ok = Assert.IsType<OkObjectResult>(result);
            _shoppingCartServiceMock.Verify(s => s.RemoveFromCartAsync(itemId, It.IsAny<Guid>()), Times.Once);
        }

        [Fact]
        public async Task ClearCart_ReturnsOk_WhenSuccessful()
        {
            // Arrange
            var userId = Guid.NewGuid().ToString();

            // Act
            var result = await _controller.ClearCart(userId);

            // Assert
            var ok = Assert.IsType<OkObjectResult>(result);
            _shoppingCartServiceMock.Verify(s => s.ClearCartAsync(It.IsAny<Guid>()), Times.Once);
        }
    }
}
