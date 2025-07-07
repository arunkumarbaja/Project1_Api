
namespace Project1_Api.NewFolder
{
    public interface IEmailService
    {
        Task SendEmailAsync(string receptor, string subject, string body);

        Task SendOrderConfirmationEmailAsync(string toEmail, string userName, string orderId, DateTime orderDate, string shippingAddressStreet, string shippingAddressCity, string shippingAddressState, string shippingAddressPostalCode, string shippingAddressCountry);
    }
}