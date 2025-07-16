
namespace BBL.AuthService
{
    public interface IAuthService
    {
        Task<string> GenerateTokenAsync(string email);
    }
}