using BBL.AuthService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project1.Models.ViewModels;
using Project1_Api.AuthService;
using Project1_Api.NewFolder;

namespace Project1_Api.Controllers.AccountApis
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
        private readonly ILogger<AccountController> _logger;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<ApplicationRole> roleManager,
            IEmailService emailService,
            IAuthService authService,
            ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _emailService = emailService;
            _authService = authService;
            _logger = logger;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<TokenResponse>> Login(LoginViewModel model)
        {
            if (model == null)
            {
                _logger.LogWarning("Login attempt with missing data.");
                return BadRequest("Login data is missing.");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Login attempt with invalid model state for email: {Email}", model.Email);
                return BadRequest("Invalid login request.");
            }

            var result = await _signInManager.PasswordSignInAsync(model.Email!, model.Password!, isPersistent: false, lockoutOnFailure: true);

            if (result.Succeeded)
            {
                var token = await _authService.GenerateTokenAsync(model.Email!);

                var body = $"You have logged in  successfully if not you report changes done";
                var subject = $"Login Successfull";
                await _emailService.SendEmailAsync(model.Email!, subject, body);

                _logger.LogInformation("User {Email} logged in successfully.", model.Email);

                return Ok(new TokenResponse { Token = token });
            }

            _logger.LogWarning("Invalid login credentials for email: {Email}", model.Email);
            return Unauthorized("Invalid credentials.");
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterViewModel model, string role = "Customer")
        {
            if (model == null)
            {
                _logger.LogWarning("Registration attempt with missing data.");
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Registration attempt with invalid model state for email: {Email}", model.Email);
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
                if (!await _roleManager.RoleExistsAsync(role))
                {
                    await _roleManager.CreateAsync(new ApplicationRole { Name = role, NormalizedName = role.ToUpper() });
                    _logger.LogInformation("Role {Role} created.", role);
                }
                var roleresult = await _userManager.AddToRoleAsync(user, role);
                if (roleresult.Succeeded)
                {
                    var body = $" Dear {model.First_Name} you have successfully registred";
                    var subject = $"Registration Successfull";
                    var receptor = model.Email;

                    await _emailService.SendEmailAsync(receptor, subject, body);

                    _logger.LogInformation("User {Email} registered successfully with role {Role}.", model.Email, role);

                    return Created();
                }
                else
                {
                    _logger.LogError("Error occurred while adding user {Email} to role {Role}.", model.Email, role);
                    return BadRequest("error occurred while adding to role");
                }
            }
            else
            {
                _logger.LogError("Unable to register user {Email}. Errors: {Errors}", model.Email, string.Join(", ", result.Errors.Select(e => e.Description)));
                return BadRequest("unable to register");
            }
        }

        [HttpPost("VerifyEmail")]
        public async Task<IActionResult> VerifyEmail(VerifyEmailViewModel model)
        {
            if (model == null)
            {
                _logger.LogWarning("Email verification attempt with missing data.");
                return BadRequest("Login data is missing.");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Email verification attempt with invalid model state for email: {Email}", model.Email);
                return BadRequest("Invalid login request.");
            }

            var user = await _userManager.FindByEmailAsync(model.Email!);

            if (user != null)
            {
                var body = $"https://yourfrontend.com/reset-password?token={"token"}&email={user.Email}";
                var subject = $"Registration Successfull";
                var receptor = model.Email;

                await _emailService.SendEmailAsync(receptor!, subject, body);

                _logger.LogInformation("Verification email sent to {Email}.", model.Email);

                return Ok("An email verification link has been sent to your email");
            }
            else
            {
                _logger.LogWarning("User not found for email verification: {Email}", model.Email);
                return NotFound("User not found");
            }
        }

        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (model == null)
            {
                _logger.LogWarning("Change password attempt with missing data.");
                return BadRequest("Password data is missing.");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Change password attempt with invalid model state for email: {Email}", model.Email);
                return BadRequest(ModelState);
            }

            if (model.New_Password != model.Confirm_New_Password)
            {
                _logger.LogWarning("Change password attempt with mismatched new password and confirmation for email: {Email}", model.Email);
                return BadRequest("New password and confirmation do not match.");
            }

            var user = await _userManager.FindByEmailAsync(model.Email!);
            if (user == null)
            {
                _logger.LogWarning("Change password attempt for non-existent user: {Email}", model.Email);
                return NotFound("User not found.");
            }

            var result = await _userManager.ChangePasswordAsync(user, model.Current_Password!, model.New_Password!);

            if (result.Succeeded)
            {
                var body = $"Your password has been changed , report if not you";
                var subject = $"Password Changed";
                var receptor = model.Email;
                await _emailService.SendEmailAsync(receptor!, subject, body);

                _logger.LogInformation("Password changed successfully for user {Email}.", model.Email);

                return Ok("Password successfully changed.");
            }

            _logger.LogError("Failed to change password for user {Email}. Errors: {Errors}", model.Email, string.Join(", ", result.Errors.Select(e => e.Description)));
            return BadRequest(result.Errors);
        }
    }
}
