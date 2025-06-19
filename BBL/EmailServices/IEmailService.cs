
namespace Project1_Api.NewFolder
{
    public interface IEmailService
    {
        Task SendEmailAsync( string receptor, string subject, string body);
    }
}