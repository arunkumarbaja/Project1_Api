using DTO.ProductDTO;
using DTO.ShoppingCart;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Net.Http;
using System.Security.Claims;
using System.Text.Json;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly HttpClient _httpClient;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<IActionResult> Index(string search)
        {
            _logger.LogInformation("Index action called with search: {Search}", search);

            var response = await _httpClient.GetAsync("https://localhost:7079/api/Products");

            if (response.IsSuccessStatusCode)
            {
                _logger.LogInformation("Successfully received products from API.");

                var content = await response.Content.ReadAsStringAsync();

                var products = JsonSerializer.Deserialize<List<ProductDto>>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (!string.IsNullOrWhiteSpace(search))
                {
                    search = search.ToLower();
                    products = products
                        .Where(p => p.Name.ToLower().Contains(search) || p.CategoryName.ToLower().Contains(search))
                        .ToList();

                    _logger.LogInformation("Filtered products by search: {Search}. Count: {Count}", search, products.Count);
                }

                return View(products);
            }

            _logger.LogWarning("Failed to receive products from API. StatusCode: {StatusCode}", response.StatusCode);

            return View(new List<ProductDto>()); // Return empty if failed
        }

        public IActionResult Privacy()
        {
            _logger.LogInformation("Privacy action called.");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            _logger.LogError("Error action called.");
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
