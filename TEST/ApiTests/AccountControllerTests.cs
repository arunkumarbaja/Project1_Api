using BBL.AuthService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Project1.Models.ViewModels;
using Project1_Api.AuthService;
using Project1_Api.Controllers.AccountApis;
using Project1_Api.NewFolder;

namespace TEST.ApiTests
{
    public class AccountControllerTests
    {
        private readonly Mock<UserManager<ApplicationUser>> _userManagerMock;
        private readonly Mock<SignInManager<ApplicationUser>> _signInManagerMock;
        private readonly Mock<RoleManager<ApplicationRole>> _roleManagerMock;
        private readonly Mock<IEmailService> _emailServiceMock;
        private readonly Mock<IAuthService> _authServiceMock;
        private readonly Mock<ILogger<AccountController>> _loggerMock;
        private readonly AccountController _controller;

        public AccountControllerTests()
        {
            var userStore = new Mock<IUserStore<ApplicationUser>>();
            _userManagerMock = new Mock<UserManager<ApplicationUser>>(userStore.Object, null, null, null, null, null, null, null, null);

            var contextAccessor = new Mock<IHttpContextAccessor>();
            var claimsFactory = new Mock<IUserClaimsPrincipalFactory<ApplicationUser>>();
            _signInManagerMock = new Mock<SignInManager<ApplicationUser>>(
                _userManagerMock.Object,
                contextAccessor.Object,
                claimsFactory.Object,
                null, null, null, null);

            var roleStore = new Mock<IRoleStore<ApplicationRole>>();
            _roleManagerMock = new Mock<RoleManager<ApplicationRole>>(roleStore.Object, null, null, null, null);

            _emailServiceMock = new Mock<IEmailService>();
            _authServiceMock = new Mock<IAuthService>();
            _loggerMock = new Mock<ILogger<AccountController>>();

            _controller = new AccountController(
                _userManagerMock.Object,
                _signInManagerMock.Object,
                _roleManagerMock.Object,
                _emailServiceMock.Object,
                _authServiceMock.Object,
                _loggerMock.Object);
        }

        [Fact]
        public async Task Login_ReturnsOk_WithToken_OnSuccess()
        {
            // Arrange
            var model = new LoginViewModel { Email = "test@example.com", Password = "Password123!" };
            _signInManagerMock.Setup(s => s.PasswordSignInAsync(model.Email!, model.Password!, false, true))
                .ReturnsAsync(SignInResult.Success);

            _authServiceMock.Setup(a => a.GenerateTokenAsync(model.Email!))
                .ReturnsAsync("fake-token");

            // Act
            var result = await _controller.Login(model);

            // Assert
            var ok = Assert.IsType<OkObjectResult>(result.Result);
            var tokenResponse = Assert.IsType<TokenResponse>(ok.Value);
            Assert.Equal("fake-token", tokenResponse.Token);
        }

        [Fact]
        public async Task Login_ReturnsUnauthorized_OnInvalidCredentials()
        {
            // Arrange
            var model = new LoginViewModel { Email = "test@example.com", Password = "Password123!" };
            _signInManagerMock.Setup(s => s.PasswordSignInAsync(model.Email!, model.Password!, false, true))
                .ReturnsAsync(SignInResult.Failed);

            // Act
            var result = await _controller.Login(model);

            // Assert
            Assert.IsType<UnauthorizedObjectResult>(result.Result);
        }

        [Fact]
        public async Task Register_ReturnsCreated_OnSuccess()
        {
            // Arrange
            var model = new RegisterViewModel
            {
                First_Name = "John",
                Last_Name = "Doe",
                Email = "john@example.com",
                Password = "Password123!",
                Confirm_Password = "Password123!",
                ShippingAddressStreet = "st",
                ShippingAddressCity = "c",
                ShippingAddressState = "s",
                ShippingAddressPostalCode = "p",
                ShippingAddressCountry = "ct"
            };

            _userManagerMock.Setup(u => u.CreateAsync(It.IsAny<ApplicationUser>(), model.Password!))
                .ReturnsAsync(IdentityResult.Success);

            _roleManagerMock.Setup(r => r.RoleExistsAsync("Customer"))
                .ReturnsAsync(false);
            _roleManagerMock.Setup(r => r.CreateAsync(It.IsAny<ApplicationRole>()))
                .ReturnsAsync(IdentityResult.Success);
            _userManagerMock.Setup(u => u.AddToRoleAsync(It.IsAny<ApplicationUser>(), "Customer"))
                .ReturnsAsync(IdentityResult.Success);

            // Act
            var result = await _controller.Register(model);

            // Assert
            Assert.IsType<CreatedResult>(result);
        }

        [Fact]
        public async Task VerifyEmail_ReturnsOk_WhenUserExists()
        {
            // Arrange
            var model = new VerifyEmailViewModel { Email = "user@example.com" };
            var user = new ApplicationUser { Email = model.Email };

            _userManagerMock.Setup(u => u.FindByEmailAsync(model.Email!))
                .ReturnsAsync(user);

            // Act
            var result = await _controller.VerifyEmail(model);

            // Assert
            var ok = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(ok.Value);
        }

        [Fact]
        public async Task VerifyEmail_ReturnsNotFound_WhenUserMissing()
        {
            // Arrange
            var model = new VerifyEmailViewModel { Email = "missing@example.com" };
            _userManagerMock.Setup(u => u.FindByEmailAsync(model.Email!))
                .ReturnsAsync((ApplicationUser?)null);

            // Act
            var result = await _controller.VerifyEmail(model);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async Task ChangePassword_ReturnsOk_OnSuccess()
        {
            // Arrange
            var model = new ChangePasswordViewModel
            {
                Name = "User",
                Email = "user@example.com",
                Current_Password = "OldPassword123!",
                New_Password = "NewPassword123!",
                Confirm_New_Password = "NewPassword123!"
            };

            var user = new ApplicationUser { Email = model.Email };
            _userManagerMock.Setup(u => u.FindByEmailAsync(model.Email!))
                .ReturnsAsync(user);

            _userManagerMock.Setup(u => u.ChangePasswordAsync(user, model.Current_Password!, model.New_Password!))
                .ReturnsAsync(IdentityResult.Success);

            // Act
            var result = await _controller.ChangePassword(model);

            // Assert
            var ok = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(ok.Value);
        }

        [Fact]
        public async Task ChangePassword_ReturnsBadRequest_WhenNewPasswordMismatch()
        {
            // Arrange
            var model = new ChangePasswordViewModel
            {
                Name = "User",
                Email = "user@example.com",
                Current_Password = "OldPassword123!",
                New_Password = "NewPassword123!",
                Confirm_New_Password = "Different!"
            };

            // Act
            var result = await _controller.ChangePassword(model);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
