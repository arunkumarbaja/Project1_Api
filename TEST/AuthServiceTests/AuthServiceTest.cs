using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Microsoft.Extensions.Configuration;
using BBL.AuthService;
using Project1_Api.AuthService;

namespace TEST.AuthServiceTests
{
    public class AuthServiceTest
    {
        private readonly Mock<UserManager<ApplicationUser>> _userManagerMock;
        private readonly IAuthService _authService;

        private readonly Mock<IConfiguration> _configurationMock;

        private readonly JwtSettings _jwtSettings;


        public AuthServiceTest()
        {
            var userStoreMock = new Mock<IUserStore<ApplicationUser>>();

            _userManagerMock = new Mock<UserManager<ApplicationUser>>(userStoreMock.Object, null, null, null, null, null, null, null, null);

            _configurationMock = new Mock<IConfiguration>();

            _jwtSettings = new JwtSettings()
            {
                Issuer = "TestIssuer",
                Audience = "TestAudience",
                SecretKey = "ThisIsASecretKeyForTesting1234567890", // Must be at least 16 characters long
                ExpiryMinutes = 60 // Token expiry time in minutes
            };

            _authService = new AuthService(_jwtSettings, _userManagerMock.Object, _configurationMock.Object);
        }

        [Fact]
        public async Task GenerateToken_OnValidUser_ReturnToken()
        {
            //Arrange
            var user = new ApplicationUser { Email = "arun@Exanple.com", Id = Guid.NewGuid(), UserName = "arun" };

            _userManagerMock.Setup(x => x.FindByEmailAsync(user.Email)).ReturnsAsync(user);
            _userManagerMock.Setup(x => x.GetRolesAsync(user)).ReturnsAsync(new List<string> { "Customer" });

            // act

            var token = await _authService.GenerateTokenAsync(user.Email);

            // Assert
            Assert.NotNull(token);
            Assert.NotEmpty(token);
            Assert.IsType<string>(token);
        }

        [Fact]
        public async Task GenerateToken_OnInvalidUser_ThrowsException()
        {
            // Arrange
            string fakeEmail = "notfound@example.com";
            _userManagerMock.Setup(x => x.FindByEmailAsync(fakeEmail)).ReturnsAsync((ApplicationUser)null);

            // Act + Assert
            await Assert.ThrowsAsync<Exception>(() => _authService.GenerateTokenAsync(fakeEmail));
        }
    }


}
