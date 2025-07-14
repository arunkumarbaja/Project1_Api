using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Category
    {

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }

        // Navigation properties
        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();


    }
}
