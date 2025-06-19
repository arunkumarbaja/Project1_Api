using DTO.ShoppingCart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL.ECommerceServices.ShoppingServices
{
    public interface IShoppingCartService
    {
        Task AddToCartAsync( AddToCartDto dto);
        Task<List<CartItemDto>> GetCartItemsAsync(Guid userId);
        Task RemoveFromCartAsync(Guid cartItemId);
        Task ClearCartAsync(Guid userId);
    }

}
