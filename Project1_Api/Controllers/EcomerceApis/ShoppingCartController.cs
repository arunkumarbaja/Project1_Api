using BBL.ECommerceServices.ShoppingServices;
using DTO.ShoppingCart;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project1_Api.Models;

namespace Project1_Api.Controllers.EcomerceApis
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartService _shoppingCartService;

        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        private Guid GetUserId()
        {
            return Guid.Parse(User.FindFirst("sub")?.Value ?? throw new Exception("User not found"));
        }

        // GET /api/cart
        [HttpGet]
        public async Task<IActionResult> GetCart()
        {
            var userId = GetUserId();
            var items = await _shoppingCartService.GetCartItemsAsync(userId);
            return Ok(items);
        }

        // POST /api/cart
        [HttpPost]
        public async Task<IActionResult> AddToCart([FromBody] AddToCartDto dto)
        {
            await _shoppingCartService.AddToCartAsync(dto);
            return Ok(new { message = "Item added to cart" });
        }

        // DELETE /api/cart/{itemId}
        [HttpDelete("{itemId}")]
        public async Task<IActionResult> RemoveFromCart(Guid itemId)
        {
            await _shoppingCartService.RemoveFromCartAsync(itemId);
            return Ok(new { message = "Item removed from cart" });
        }

        // DELETE /api/cart/clear
        [HttpDelete("clear")]
        public async Task<IActionResult> ClearCart()
        {
            var userId = GetUserId();
            await _shoppingCartService.ClearCartAsync(userId);
            return Ok(new { message = "Cart cleared" });
        }
    }

}
