using System.Net;
using System.Net.Mail;

namespace Project1_Api.NewFolder
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration configuration;

        public EmailService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task SendEmailAsync(string receptor, string subject, string body)
        {

            var email = configuration.GetValue<string>("Email_Configuration:Email");
            var password = configuration.GetValue<string>("Email_Configuration:Password");
            var host = configuration.GetValue<string>("Email_Configuration:Host");
            var port = configuration.GetValue<int>("Email_Configuration:Port");

            var smtpClinet = new SmtpClient(host, port);
            smtpClinet.EnableSsl = true;
            smtpClinet.UseDefaultCredentials = false;
            smtpClinet.Credentials = new NetworkCredential(email, password);

            var message = new MailMessage(email!, receptor, subject, body);
            await smtpClinet.SendMailAsync(message);

        }
    }

    public static class EmailServiceExtensions
    {
        public static bool IsValidEmail(this EmailService service, string email)
        {
            return !string.IsNullOrWhiteSpace(email) &&
                   System.Text.RegularExpressions.Regex.IsMatch(
                       email,
                       @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                       System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        }
    }

}
