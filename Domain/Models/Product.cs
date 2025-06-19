using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project1_Api.Models
{
    public class Product
    {

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [MaxLength(50)]
        public string Sku { get; set; } // Stock Keeping Unit

        public int StockQuantity { get; set; }
        public bool IsAvailable { get; set; } = true;

        public string ImageUrl { get; set; } // Path to the main product image

        public Guid CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();
        public virtual ICollection<ShoppingCartItem> ShoppingCartItems { get; set; } = new HashSet<ShoppingCartItem>();
    }
}
