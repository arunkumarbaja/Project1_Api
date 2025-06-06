using Project1.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ShoppingCartItem
{
    [Key]
    public Guid Id { get; set; }

    // For logged-in users
    public Guid? UserId { get; set; } // Foreign key to ApplicationUser, still Guid
    [ForeignKey("UserId")]
    public virtual ApplicationUser User { get; set; } // <<<< CHANGE TO ApplicationUser

    // For anonymous users
    [MaxLength(128)] // Good to have a max length
    public string? SessionId { get; set; }

    [Required]
    public Guid ProductId { get; set; }
    [ForeignKey("ProductId")]
    public virtual Product Product { get; set; }

    [Required]
    [Range(1, 100)]
    public int Quantity { get; set; }

    public DateTime DateAdded { get; set; } = DateTime.UtcNow;

    [NotMapped]
    public decimal LineTotal => Product != null ? Quantity * Product.Price : 0;
}