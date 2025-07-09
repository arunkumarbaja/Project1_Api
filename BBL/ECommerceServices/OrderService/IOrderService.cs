using Domain.Models;
using DTO.OrderDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL.ECommerceServices.OrderService
{
    public interface IOrderService
    {
        Task<OrderResponseDto> CreateOrderAsync(CreateOrderDto dto);
        Task<Order> GetOrderByIdAsync(Guid orderId);
        Task<List<OrderResponseDto>> GetOrdersByUserIdAsync(Guid userId);
    }


}
