using DTO.ProductDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Web.Models;

namespace Web.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;




        // Constructor to inject dependencies
        public AdminController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClient = httpClientFactory.CreateClient();
            _logger.LogInformation("AdminController initialized.");
        }

        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("Fetching product list from API.");
            var response = await _httpClient.GetAsync("https://localhost:7079/api/Products");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();

                var products = System.Text.Json.JsonSerializer.Deserialize<List<ProductDto>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                _logger.LogInformation("Product list successfully retrieved. Count: {Count}", products?.Count ?? 0);
                return View(products);
            }

            _logger.LogWarning("Failed to fetch product list. StatusCode: {StatusCode}", response.StatusCode);
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            _logger.LogInformation("Rendering Create Product form.");
            return View(); // Return empty form
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto dto, IFormFile ImageFile)
        {
            _logger.LogInformation("Received Create Product POST request.");
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("ModelState is invalid for CreateProductDto.");
                foreach (var state in ModelState)
                {
                    foreach (var error in state.Value.Errors)
                    {
                        _logger.LogWarning("Field: {Field} | Error: {Error}", state.Key, error.ErrorMessage);
                        Console.WriteLine($"Field: {state.Key} | Error: {error.ErrorMessage}");
                    }
                }

                return View(dto);
            }

            // Save image file
            if (ImageFile != null && ImageFile.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImageFile.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/products", fileName);

                Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(stream);
                }

                dto.ImageUrl = "/products/" + fileName;
                _logger.LogInformation("Image file saved: {ImageUrl}", dto.ImageUrl);
            }

            // Serialize using Newtonsoft
            var jsonBody = JsonConvert.SerializeObject(dto);
            _logger.LogInformation("Serialized product JSON: {JsonBody}", jsonBody);
            Console.WriteLine("JSON Sent:\n" + jsonBody);

            var jsonContent = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"https://localhost:7079/api/Products", jsonContent);

            if (response.IsSuccessStatusCode)
            {
                _logger.LogInformation("Product created successfully.");
                return RedirectToAction("Index");
            }

            // Log error response
            string errorContent = await response.Content.ReadAsStringAsync();
            _logger.LogError("API Error Response: {ErrorContent}", errorContent);
            Console.WriteLine("API Error Response:\n" + errorContent);

            ModelState.AddModelError(string.Empty, "Failed to create product.");
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            _logger.LogInformation("Fetching product for edit. ProductId: {ProductId}", id);
            var response = await _httpClient.GetAsync($"https://localhost:7079/api/Products/{id}");
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogWarning("Failed to fetch product for edit. ProductId: {ProductId}, StatusCode: {StatusCode}", id, response.StatusCode);
                return NotFound();
            }

            var json = await response.Content.ReadAsStringAsync();
            var product = System.Text.Json.JsonSerializer.Deserialize<UpdateProductDto>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            _logger.LogInformation("Product loaded for edit. ProductId: {ProductId}", id);
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, UpdateProductDto product)
        {
            _logger.LogInformation("Received Edit Product POST request. ProductId: {ProductId}", id);
            if (id != product.Id || !ModelState.IsValid)
            {
                _logger.LogWarning("Edit Product validation failed. ProductId: {ProductId}", id);
                return View(product);
            }

            var jsonContent = new StringContent(System.Text.Json.JsonSerializer.Serialize(product), System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"https://localhost:7079/api/Products/{id}", jsonContent);

            if (response.IsSuccessStatusCode)
            {
                _logger.LogInformation("Product updated successfully. ProductId: {ProductId}", id);
                return RedirectToAction("Index");
            }

            foreach (var state in ModelState)
            {
                foreach (var error in state.Value.Errors)
                {
                    _logger.LogWarning("Field: {Field} | Error: {Error}", state.Key, error.ErrorMessage);
                    Console.WriteLine($"Field: {state.Key} | Error: {error.ErrorMessage}");
                }
            }
            _logger.LogError("Failed to update product. ProductId: {ProductId}", id);
            return View(product);
        }

        // GET: Products/Delete/{id}
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            _logger.LogInformation("Fetching product for deletion. ProductId: {ProductId}", id);
            var response = await _httpClient.GetAsync($"https://localhost:7079/api/Products/{id}");

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogWarning("Failed to load product for deletion. ProductId: {ProductId}, StatusCode: {StatusCode}", id, response.StatusCode);
                TempData["Error"] = "Failed to load product for deletion.";
                return RedirectToAction("Index");
            }

            var content = await response.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<ProductDto>(content);

            _logger.LogInformation("Product loaded for deletion confirmation. ProductId: {ProductId}", id);
            return View(product); // Returns a confirmation view
        }

        // POST: Products/DeleteConfirmed
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            _logger.LogInformation("Received DeleteConfirmed POST request. ProductId: {ProductId}", id);
            var response = await _httpClient.DeleteAsync($"https://localhost:7079/api/Products/{id}");

            if (response.IsSuccessStatusCode)
            {
                _logger.LogInformation("Product deleted successfully. ProductId: {ProductId}", id);
                TempData["Success"] = "Product deleted successfully.";
                return RedirectToAction("Index");
            }

            _logger.LogError("Failed to delete product. ProductId: {ProductId}, StatusCode: {StatusCode}", id, response.StatusCode);
            TempData["Error"] = "Failed to delete product.";
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            _logger.LogInformation("Rendering Privacy view.");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            _logger.LogError("An error occurred. Rendering Error view.");
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
