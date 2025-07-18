using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly ILogger<CheckoutController> _logger;
        private string PayPalClientId { get; set; } = "";
        private string PayPalSecret { get; set; } = "";
        private string PaypalUrl { get; set; } = "";

        public CheckoutController(IConfiguration configuration, ILogger<CheckoutController> logger)
        {
            _logger = logger;
            PayPalClientId = configuration["PayPalSettings:ClientId"]!;
            PayPalSecret = configuration["PayPalSettings:Secret"]!;
            PaypalUrl = configuration["PayPalSettings:Url"]!;
            _logger.LogInformation("CheckoutController initialized with PayPalClientId: {PayPalClientId}, PaypalUrl: {PaypalUrl}", PayPalClientId, PaypalUrl);
        }

        public async Task<string> Token()
        {
            _logger.LogInformation("Token endpoint called.");
            return await GetPaypalTokenAsync();
        }

        private async Task<string> GetPaypalTokenAsync()
        {
            string accessToken = string.Empty;
            string url = PaypalUrl.TrimEnd('/') + "/v1/oauth2/token";
            _logger.LogInformation("Requesting PayPal token from {Url}", url);

            using (var client = new HttpClient())
            {
                string credentials64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(PayPalClientId + ":" + PayPalSecret));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials64);

                var requestMessage = new HttpRequestMessage(HttpMethod.Post, url);
                requestMessage.Content = new StringContent("grant_type=client_credentials", Encoding.UTF8, "application/x-www-form-urlencoded");

                var httpResponse = await client.SendAsync(requestMessage);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var strResponse = await httpResponse.Content.ReadAsStringAsync();
                    var jsonResponse = JsonNode.Parse(strResponse);

                    if (jsonResponse != null)
                    {
                        accessToken = jsonResponse["access_token"]?.ToString() ?? "";
                        _logger.LogInformation("Received PayPal access token.");
                    }
                }
                else
                {
                    _logger.LogError("Failed to get PayPal token. StatusCode: {StatusCode}", httpResponse.StatusCode);
                }

                return accessToken;
            }
        }

        [HttpGet]
        public IActionResult Index([FromQuery] decimal totalAmount)
        {
            _logger.LogInformation("Index called with totalAmount: {TotalAmount}", totalAmount);
            ViewBag.PayPalClientId = PayPalClientId;
            ViewBag.totalAmount = totalAmount;
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> CreatePaymentOrder([FromBody] JsonObject data)
        {
            var totalAmount = data?["amount"]?.ToString();
            _logger.LogInformation("CreatePaymentOrder called with amount: {Amount}", totalAmount);

            if (totalAmount == null)
            {
                _logger.LogWarning("CreatePaymentOrder called with null amount.");
                return new JsonResult(new { id = "" });
            }

            JsonObject createOrderRequest = new JsonObject();
            createOrderRequest.Add("intent", "CAPTURE");

            JsonObject amount = new JsonObject();
            amount.Add("currency_code", "USD");
            amount.Add("value", totalAmount);

            JsonObject purchaseUnit1 = new JsonObject();
            purchaseUnit1.Add("amount", amount);

            JsonArray purchaseUnits = new JsonArray();
            purchaseUnits.Add(purchaseUnit1);

            createOrderRequest.Add("purchase_units", purchaseUnits);

            string accessToken = await GetPaypalTokenAsync();
            string url = PaypalUrl.TrimEnd('/') + "/v2/checkout/orders";
            _logger.LogInformation("Creating PayPal order at {Url}", url);

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                var requestMessage = new HttpRequestMessage(HttpMethod.Post, url);
                requestMessage.Content = new StringContent(createOrderRequest.ToString(), Encoding.UTF8, "application/json");

                var httpResponse = await client.SendAsync(requestMessage);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var strResponse = await httpResponse.Content.ReadAsStringAsync();
                    var jsonResponse = JsonNode.Parse(strResponse);

                    if (jsonResponse != null)
                    {
                        string paypalOrderId = jsonResponse["id"]?.ToString() ?? "";
                        _logger.LogInformation("PayPal order created with ID: {OrderId}", paypalOrderId);
                        return new JsonResult(new { Id = paypalOrderId });
                    }
                }
                else
                {
                    _logger.LogError("Failed to create PayPal order. StatusCode: {StatusCode}", httpResponse.StatusCode);
                }
            }

            return new JsonResult(new { id = "" });
        }

        [HttpPost]
        public async Task<JsonResult> CompleteOrder([FromBody] JsonObject data)
        {
            var orderId = data["orderID"]?.ToString();
            _logger.LogInformation("CompleteOrder called with orderID: {OrderId}", orderId);

            if (orderId == null)
            {
                _logger.LogWarning("CompleteOrder called with null orderID.");
                return new JsonResult("error");
            }

            string accessToken = await GetPaypalTokenAsync();
            string url = $"{PaypalUrl}/v2/checkout/orders/{orderId}/capture";
            _logger.LogInformation("Capturing PayPal order at {Url}", url);

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                var requestMessage = new HttpRequestMessage(HttpMethod.Post, url);
                requestMessage.Content = new StringContent("", Encoding.UTF8, "application/json");

                var httpResponse = await client.SendAsync(requestMessage);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var strResponse = await httpResponse.Content.ReadAsStringAsync();
                    var jsonResponse = JsonNode.Parse(strResponse);

                    if (jsonResponse != null)
                    {
                        string paypalOrderStatus = jsonResponse["status"]?.ToString() ?? "";
                        _logger.LogInformation("PayPal order status: {Status}", paypalOrderStatus);
                        if (paypalOrderStatus == "COMPLETED")
                        {
                            return new JsonResult("success");
                        }
                    }
                }
                else
                {
                    _logger.LogError("Failed to capture PayPal order. StatusCode: {StatusCode}", httpResponse.StatusCode);
                }
            }

            return new JsonResult("error");
        }
    }
}
