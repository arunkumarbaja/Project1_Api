using Domain.Models;

namespace Web.Models.ViewModels
{
    public class InvoiceClass
    {
        public Order OrderInvoice { get; set; }

        public List<OrderItem> OrderItemInvoice { get; set; }

    }
}
