using Microsoft.Extensions.Configuration;
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




        public async Task SendOrderConfirmationEmailAsync(string toEmail, string userName, string orderId, DateTime orderDate, string shippingAddressStreet, string shippingAddressCity, string shippingAddressState,string shippingAddressPostalCode, string shippingAddressCountry)
        {
            // Sender email and credentials from configuration or secrets
            var email = configuration.GetValue<string>("Email_Configuration:Email");
            var password = configuration.GetValue<string>("Email_Configuration:Password");
            var host = configuration.GetValue<string>("Email_Configuration:Host");
            var port = configuration.GetValue<int>("Email_Configuration:Port");

            // Compose the email body (plain text or HTML)
            string body = $@"
    <html>
    <body style='font-family: Arial, sans-serif;'>
      <h2>Order Confirmation - Order #{orderId}</h2>
      <p>Hi <strong>{userName}</strong>,</p>
      <p>Thank you for your order! We’re pleased to confirm that your order has been successfully placed on <strong>{orderDate:dddd, dd MMMM yyyy}</strong>.</p>

      <h4>Order Summary:</h4>
      <ul>
        <li><strong>Shipping Address:</strong><br />
            {shippingAddressStreet},<br />
            {shippingAddressCity}, {shippingAddressState} - {shippingAddressPostalCode}<br />
            {shippingAddressCountry}
        </li>
      </ul>

      <p>You will receive another email when your order ships.</p>
      <p>If you have any questions, feel free to contact our support team.</p>

      <p>Best regards,<br />
      <strong>YourStoreName Team</strong></p>
    </body>
    </html>
    ";

            var message = new MailMessage
            {
                From = new MailAddress(email!, "YourStoreName"),
                Subject = $"Order Confirmation - #{orderId}",
                Body = body,
                IsBodyHtml = true
            };

            message.To.Add(toEmail);

            using (var client = new SmtpClient(host, port))
            {
                client.Credentials = new NetworkCredential(email, password);
                client.EnableSsl = true; // Or false depending on your provider
                await client.SendMailAsync(message);
            }
        }

    }

    public static class EmailServiceExtensions
    {
        public static bool IsValidEmail(this EmailService service, string email)
        {
            return !string.IsNullOrWhiteSpace(email) &&
                   System.Text.RegularExpressions.Regex.IsMatch(
                       email,
                       @"^[^@\s]+@[^@\s]+\.[ ^@\s]+$",
                       System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        }
    }

}
