using BBL.ECommerceServices.ShoppingServices;
using DTO.ShoppingCart;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project1_Api.Models;
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

        //private Guid GetUserId()
        //{
        //    return Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? throw new Exception("User not found"));
        //}

        //// GET /api/cart
        //[HttpGet]
        //public async Task<IActionResult> GetCart()
        //{
        //    var userId = GetUserId();
        //    var items = await _shoppingCartService.GetCartItemsAsync(userId);
        //    return Ok(items);
        //}

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
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            await _shoppingCartService.ClearCartAsync(Guid.Parse(userId));
            return Ok(new { message = "Cart cleared" });
        }
    }

}
