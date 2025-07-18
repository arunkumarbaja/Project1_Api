using BBL.ECommerceServices.ShoppingServices;
using DTO.ShoppingCart;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ShoppingCartController : ControllerBase
{
    private readonly IShoppingCartService _shoppingCartService;
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly ILogger<ShoppingCartController> _logger;

    public ShoppingCartController(
        IShoppingCartService shoppingCartService,
        IHttpContextAccessor contextAccessor,
        ILogger<ShoppingCartController> logger)
    {
        _shoppingCartService = shoppingCartService;
        _contextAccessor = contextAccessor;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> AddToCart([FromBody] AddToCartDto dto)
    {
        _logger.LogInformation("adding products to cart");
        try
        {
            await _shoppingCartService.AddToCartAsync(dto);
            return Ok(new { message = "Item added to cart" });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error adding item to cart");
            return StatusCode(500, "An error occurred while adding to cart.");
        }
    }

    [HttpGet("user/{userIdClaim}")]
    public async Task<IActionResult> GetCartForLoggedInUser(string userIdClaim)
    {
        try
        {
            if (string.IsNullOrEmpty(userIdClaim))
                return Unauthorized("User ID not found in claims.");

            if (!Guid.TryParse(userIdClaim, out var userId))
                return BadRequest("Invalid user ID format.");

            var items = await _shoppingCartService.GetCartItemsAsync(userId);
            var grandTotal = items.Sum(i => i.Quantity * i.Price);

            return Ok(new
            {
                Items = items,
                GrandTotal = grandTotal
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error fetching cart for user {userIdClaim}");
            return StatusCode(500, "An error occurred while fetching the cart.");
        }
    }

    [HttpPost("increase/{itemId}/{userId}")]
    public async Task<IActionResult> IncreaseQuantity(Guid itemId, string userId)
    {
        try
        {
            if (string.IsNullOrEmpty(userId)) return Unauthorized();

            var success = await _shoppingCartService.IncreaseQuantityAsync(itemId, Guid.Parse(userId));
            if (!success) return NotFound("Item not found");

            return Ok(new { message = "Quantity increased" });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error increasing quantity");
            return StatusCode(500, "An error occurred while increasing quantity.");
        }
    }

    [HttpPost("decrease/{itemId}/{userId}")]
    public async Task<IActionResult> DecreaseQuantity(Guid itemId, string userId)
    {
        try
        {
            if (string.IsNullOrEmpty(userId)) return Unauthorized();

            var success = await _shoppingCartService.DecreaseQuantityAsync(itemId, Guid.Parse(userId));
            if (!success) return NotFound("Item not found or quantity already 1");

            return Ok(new { message = "Quantity decreased" });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error decreasing quantity");
            return StatusCode(500, "An error occurred while decreasing quantity.");
        }
    }

    [HttpDelete("{itemId}/{userId}")]
    public async Task<IActionResult> RemoveFromCart(Guid itemId, string userId)
    {
        try
        {
            await _shoppingCartService.RemoveFromCartAsync(itemId, Guid.Parse(userId));
            return Ok(new { message = "Item removed from cart" });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error removing item from cart");
            return StatusCode(500, "An error occurred while removing the item.");
        }
    }

    [HttpDelete("clear/{userId}")]
    public async Task<IActionResult> ClearCart(string userId)
    {
        try
        {
            await _shoppingCartService.ClearCartAsync(Guid.Parse(userId));
            return Ok(new { message = "Cart cleared" });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error clearing cart");
            return StatusCode(500, "An error occurred while clearing the cart.");
        }
    }
}
