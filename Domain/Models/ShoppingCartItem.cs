using Project1_Api.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ShoppingCartItem
{
    [Key]
    public Guid Id { get; set; }

    [Display(Name = "User ID")]
    public Guid? UserId { get; set; }

    [MaxLength(128, ErrorMessage = "Session ID cannot exceed 128 characters.")]
    [Display(Name = "Session ID")]
    public string? SessionId { get; set; }

    [Required(ErrorMessage = "Product ID is required.")]
    [Display(Name = "Product ID")]
    public Guid ProductId { get; set; }

    [Required(ErrorMessage = "Quantity is required.")]
    [Range(1, 100, ErrorMessage = "Quantity must be between 1 and 100.")]
    public int Quantity { get; set; }

    [DataType(DataType.DateTime)]
    [Display(Name = "Date Added")]
    public DateTime DateAdded { get; set; } = DateTime.UtcNow;

    [NotMapped]
    [Display(Name = "Line Total")]
    public decimal LineTotal => Quantity * 0; // Product.Price will be injected/calculated separately

    public virtual Product Product { get; set; }    

}