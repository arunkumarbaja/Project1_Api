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

        public AdminController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("https://localhost:7079/api/Products");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();

                var products = System.Text.Json.JsonSerializer.Deserialize<List<ProductDto>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return View(products);
            }

            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(); // Return empty form
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto dto, IFormFile ImageFile)
        {
            if (!ModelState.IsValid)
            {
                foreach (var state in ModelState)
                {
                    foreach (var error in state.Value.Errors)
                    {
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
            }

            // Serialize using Newtonsoft
            var jsonBody = JsonConvert.SerializeObject(dto);
            Console.WriteLine("JSON Sent:\n" + jsonBody);

            var jsonContent = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"https://localhost:7079/api/Products", jsonContent);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            // Log error response
            string errorContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine("API Error Response:\n" + errorContent);

            ModelState.AddModelError(string.Empty, "Failed to create product.");
            return View(dto);
        }



        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7079/api/Products/{id}");
            if (!response.IsSuccessStatusCode)
                return NotFound();

            var json = await response.Content.ReadAsStringAsync();
            var product =System.Text.Json.JsonSerializer.Deserialize<UpdateProductDto>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, UpdateProductDto product)
        {
            if (id != product.Id || !ModelState.IsValid)
                return View(product);



            var jsonContent = new StringContent(System.Text.Json.JsonSerializer.Serialize(product), System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"https://localhost:7079/api/Products/{id}", jsonContent);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            foreach (var state in ModelState)
            {
                foreach (var error in state.Value.Errors)
                {
                    Console.WriteLine($"Field: {state.Key} | Error: {error.ErrorMessage}");
                }
            }
            return View(product);
        }
        // GET: Products/Delete/{id}
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7079/api/Products/{id}");

            if (!response.IsSuccessStatusCode)
            {
                TempData["Error"] = "Failed to load product for deletion.";
                return RedirectToAction("Index");
            }

            var content = await response.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<ProductDto>(content);

            return View(product); // Returns a confirmation view
        }
        // POST: Products/DeleteConfirmed
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:7079/api/Products/{id}");

            if (response.IsSuccessStatusCode)
            {
                TempData["Success"] = "Product deleted successfully.";
                return RedirectToAction("Index");
            }

            TempData["Error"] = "Failed to delete product.";
            return RedirectToAction("Index");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
