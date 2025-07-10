using BBL.ECommerceServices.ShoppingServices;
using Domain.Models;
using DTO.OrderDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using Project1_Api.NewFolder;
using SelectPdf;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
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


        public OrderController(IHttpClientFactory httpClientFactory, IHttpContextAccessor contextAccessor,UserManager<ApplicationUser> userManager, IShoppingCartService shoppingCartService, IEmailService emailService)
        {
            _userManager = userManager;
            _httpClient = httpClientFactory.CreateClient();
            _contextAccessor = contextAccessor;
            _httpClient.BaseAddress = new Uri("https://localhost:7079/"); // Update with your actual API base URL
            _shoppingCartService = shoppingCartService;
            _emailService = emailService;
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
                return RedirectToAction("Login", "Account");

            var response = await _httpClient.GetAsync($"api/order/user/{userId}");

            if (!response.IsSuccessStatusCode)
            {
                TempData["Error"] = "Unable to fetch orders.";
                return View(new List<OrderResponseDto>());
            }

            var content = await response.Content.ReadAsStringAsync();
            var orders = JsonConvert.DeserializeObject<List<OrderResponseDto>>(content);

            return View(orders);
        }

        [HttpPost]
        public async Task<IActionResult> PlaceOrder()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null) return RedirectToAction("Login", "Account");

            // 1. Get cart items
            var cartItems = await _shoppingCartService.GetCartItemsAsync(Guid.Parse(userId));
            if (cartItems == null || !cartItems.Any())
                return RedirectToAction("Index"); // or show empty cart msg

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
            //make payment...........



            // 3. Send request to API
            var request = new StringContent(JsonConvert.SerializeObject(orderDto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/order/create", request);

            if (response.IsSuccessStatusCode)
            {
                var userEmail = User.FindFirst(ClaimTypes.Email)!.Value;

                var user = await _userManager.FindByEmailAsync(userEmail);
                if(userEmail != null)
                {
                    //sending email regrding order placement
                    await _emailService.SendOrderConfirmationEmailAsync(user!.Email!, user.FirstName, Guid.NewGuid().ToString(), DateTime.UtcNow, user.ShippingAddressStreet, user.ShippingAddressCity, user.ShippingAddressState, user.ShippingAddressPostalCode, user.ShippingAddressCountry);

                }



                // 4. Clear cart
                await _shoppingCartService.ClearCartAsync(Guid.Parse(userId));
                return RedirectToAction("Index","Order");
            }

            TempData["Error"] = "Failed to place order.";
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public async Task<IActionResult> DownloadInvoice(Guid orderId)
        {

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null) return RedirectToAction("Login", "Account");


            // Fetch order details from DB

            var response = await _httpClient.GetAsync($"api/order/{orderId}");

            if (!response.IsSuccessStatusCode)
            {
                TempData["Error"] = "Unable to fetch orders.";
                return View(new Order());
            }

            var json = await response.Content.ReadAsStringAsync();
            var order = System.Text.Json.JsonSerializer.Deserialize<Order>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });


            if (order == null)
                return NotFound();

            // Render Razor view to HTML
            string htmlContent = await this.RenderViewAsync("DownloadInvoice", order, true);

            // Convert HTML to PDF
            HtmlToPdf converter = new HtmlToPdf();
            PdfDocument doc = converter.ConvertHtmlString(htmlContent);

            byte[] pdf = doc.Save();
            doc.Close();

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
