using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.OrderDto
{
    public class CreateOrderDto
    {
        public Guid UserId { get; set; }

        public string ShippingAddressStreet { get; set; }
        public string ShippingAddressCity { get; set; }
        public string ShippingAddressState { get; set; }
        public string ShippingAddressPostalCode { get; set; }
        public string ShippingAddressCountry { get; set; }

        public List<OrderItemDto> OrderItems { get; set; }
    }

}
