using BBL.ECommerceServices.ShoppingServices;
using DTO.ShoppingCart;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace Project1_Api.Controllers.EcomerceApis
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IHttpContextAccessor _contextAccessor;

        public ShoppingCartController(IShoppingCartService shoppingCartService, IHttpContextAccessor contextAccessor    )
        {
            _shoppingCartService = shoppingCartService;
            _contextAccessor = contextAccessor;
        }


        // POST /api/cart
        [HttpPost]
        public async Task<IActionResult> AddToCart([FromBody] AddToCartDto dto)
        {
            await _shoppingCartService.AddToCartAsync(dto);
            return Ok(new { message = "Item added to cart" });
        }

        [HttpGet("user/{userIdClaim}")]
        public async Task<IActionResult> GetCartForLoggedInUser(string userIdClaim)
        {

             
             //var userIdClaim = "FF241E75-099C-4578-80F3-08DDAA7EE748";

            if (string.IsNullOrEmpty(userIdClaim))
                return Unauthorized("User ID not found in claims.");

            if (!Guid.TryParse(userIdClaim, out var userId))
                return BadRequest("Invalid user ID format.");

            var items = await _shoppingCartService.GetCartItemsAsync(userId);
            var grandTotal = items.Sum(i => i.Quantity * i.Price); // Assuming ProductPrice is available

            return Ok(new
            {
                Items = items,
                GrandTotal = grandTotal
            });
        }

        [HttpPost("increase/{itemId}/{userId}")]
        public async Task<IActionResult> IncreaseQuantity(Guid itemId, string userId)
        {
            if (string.IsNullOrEmpty(userId)) return Unauthorized();

            var success = await _shoppingCartService.IncreaseQuantityAsync(itemId, Guid.Parse(userId));
            if (!success) return NotFound("Item not found");

            return Ok(new { message = "Quantity increased" });
        }

        [HttpPost("decrease/{itemId}/{userId}")]
        public async Task<IActionResult> DecreaseQuantity(Guid itemId, string userId)
        {
            if (string.IsNullOrEmpty(userId)) return Unauthorized();

            var success = await _shoppingCartService.DecreaseQuantityAsync(itemId, Guid.Parse(userId));
            if (!success) return NotFound("Item not found or quantity already 1");

            return Ok(new { message = "Quantity decreased" });
        }


        // DELETE /api/cart/{itemId}
        [HttpDelete("{itemId}/{userId}")]
        public async Task<IActionResult> RemoveFromCart(Guid itemId, string userId)
        {
            await _shoppingCartService.RemoveFromCartAsync(itemId, Guid.Parse(userId));
            return Ok(new { message = "Item removed from cart" });
        }

        // DELETE /api/cart/clear
        [HttpDelete("clear/{userId}")]
        public async Task<IActionResult> ClearCart(string userId)
        {
            await _shoppingCartService.ClearCartAsync(Guid.Parse(userId));
            return Ok(new { message = "Cart cleared" });
        }
    }

}
