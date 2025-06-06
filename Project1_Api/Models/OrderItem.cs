using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project1.Models
{
    public class OrderItem
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid OrderId { get; set; }
        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }

        [Required]
        public Guid ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; } // Reference to the product

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal UnitPriceAtPurchase { get; set; } // Price of the product AT THE TIME OF ORDER

        // Optional: Store product name at time of purchase in case product name changes later
        // [Required]
        // [MaxLength(200)]
        // public string ProductNameAtPurchase { get; set; }

        [NotMapped]
        public decimal LineTotal => Quantity * UnitPriceAtPurchase;
    }
}
