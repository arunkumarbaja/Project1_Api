using Domain;
using DTO.ShoppingCart;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace Web.Controllers
{

    [Authorize(Roles = "Admin,Customer")]
    public class CartController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ILogger<CartController> _logger;

        public CartController(IHttpClientFactory httpClientFactory, IHttpContextAccessor contextAccessor, ILogger<CartController> logger)
        {
            _httpClient = httpClientFactory.CreateClient();
            _contextAccessor = contextAccessor;
            _logger = logger;
            _httpClient.BaseAddress = new Uri("https://localhost:7079/"); // Update with your actual API base URL
        }

        private void SetToken()
        {
            var cookie = _contextAccessor.HttpContext?.Request.Cookies[".AspNetCore.Cookies"];
            if (!string.IsNullOrEmpty(cookie))
            {
                _httpClient.DefaultRequestHeaders.Remove("Cookie");
                _httpClient.DefaultRequestHeaders.Add("Cookie", $".AspNetCore.Cookies={cookie}");
                _logger.LogInformation("Set authentication cookie for HttpClient.");
            }
            else
            {
                _logger.LogWarning("No authentication cookie found when setting token.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var accessToken = _contextAccessor?.HttpContext?.Request.Cookies[".AspNetCore.Cookies"];
            if (!string.IsNullOrEmpty(accessToken))
            {
                _httpClient.DefaultRequestHeaders.Add("Cookie", $".AspNetCore.Cookies={accessToken}");
                _logger.LogInformation("Added authentication cookie to HttpClient for Index.");
            }

            var response = await _httpClient.GetAsync($"api/ShoppingCart/user/{userId}");
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogWarning("Failed to get shopping cart for user {UserId}. StatusCode: {StatusCode}", userId, response.StatusCode);
                return View(new List<CartItemDto>());
            }

            var json = await response.Content.ReadAsStringAsync();
            var result = System.Text.Json.JsonSerializer.Deserialize<CartApiResponse>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            ViewBag.GrandTotal = result?.Items?.Sum(x => x.Total) ?? 0;
            _logger.LogInformation("Loaded cart for user {UserId} with {ItemCount} items.", userId, result?.Items?.Count ?? 0);
            return View(result?.Items);

        }

        [HttpPost]
        public async Task<IActionResult> Add(AddToCartDto dto)
        {
            if (dto.ProductId == Guid.Empty)
            {
                _logger.LogWarning("AddToCartDto.ProductId is empty.");
                return BadRequest("ProductId is required");
            }

            if (dto.Quantity <= 0)
            {
                _logger.LogWarning("AddToCartDto.Quantity is less than or equal to zero.");
                return BadRequest("Quantity must be at least 1");
            }

            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            dto.UserId = Guid.Parse(userid!);
            if (dto?.UserId == null)
            {
                _logger.LogWarning("UserId is null in AddToCartDto.");
                return RedirectToAction("Login", "Account");
            }
            // Serialize using Newtonsoft
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/ShoppingCart", content);

            if (response.IsSuccessStatusCode)
            {
                _logger.LogInformation("Successfully added product {ProductId} to cart for user {UserId}.", dto.ProductId, dto.UserId);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                _logger.LogError("Failed to add product {ProductId} to cart for user {UserId}. StatusCode: {StatusCode}", dto.ProductId, dto.UserId, response.StatusCode);
                foreach (var state in ModelState)
                {
                    foreach (var error in state.Value.Errors)
                    {
                        _logger.LogError("Field: {Field} | Error: {ErrorMessage}", state.Key, error.ErrorMessage);
                        Console.WriteLine($"Field: {state.Key} | Error: {error.ErrorMessage}");
                    }
                }
            }

            return BadRequest("Failed to add item to cart.");
        }
        // Optional: increase Quantity

        [HttpPost]
        public async Task<IActionResult> IncreaseQuantity(Guid itemId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            SetToken();
            var response = await _httpClient.PostAsync($"api/ShoppingCart/increase/{itemId}/{userId}", null);
            if (response.IsSuccessStatusCode)
            {
                _logger.LogInformation("Increased quantity for cart item {ItemId} for user {UserId}.", itemId, userId);
            }
            else
            {
                _logger.LogWarning("Failed to increase quantity for cart item {ItemId} for user {UserId}. StatusCode: {StatusCode}", itemId, userId, response.StatusCode);
            }
            return RedirectToAction("Index");
        }

        // Optional: Decrease Quantity
        [HttpPost]
        public async Task<IActionResult> DecreaseQuantity(Guid itemId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            SetToken();
            var response = await _httpClient.PostAsync($"api/ShoppingCart/decrease/{itemId}/{userId}", null);
            if (response.IsSuccessStatusCode)
            {
                _logger.LogInformation("Decreased quantity for cart item {ItemId} for user {UserId}.", itemId, userId);
            }
            else
            {
                _logger.LogWarning("Failed to decrease quantity for cart item {ItemId} for user {UserId}. StatusCode: {StatusCode}", itemId, userId, response.StatusCode);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Remove(Guid itemId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            SetToken();
            var response = await _httpClient.DeleteAsync($"api/ShoppingCart/{itemId}/{userId}");
            if (response.IsSuccessStatusCode)
            {
                _logger.LogInformation("Removed cart item {ItemId} for user {UserId}.", itemId, userId);
            }
            else
            {
                _logger.LogWarning("Failed to remove cart item {ItemId} for user {UserId}. StatusCode: {StatusCode}", itemId, userId, response.StatusCode);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Clear()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            SetToken();
            var response = await _httpClient.DeleteAsync($"api/ShoppingCart/clear/{userId}");
            if (response.IsSuccessStatusCode)
            {
                _logger.LogInformation("Cleared cart for user {UserId}.", userId);
            }
            else
            {
                _logger.LogWarning("Failed to clear cart for user {UserId}. StatusCode: {StatusCode}", userId, response.StatusCode);
            }
            return RedirectToAction("Index");
        }

        // getting cart count

        [HttpGet]
        public async Task<IActionResult> GetCartCount()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var accessToken = _contextAccessor?.HttpContext?.Request.Cookies[".AspNetCore.Cookies"];
            if (!string.IsNullOrEmpty(accessToken))
            {
                _httpClient.DefaultRequestHeaders.Add("Cookie", $".AspNetCore.Cookies={accessToken}");
                _logger.LogInformation("Added authentication cookie to HttpClient for GetCartCount.");
            }

            var response = await _httpClient.GetAsync($"api/ShoppingCart/user/{userId}");
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogWarning("Failed to get cart count for user {UserId}. StatusCode: {StatusCode}", userId, response.StatusCode);
                return View(new List<CartItemDto>());
            }

            var json = await response.Content.ReadAsStringAsync();
            var result = System.Text.Json.JsonSerializer.Deserialize<CartApiResponse>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            var totalCount = result?.Items?.Sum(x => x.Quantity) ?? 0;
            _logger.LogInformation("Cart count for user {UserId}: {Count}", userId, totalCount);
            return Json(new { count = totalCount });
        }

        public class CartApiResponse
        {
            public List<CartItemDto>? Items { get; set; }
            public decimal GrandTotal { get; set; }
        }
    }
}

