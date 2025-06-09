using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Microsoft.Identity.Client;
using Project1.Data;
using Project1.Models;
using Project1.Models.ViewModels;
using Project1_Api.AuthService;
using Project1_Api.NewFolder;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;

namespace Project1_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IEmailService _emailService;
        private readonly IAuthService _authService;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager, IEmailService emailService, IAuthService authService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _emailService = emailService;
            _authService = authService;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<TokenResponse>> Login(LoginViewModel model)
        {
            if (model == null)
                return BadRequest("Login data is missing.");

            if (!ModelState.IsValid)
                return BadRequest("Invalid login request.");

            var result = await _signInManager.PasswordSignInAsync(model.Email!, model.Password!, isPersistent: false, lockoutOnFailure: true);

            if (result.Succeeded)
            {
                //generate jwt token
                var token = await _authService.GenerateTokenAsync(model.Email);

                // sending mail that you have logged in
                var body = $"You have logged in  successfully if not you report";
                var subject = $"Login Successfull";
                await _emailService.SendEmailAsync(model.Email!,subject,body);

                return Ok(new TokenResponse { Token = token });
            }

            return Unauthorized("Invalid credentials.");
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterViewModel model, string role = "Customer")
        {
            if (model == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest();

            ApplicationUser user = new ApplicationUser()
            {
                UserName = model.Email,
                NormalizedUserName = model.First_Name.ToUpper() + model.Last_Name.ToUpper(),
                Email = model.Email,
                NormalizedEmail = model.Email.ToUpper(),
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

                    return Created();
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

        [HttpPost("VerifyEmail")]
        public async Task<IActionResult> VerifyEmail(VerifyEmailViewModel model)
        {
            if (model == null)
                return BadRequest("Login data is missing.");

            if (!ModelState.IsValid)
                return BadRequest("Invalid login request.");

            var user = await _userManager.FindByEmailAsync(model.Email!);

            if (user != null)
            {
                // send verification email that should redirect to change password
                var body = $"https://yourfrontend.com/reset-password?token={"token"}&email={user.Email}";
                var subject = $"Registration Successfull";
                var receptor = model.Email;

                await _emailService.SendEmailAsync(receptor!, subject, body);

                return Ok("An email verification link has been sent to your email");
            }
            else
            {
                return NotFound("User not found");
            }


        }

        [HttpPost("ChangePassword")]
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


                return Ok("Password successfully changed.");
            }

            // Return identity errors if it failed
            return BadRequest(result.Errors);
        }

    }
}
