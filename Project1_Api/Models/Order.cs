using Project1.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public enum OrderStatus // Make sure this enum is defined or accessible
{
    Pending, Paid, Shipped, Delivered, Cancelled
}

public class Order
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public Guid UserId { get; set; } // Foreign key to ApplicationUser, still Guid
    [ForeignKey("UserId")]
    public virtual ApplicationUser User { get; set; } // <<<< CHANGE TO ApplicationUser

    public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    public OrderStatus Status { get; set; } = OrderStatus.Pending;

    [Required]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal TotalAmount { get; set; }

    [Required]
    [MaxLength(200)]
    public string ShippingAddressStreet { get; set; }
    [Required]
    [MaxLength(100)]
    public string ShippingAddressCity { get; set; }
    [Required]
    [MaxLength(100)]
    public string ShippingAddressState { get; set; }
    [Required]
    [MaxLength(20)]
    public string ShippingAddressPostalCode { get; set; }
    [Required]
    [MaxLength(100)]
    public string ShippingAddressCountry { get; set; }

    [MaxLength(50)]
    public string PaymentTransactionId { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();
}