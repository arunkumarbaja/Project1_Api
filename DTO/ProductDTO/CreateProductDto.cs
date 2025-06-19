using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ProductDTO
{
    public class CreateProductDto
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; } = null!;

        [MaxLength(1000)]
        public string? Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [MaxLength(50)]
        public string? Sku { get; set; }

        public int StockQuantity { get; set; }
        public bool IsAvailable { get; set; } = true;

        public string? ImageUrl { get; set; }

        [Required]
        public Guid CategoryId { get; set; }
    }
}