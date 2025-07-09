namespace Web.Models.ViewModels
{
    public class PaymentViewModel
    {
        public Guid ID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public decimal Amount { get; set; }

        public Guid TransactionId { get; set; }
    }
}
