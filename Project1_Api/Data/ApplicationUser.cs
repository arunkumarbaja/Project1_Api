using Microsoft.AspNetCore.Identity;
using Project1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // For NotMapped

// Assuming your e-commerce models (Order, ShoppingCartItem) are in a relevant namespace
// using YourProject.Models.ECommerce;

public class ApplicationUser : IdentityUser<Guid> // Inherit from IdentityUser with Guid key
{
    // Custom properties from your original 'User' class
    [MaxLength(100)]
    public string FirstName { get; set; }

    [MaxLength(100)]
    public string LastName { get; set; }

    public DateTime DateRegistered { get; set; } = DateTime.UtcNow;

    // Simplified Address directly in ApplicationUser (as per your original User model)
    // For a real app, a separate Address entity linked to ApplicationUser is usually better.
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

    // Navigation properties to your e-commerce entities
    public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    public virtual ICollection<ShoppingCartItem> ShoppingCartItems { get; set; } = new HashSet<ShoppingCartItem>();

    // Note: IdentityUser<Guid> already provides:
    // Id (Guid), UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed,
    // PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed,
    // TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount
}