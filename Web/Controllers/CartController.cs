using Domain;
using DTO.ShoppingCart;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace Web.Controllers
{

        public class CartController : Controller
        {
            private readonly HttpClient _httpClient;
            private readonly IHttpContextAccessor _contextAccessor;

            public CartController(IHttpClientFactory httpClientFactory, IHttpContextAccessor contextAccessor)
            {
                _httpClient = httpClientFactory.CreateClient();
                _contextAccessor = contextAccessor;
                _httpClient.BaseAddress = new Uri("https://localhost:7079/"); // Update with your actual API base URL
            }

            private void SetToken()
            {
                var cookie = _contextAccessor.HttpContext?.Request.Cookies[".AspNetCore.Cookies"];
                if (!string.IsNullOrEmpty(cookie))
                {
                _httpClient.DefaultRequestHeaders.Remove("Cookie");
                _httpClient.DefaultRequestHeaders.Add("Cookie", $".AspNetCore.Cookies={cookie}");
                }
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var accessToken = _contextAccessor.HttpContext.Request.Cookies[".AspNetCore.Cookies"];
            if (!string.IsNullOrEmpty(accessToken))
            {
                _httpClient.DefaultRequestHeaders.Add("Cookie", $".AspNetCore.Cookies={accessToken}");
            }

            var response = await _httpClient.GetAsync($"api/ShoppingCart/user/{userId}");
            if (!response.IsSuccessStatusCode)
            {
                return View(new List<CartItemDto>());
            }

            var json = await response.Content.ReadAsStringAsync();
            var result = System.Text.Json.JsonSerializer.Deserialize<CartApiResponse>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            ViewBag.GrandTotal = result.Items?.Sum(x => x.Total) ?? 0;
            return View(result.Items);

        }

        [HttpPost]

        public async Task<IActionResult> Add(AddToCartDto dto)
         {
            if (dto.ProductId == Guid.Empty)
                return BadRequest("ProductId is required");

            if (dto.Quantity <= 0)
               return BadRequest("Quantity must be at least 1");

               var userid=  User.FindFirstValue(ClaimTypes.NameIdentifier);

               dto.UserId = Guid.Parse(userid!);
              if(dto.UserId==null)
              {
                return RedirectToAction("Login","Account");
              }
              // Serialize using Newtonsoft
               var json = JsonConvert.SerializeObject(dto);
               var content = new StringContent(json, Encoding.UTF8, "application/json");

               var response = await _httpClient.PostAsync("api/ShoppingCart", content);
   
               if (response.IsSuccessStatusCode)
               {
                  return RedirectToAction("Index","Home");
               }
               else
               {
                  foreach (var state in ModelState)
               {
                  foreach (var error in state.Value.Errors)
                  {
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
            await _httpClient.PostAsync($"api/ShoppingCart/increase/{itemId}/{userId}", null);
            return RedirectToAction("Index");
        }

        // Optional: Decrease Quantity
        [HttpPost]
        public async Task<IActionResult> DecreaseQuantity(Guid itemId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            SetToken();
            await _httpClient.PostAsync($"api/ShoppingCart/decrease/{itemId}/{userId}", null);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Remove(Guid itemId)
            {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            SetToken();
                var response = await _httpClient.DeleteAsync($"api/ShoppingCart/{itemId}/{userId}");
                return RedirectToAction("Index");
            }

        [HttpPost]
        public async Task<IActionResult> Clear()
        {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                SetToken();
            var response = await _httpClient.DeleteAsync($"api/ShoppingCart/clear/{userId}");
            return RedirectToAction("Index");
            }
        }

       
        public class CartApiResponse
        {
            public List<CartItemDto> Items { get; set; }
            public decimal GrandTotal { get; set; }
        }
    }

