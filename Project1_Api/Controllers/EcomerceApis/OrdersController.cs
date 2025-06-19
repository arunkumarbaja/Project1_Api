using BBL.ECommerceServices.OrderService;
using DTO.OrderDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Project1_Api.Controllers.EcomerceControllers
{
    // 3. OrderController (API)
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto dto)
        {
            try
            {
                var result = await _orderService.CreateOrderAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrder(Guid orderId)
        {
            var result = await _orderService.GetOrderByIdAsync(orderId);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetOrdersByUser(Guid userId)
        {
            var result = await _orderService.GetOrdersByUserIdAsync(userId);
            return Ok(result);
        }
    }
}
