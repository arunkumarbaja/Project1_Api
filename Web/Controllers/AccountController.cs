using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Project1_Api.NewFolder;
using System.Data;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using Web.Models;
using Web.Models.ViewModels;

namespace Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private IEmailService _emailService;
        private readonly ILogger<AccountController> _logger;

        public AccountController(
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            IEmailService emailService,
            ILogger<AccountController> logger)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _emailService = emailService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Login()
        {
            _logger.LogInformation("Login GET requested.");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            _logger.LogInformation("Login POST requested for email: {Email}", model.Email);
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Login model state invalid for email: {Email}", model.Email);
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email!);
            if (user == null)
            {
                _logger.LogWarning("Login failed: user not found for email: {Email}", model.Email);
                ModelState.AddModelError("", "Invalid login.");
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password!, false, true);

            if (result.Succeeded)
            {
                _logger.LogInformation("User {Email} logged in successfully.", model.Email);
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

                var body = $"You have logged in  successfully if not you report changes done";
                var subject = $"Login Successfull";
                await _emailService.SendEmailAsync(model.Email!, subject, body);

                return RedirectToAction("Index", "Home");
            }

            _logger.LogWarning("Login failed for user: {Email}", model.Email);
            ModelState.AddModelError("", "Invalid login.");
            return View(model);
        }

        public IActionResult Register()
        {
            _logger.LogInformation("Register GET requested.");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model, string role = "Customer")
        {
            _logger.LogInformation("Register POST requested for email: {Email}", model?.Email);
            if (model == null)
            {
                _logger.LogWarning("Register failed: model is null.");
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Register failed: model state invalid for email: {Email}", model.Email);
                return BadRequest();
            }

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
                _logger.LogInformation("User {Email} created successfully.", model.Email);
                if (!await _roleManager.RoleExistsAsync(role))
                {
                    await _roleManager.CreateAsync(new ApplicationRole { Name = role, NormalizedName = role.ToUpper() });
                    _logger.LogInformation("Role {Role} created.", role);
                }
                var roleresult = await _userManager.AddToRoleAsync(user, role);
                if (roleresult.Succeeded)
                {
                    _logger.LogInformation("User {Email} added to role {Role}.", model.Email, role);
                    var welcomeBody = $"Dear {model.First_Name}, you have successfully registered.";
                    var welcomeSubject = "Registration Successful";
                    await _emailService.SendEmailAsync(model.Email, welcomeSubject, welcomeBody);

                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    _logger.LogError("Error occurred while adding user {Email} to role {Role}.", model.Email, role);
                    return BadRequest("Error occurred while adding to role");
                }
            }
            else
            {
                _logger.LogError("Unable to register user {Email}.", model.Email);
                return BadRequest("unable to register");
            }
        }

        public IActionResult VerifyEmail()
        {
            _logger.LogInformation("VerifyEmail GET requested.");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> VerifyEmail(VerifyEmailViewModel model)
        {
            _logger.LogInformation("VerifyEmail POST requested for email: {Email}", model.Email);
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.Email!);
                if (user == null)
                {
                    _logger.LogWarning("VerifyEmail failed: user not found for email: {Email}", model.Email);
                    ModelState.AddModelError("", "User not found. Please check the entered email.");
                    return View(model);
                }

                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var encodedToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));

                var confirmationLink = Url.Action(nameof(ConfirmEmail), "Account", new { token = encodedToken, email = user.Email }, protocol: HttpContext.Request.Scheme);

                var confirmBody = $@"
                Hi {user.FirstName}
                Thank you for registering. Please confirm your email by clicking the link below:
                <a href='{confirmationLink}'>Confirm Email</a>
                If you did not request this, you can ignore this email ";

                var confirmSubject = "Email Confirmation Link";
                await _emailService.SendEmailAsync(user.Email!, confirmSubject, confirmBody);

                _logger.LogInformation("Email confirmation link sent to {Email}.", user.Email);

                return RedirectToAction("EmailVerificationImage", "Account");
            }

            _logger.LogWarning("VerifyEmail model state invalid for email: {Email}", model.Email);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            _logger.LogInformation("ConfirmEmail GET requested for email: {Email}", email);
            if (token == null || email == null)
            {
                _logger.LogError("ConfirmEmail failed: token or email is missing.");
                return View("Error", new ErrorViewModel { Message = "Token or email is missing." });
            }

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                _logger.LogError("ConfirmEmail failed: user not found for email: {Email}", email);
                return View("Error", new ErrorViewModel { Message = "User not found." });
            }

            string decodedToken = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(token));

            var result = await _userManager.ConfirmEmailAsync(user, decodedToken);

            if (result.Succeeded)
            {
                _logger.LogInformation("Email confirmed for user: {Email}", email);
                return RedirectToAction("ChangePassword", "Account", new { username = user.UserName });
            }

            _logger.LogError("Email confirmation failed for user: {Email}", email);
            return View("Error", new ErrorViewModel { Message = "Email confirmation failed." });
        }

        [HttpGet]
        public IActionResult EmailVerificationImage()
        {
            _logger.LogInformation("EmailVerificationImage GET requested.");
            return View();
        }

        public IActionResult ChangePassword(string username)
        {
            _logger.LogInformation("ChangePassword GET requested for username: {Username}", username);
            return View(new ChangePasswordViewModel { Email = username });
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            _logger.LogInformation("ChangePassword POST requested for email: {Email}", model?.Email);
            if (model == null)
            {
                _logger.LogWarning("ChangePassword failed: model is null.");
                return BadRequest("Password data is missing.");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("ChangePassword failed: model state invalid for email: {Email}", model.Email);
                return BadRequest(ModelState);
            }

            if (model.New_Password != model.Confirm_New_Password)
            {
                _logger.LogWarning("ChangePassword failed: new password and confirmation do not match for email: {Email}", model.Email);
                return BadRequest("New password and confirmation do not match.");
            }

            var user = await _userManager.FindByEmailAsync(model.Email!);
            if (user == null)
            {
                _logger.LogWarning("ChangePassword failed: user not found for email: {Email}", model.Email);
                return NotFound("User not found.");
            }

            var result = await _userManager.ChangePasswordAsync(user, model.Current_Password!, model.New_Password!);

            if (result.Succeeded)
            {
                _logger.LogInformation("Password changed successfully for user: {Email}", model.Email);
                var body = $"Your password has been changed , report if not you";
                var subject = $"Password Changed";
                var receptor = model.Email;
                await _emailService.SendEmailAsync(receptor!, subject, body);

                return RedirectToAction("Account", "Login");
            }

            _logger.LogError("Password change failed for user: {Email}. Errors: {Errors}", model.Email, result.Errors);
            return BadRequest(result.Errors);
        }

        public async Task<IActionResult> Logout()
        {
            _logger.LogInformation("Logout requested.");
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme, new AuthenticationProperties
            {
                ExpiresUtc = DateTime.UtcNow.AddDays(-1),
                IsPersistent = false,
                AllowRefresh = false
            });

            HttpContext.User = new ClaimsPrincipal(new ClaimsIdentity());

            await _signInManager.SignOutAsync();

            _logger.LogInformation("User logged out.");
            return RedirectToAction("Login", "Account");
        }
    }

}
