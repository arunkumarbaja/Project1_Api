using BBL.ECommerceServices.OrderService;
using DTO.OrderDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Project1_Api.Controllers.EcomerceControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ILogger<OrderController> _logger;

        public OrderController(IOrderService orderService, ILogger<OrderController> logger)
        {
            _orderService = orderService;
            _logger = logger;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto dto)
        {
            _logger.LogInformation("CreateOrder called for UserId: {UserId}", dto.UserId);
            try
            {
                var result = await _orderService.CreateOrderAsync(dto);
                _logger.LogInformation("Order created successfully. OrderId: {OrderId}", result.OrderId);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error creating order for UserId: {UserId}", dto.UserId);
                return StatusCode(500, "An error occurred while creating the order.");
            }
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrder(Guid orderId)
        {
            _logger.LogInformation("GetOrder called for OrderId: {OrderId}", orderId);
            try
            {
                var result = await _orderService.GetOrderByIdAsync(orderId);
                if (result == null)
                {
                    _logger.LogWarning("Order not found. OrderId: {OrderId}", orderId);
                    return NotFound();
                }

                _logger.LogInformation("Order retrieved successfully. OrderId: {OrderId}", orderId);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error fetching order with ID: {OrderId}", orderId);
                return StatusCode(500, "An error occurred while retrieving the order.");
            }
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetOrdersByUser(Guid userId)
        {
            _logger.LogInformation("GetOrdersByUser called for UserId: {UserId}", userId);
            try
            {
                var result = await _orderService.GetOrdersByUserIdAsync(userId);
                _logger.LogInformation("Orders retrieved for UserId: {UserId}. Count: {Count}", userId, result?.Count ?? 0);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error fetching orders for user ID: {UserId}", userId);
                return StatusCode(500, "An error occurred while retrieving the orders.");
            }
        }
    }
}
