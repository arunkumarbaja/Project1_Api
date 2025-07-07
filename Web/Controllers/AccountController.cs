using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Project1_Api.NewFolder;
using System.Data;
using System.Net.Http;
using System.Security.Claims;
using Web.Models.ViewModels;

namespace Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private IEmailService _emailService;

        public AccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IEmailService emailService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _emailService = emailService;
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _userManager.FindByEmailAsync(model.Email!);
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid login.");
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password!, false,true);

            if (result.Succeeded)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var claims = new List<Claim>
                {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName ?? ""),
                new Claim(ClaimTypes.Email, user.Email ?? "")
                };

                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                // sending mail that you have logged in
                var body = $"You have logged in  successfully if not you report changes done";
                var subject = $"Login Successfull";
                await _emailService.SendEmailAsync(model.Email!, subject, body);

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Invalid login.");
            return View(model);
        }

        
        public IActionResult Register()
        {
            return View();  
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model,string role="Customer" )
        {
            if (model == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest();

            ApplicationUser user = new ApplicationUser()
            {
                UserName = model.Email,
                NormalizedUserName = model.First_Name!.ToUpper() + model.Last_Name!.ToUpper(),
                Email = model.Email,
                NormalizedEmail = model.Email!.ToUpper(),
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D").ToUpper(),
                FirstName = model.First_Name,
                LastName = model.Last_Name,
                DateRegistered = DateTime.UtcNow,
                PhoneNumber = model.phonenumber,
                ShippingAddressStreet = model.ShippingAddressStreet,
                ShippingAddressCity = model.ShippingAddressCity,
                ShippingAddressState = model.ShippingAddressState,
                ShippingAddressPostalCode = model.ShippingAddressPostalCode,
                ShippingAddressCountry = model.ShippingAddressCountry,
            };
            var result = await _userManager.CreateAsync(user, model.Password!);
            if (result.Succeeded)
            {

                if (!await _roleManager.RoleExistsAsync(role))
                {
                    await _roleManager.CreateAsync(new ApplicationRole { Name = role, NormalizedName = role.ToUpper() });
                }
                var roleresult = await _userManager.AddToRoleAsync(user, role);
                if (roleresult.Succeeded)
                {
                    // send registration successfull email
                    var body = $" Dear {model.First_Name} you have successfully registred";
                    var subject = $"Registration Successfull";
                    var receptor = model.Email;

                    await _emailService.SendEmailAsync(receptor, subject, body);

                    return RedirectToAction("Login","Account");
                }
                else
                {
                    return BadRequest("error occurred while adding to role");
                }

            }
            else
            {
                return BadRequest("unable to register");
            }
        }


        public IActionResult VerifyEmail()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> VerifyEmail(VerifyEmailViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.Email!);
                if (user == null)
                {
                    ModelState.AddModelError("", "User not found. Please check the entered email.");
                    return View(model);
                }

                var sub = "this mail is regarding conformation password";
                var body = "verify email to set new password";

                await _emailService.SendEmailAsync(model.Email!, sub, body);

                return RedirectToAction("ChangePassword", "Account", new { username = user.UserName });
            }

            return View(model);
        }

        public IActionResult ChangePassword(string username)
        {

            return View(new ChangePasswordViewModel { Email = username });
        }



        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (model == null)
                return BadRequest("Password data is missing.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (model.New_Password != model.Confirm_New_Password)
                return BadRequest("New password and confirmation do not match.");

            var user = await _userManager.FindByEmailAsync(model.Email!);
            if (user == null)
                return NotFound("User not found.");

            // Change the password securely
            var result = await _userManager.ChangePasswordAsync(user, model.Current_Password!, model.New_Password!);

            if (result.Succeeded)
            {
                // send email for changing password
                var body = $"Your password has been changed , report if not you";
                var subject = $"Password Changed";
                var receptor = model.Email;
                await _emailService.SendEmailAsync(receptor!, subject, body);

                //return Ok("Password successfully changed.");

                return RedirectToAction("Account","Login");

            }

            // Return identity errors if it failed
            return BadRequest(result.Errors);
        }


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme, new AuthenticationProperties
            {
                ExpiresUtc = DateTime.UtcNow.AddDays(-1),
                IsPersistent = false,
                AllowRefresh = false
            });

            // Clear user identity manually (defensive, in case layout renders too early)
            HttpContext.User = new ClaimsPrincipal(new ClaimsIdentity());


            await _signInManager.SignOutAsync();

            return RedirectToAction("Login", "Account");
        }
 
    }

}
