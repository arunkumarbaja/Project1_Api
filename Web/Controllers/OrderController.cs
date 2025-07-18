using BBL.ECommerceServices.ShoppingServices;
using DAL.Data;
using Domain.Models;
using DTO.OrderDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Project1_Api.NewFolder;
using SelectPdf;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Web.Models.ViewModels;
using static Web.Controllers.CartController;

namespace Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly IShoppingCartService _shoppingCartService;

        private readonly IEmailService _emailService;

        private ApplicationDbContext _context;
        private readonly ILogger<OrderController> _logger;

        public OrderController(IHttpClientFactory httpClientFactory, IHttpContextAccessor contextAccessor,UserManager<ApplicationUser> userManager, IShoppingCartService shoppingCartService, IEmailService emailService, ApplicationDbContext applicationDbContext, ILogger<OrderController> logger)
        {
            _userManager = userManager;
            _httpClient = httpClientFactory.CreateClient();
            _contextAccessor = contextAccessor;
            _httpClient.BaseAddress = new Uri("https://localhost:7079/"); // Update with your actual API base URL
            _shoppingCartService = shoppingCartService;
            _emailService = emailService;
            _context = applicationDbContext;
            _logger = logger;
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
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                _logger.LogWarning("User not logged in when accessing Order Index.");
                return RedirectToAction("Login", "Account");
            }

            _logger.LogInformation("Fetching orders for user {UserId}", userId);
            var response = await _httpClient.GetAsync($"api/order/user/{userId}");

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Failed to fetch orders for user {UserId}. StatusCode: {StatusCode}", userId, response.StatusCode);
                TempData["Error"] = "Unable to fetch orders.";
                return View(new List<OrderResponseDto>());
            }

            var content = await response.Content.ReadAsStringAsync();
            var orders = JsonConvert.DeserializeObject<List<OrderResponseDto>>(content);
            _logger.LogInformation("Fetched {OrderCount} orders for user {UserId}", orders?.Count ?? 0, userId);

            return View(orders);
        }

        [HttpGet]
        public async Task<IActionResult> PlaceOrder()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                _logger.LogWarning("User not logged in when trying to place an order.");
                return RedirectToAction("Login", "Account");
            }

            // 1. Get cart items
            var cartItems = await _shoppingCartService.GetCartItemsAsync(Guid.Parse(userId));
            if (cartItems == null || !cartItems.Any())
            {
                _logger.LogInformation("User {UserId} tried to place an order with an empty cart.", userId);
                return RedirectToAction("Index"); // or show empty cart msg
            }

            // 2. Build CreateOrderDto
            var orderDto = new CreateOrderDto
            {
                UserId = Guid.Parse(userId),
                ShippingAddressStreet = "123 Main St",  // ideally from user input form
                ShippingAddressCity = "Hyderabad",
                ShippingAddressState = "Telangana",
                ShippingAddressPostalCode = "500001",
                ShippingAddressCountry = "India",
                OrderItems = cartItems.Select(ci => new OrderItemDto
                {
                    ProductId = ci.ProductId,
                    Quantity = ci.Quantity
                }).ToList()
            };

            _logger.LogInformation("Placing order for user {UserId} with {ItemCount} items.", userId, orderDto.OrderItems.Count);

            // 3. Send request to API
            var request = new StringContent(JsonConvert.SerializeObject(orderDto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/order/create", request);

            if (response.IsSuccessStatusCode)
            {
                var userEmail = User.FindFirst(ClaimTypes.Email)!.Value;
                var user = await _userManager.FindByEmailAsync(userEmail);
                if (userEmail != null)
                {
                    //sending email regrding order placement
                    await _emailService.SendOrderConfirmationEmailAsync(user!.Email!, user.FirstName, Guid.NewGuid().ToString(), DateTime.UtcNow, user.ShippingAddressStreet, user.ShippingAddressCity, user.ShippingAddressState, user.ShippingAddressPostalCode, user.ShippingAddressCountry);
                    _logger.LogInformation("Order confirmation email sent to {Email}.", userEmail);
                }

                // 4. Clear cart
                await _shoppingCartService.ClearCartAsync(Guid.Parse(userId));
                _logger.LogInformation("Cart cleared for user {UserId} after order placement.", userId);
                return RedirectToAction("Index", "Order");
            }

            _logger.LogError("Failed to place order for user {UserId}. StatusCode: {StatusCode}", userId, response.StatusCode);
            TempData["Error"] = "Failed to place order.";
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public async Task<IActionResult> DownloadInvoice(Guid orderId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                _logger.LogWarning("User not logged in when trying to download invoice.");
                return RedirectToAction("Login", "Account");
            }

            _logger.LogInformation("User {UserId} requested invoice for order {OrderId}.", userId, orderId);

            // Fetch order details from DB
            var response = await _httpClient.GetAsync($"api/order/{orderId}");

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Failed to fetch order {OrderId} for invoice. StatusCode: {StatusCode}", orderId, response.StatusCode);
                TempData["Error"] = "Unable to fetch orders.";
                return View(new Order());
            }

            var json = await response.Content.ReadAsStringAsync();
            var order = System.Text.Json.JsonSerializer.Deserialize<Order>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (order == null)
            {
                _logger.LogWarning("Order {OrderId} not found for invoice download.", orderId);
                return NotFound();
            }

            // retriving orderitems
            List<OrderItem> orderItems = await _context.OrderItems
                .Include(oi => oi.Product)
                .Where(oi => oi.OrderId == orderId)
                .ToListAsync();

            InvoiceClass invoiceObject = new InvoiceClass
            {
                OrderInvoice = order,
                OrderItemInvoice = orderItems.Where(i => i != null).ToList()
            };

            // Render Razor view to HTML
            string htmlContent = await this.RenderViewAsync("DownloadInvoice", invoiceObject, true);

            // Convert HTML to PDF
            HtmlToPdf converter = new HtmlToPdf();
            PdfDocument doc = converter.ConvertHtmlString(htmlContent);

            byte[] pdf = doc.Save();
            doc.Close();

            _logger.LogInformation("Invoice PDF generated for order {OrderId}.", orderId);

            return File(pdf, "application/pdf", $"DownloadInvoice_{orderId}.pdf");
        }
    }

    public static class ControllerExtensions
    {
        public static async Task<string> RenderViewAsync<TModel>(this Controller controller, string viewName, TModel model, bool partial = false)
        {
            controller.ViewData.Model = model;

            using var sw = new StringWriter();
            var viewEngine = controller.HttpContext.RequestServices.GetService(typeof(IRazorViewEngine)) as IRazorViewEngine;
            var tempDataProvider = controller.HttpContext.RequestServices.GetService(typeof(ITempDataProvider)) as ITempDataProvider;
            var actionContext = new ActionContext(controller.HttpContext, controller.RouteData, controller.ControllerContext.ActionDescriptor);

            var viewResult = viewEngine!.FindView(actionContext, viewName, !partial);

            if (!viewResult.Success)
                throw new InvalidOperationException($"View {viewName} not found.");

            var viewContext = new ViewContext(
                actionContext,
                viewResult.View,
                controller.ViewData,
                controller.TempData,
                sw,
                new HtmlHelperOptions()
            );

            await viewResult.View.RenderAsync(viewContext);
            return sw.ToString();
        }
    }
}
