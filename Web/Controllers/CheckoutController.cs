using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Crypto.Operators;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class CheckoutController : Controller
    {
        private string PayPalClientId { get; set; } = "";

        private string PayPalSecret { get; set; } = "";

        private string PaypalUrl { get; set; } = "";

        public CheckoutController(IConfiguration configuration) 
        {
            PayPalClientId = configuration["PayPalSettings:ClientId"]!;
            PayPalSecret = configuration["PayPalSettings:Secret"]!;
            PaypalUrl = configuration["PayPalSettings:Url"]!;
        
        }

        public async Task<string> Token()
        {
            return await GetPaypalTokenAsync();
        }

        private async Task<string> GetPaypalTokenAsync()
        {
            string accessToken = string.Empty;

            string url = PaypalUrl.TrimEnd('/') + "/v1/oauth2/token";

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
                    }
                }

                return accessToken;
            }
        }


        public IActionResult Index()
        {
            ViewBag.PayPalClientId = PayPalClientId;
            return View();
        }


        [HttpPost]
        public async Task<JsonResult> CreatePaymentOrder([FromBody] JsonObject data)
        {
            var totalAmount = data?["amount"]?.ToString();
            if (totalAmount == null)
            {
                return new JsonResult(new { id = "" });
            }

            // creating request body
            JsonObject createOrderRequest = new JsonObject();
            createOrderRequest.Add("intent", "CAPTURE");

            JsonObject amount = new JsonObject();
            amount.Add("currency_code", "USD");
            amount.Add("value", totalAmount);


            JsonObject purchaseUnit1 = new JsonObject();
            purchaseUnit1.Add("amount", amount);

            JsonArray purchaseUnits = new JsonArray();
            purchaseUnits.Add(purchaseUnit1);

            createOrderRequest.Add("purchase_units",purchaseUnits);


            // get access toekn 

            string accessToken = await GetPaypalTokenAsync();

            string url = PaypalUrl.TrimEnd('/') + "/v2/checkout/orders";

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                var requestMessage = new HttpRequestMessage(HttpMethod.Post, url);
                requestMessage.Content = new StringContent(createOrderRequest.ToString(), Encoding.UTF8, "application/json");

                var httpResponse = await client.SendAsync(requestMessage);
                
                if(httpResponse.IsSuccessStatusCode)
                {
                    var strResponse =await httpResponse.Content.ReadAsStringAsync();
                    var jsonResponse = JsonNode.Parse(strResponse);

                    if(jsonResponse!=null)
                    {
                        string paypalOrderId = jsonResponse["id"]?.ToString()??"";
                        return new JsonResult(new { Id = paypalOrderId });
                    }
                }

            }


            return new JsonResult(new { id = "" });

        }


        [HttpPost]
        public async Task<JsonResult> CompleteOrder([FromBody] JsonObject data)
        {
            var orderId = data["orderID"]?.ToString();
            if (orderId == null)
            {
                return new JsonResult("error");
            }

            string accessToken = await GetPaypalTokenAsync();

            string url = $"{PaypalUrl}/v2/checkout/orders/{orderId}/capture";

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

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
                        if (paypalOrderStatus == "COMPLETED")
                        {
                            return new JsonResult("success");
                        }
                    }
                }
            }

            return new JsonResult("error");
        }


    }
}
