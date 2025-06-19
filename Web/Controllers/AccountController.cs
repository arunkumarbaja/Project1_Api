using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Security.Claims;
using Web.Models.ViewModels;

namespace Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly HttpClient _httpClient;
        public AccountController(IHttpClientFactory httpclient  )
        {
            _httpClient = httpclient.CreateClient();
        }

        [HttpGet]
        public IActionResult Login()
        {
           return   View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string role ="Admin")
        {
            var response = await  _httpClient.PostAsJsonAsync("https://localhost:7079/api/Account/Login", model);

            if (response.IsSuccessStatusCode)
            {
                //var token = await response.Content.ReadFromJsonAsync<TokenResponse>();

                // Extract claims if you send them from API or use Email
                var claims = new List<Claim>
               {
                      new Claim(ClaimTypes.Name, model.Email!),
                      new Claim(ClaimTypes.Role, role)
               };


                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("MyCookieAuth", principal);

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Invalid login.");
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("MyCookieAuth");
            return RedirectToAction("Index", "Home");
        }
    }
}
