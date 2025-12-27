using BBL.ECommerceServices.OrderService;
using DTO.OrderDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Project1_Api.Controllers.EcomerceControllers;
using Domain.Models;

namespace TEST.ApiTests
{
    public class OrderControllerTests
    {
        private readonly Mock<IOrderService> _orderServiceMock;
        private readonly Mock<ILogger<OrderController>> _loggerMock;
        private readonly OrderController _controller;

        public OrderControllerTests()
        {
            _orderServiceMock = new Mock<IOrderService>();
            _loggerMock = new Mock<ILogger<OrderController>>();
            _controller = new OrderController(_orderServiceMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task CreateOrder_ReturnsOk_WithOrderResponse()
        {
            // Arrange
            var dto = new CreateOrderDto
            {
                UserId = Guid.NewGuid(),
                ShippingAddressStreet = "st",
                ShippingAddressCity = "city",
                ShippingAddressState = "state",
                ShippingAddressPostalCode = "12345",
                ShippingAddressCountry = "country",
                OrderItems = new List<OrderItemDto>()
            };

            var response = new OrderResponseDto
            {
                OrderId = Guid.NewGuid(),
                OrderDate = DateTime.UtcNow,
                Status = OrderStatus.Pending,
                TotalAmount = 100m
            };

            _orderServiceMock.Setup(s => s.CreateOrderAsync(dto))
                .ReturnsAsync(response);

            // Act
            var result = await _controller.CreateOrder(dto);

            // Assert
            var ok = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<OrderResponseDto>(ok.Value);
            Assert.Equal(response.OrderId, model.OrderId);
        }

        [Fact]
        public async Task GetOrder_ReturnsOk_WhenFound()
        {
            // Arrange
            var orderId = Guid.NewGuid();
            var order = new Order
            {
                Id = orderId,
                UserId = Guid.NewGuid(),
                TotalAmount = 10m,
                ShippingAddressStreet = "s",
                ShippingAddressCity = "c",
                ShippingAddressState = "st",
                ShippingAddressPostalCode = "p",
                ShippingAddressCountry = "ct"
            };

            _orderServiceMock.Setup(s => s.GetOrderByIdAsync(orderId))
                .ReturnsAsync(order);

            // Act
            var result = await _controller.GetOrder(orderId);

            // Assert
            var ok = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<Order>(ok.Value);
            Assert.Equal(orderId, model.Id);
        }

        [Fact]
        public async Task GetOrder_ReturnsNotFound_WhenMissing()
        {
            // Arrange
            var orderId = Guid.NewGuid();
            _orderServiceMock.Setup(s => s.GetOrderByIdAsync(orderId))
                .ReturnsAsync((Order?)null);

            // Act
            var result = await _controller.GetOrder(orderId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetOrdersByUser_ReturnsOk_WithOrders()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var orders = new List<OrderResponseDto>
            {
                new OrderResponseDto { OrderId = Guid.NewGuid(), TotalAmount = 10m, Status = OrderStatus.Pending },
                new OrderResponseDto { OrderId = Guid.NewGuid(), TotalAmount = 20m, Status = OrderStatus.Delivered }
            };

            _orderServiceMock.Setup(s => s.GetOrdersByUserIdAsync(userId))
                .ReturnsAsync(orders);

            // Act
            var result = await _controller.GetOrdersByUser(userId);

            // Assert
            var ok = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<OrderResponseDto>>(ok.Value);
            Assert.Equal(2, model.Count());
        }
    }
}
