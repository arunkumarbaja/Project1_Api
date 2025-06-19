using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;


namespace Domain
{
    public class User : IdentityUser
    {
        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }

        public DateTime DateRegistered { get; set; } = DateTime.UtcNow;

        // Simplified Address directly in User for a very small app
        // For slightly larger, a separate Address entity is better
        [MaxLength(200)]
        public string ShippingAddressStreet { get; set; }
        [MaxLength(100)]
        public string ShippingAddressCity { get; set; }
        [MaxLength(100)]
        public string ShippingAddressState { get; set; }
        [MaxLength(20)]
        public string ShippingAddressPostalCode { get; set; }
        [MaxLength(100)]
        public string ShippingAddressCountry { get; set; }


        // Navigation properties
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
        public virtual ICollection<ShoppingCartItem> ShoppingCartItems { get; set; } = new HashSet<ShoppingCartItem>();
    }
}
