
namespace Project1_Api.AuthService
{
    public interface IAuthService
    {
        Task<string> GenerateTokenAsync(string email);
    }
}