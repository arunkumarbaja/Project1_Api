﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Project1.Models;

namespace DTO.ProductDTO
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ProductDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Product name is required.")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Product name must be between 3 and 200 characters.")]
        public string Name { get; set; } = null!;

        [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.01, 1000000, ErrorMessage = "Price must be a positive number.")]
        public decimal Price { get; set; }

        [StringLength(50, ErrorMessage = "SKU cannot exceed 50 characters.")]
        public string? Sku { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Stock quantity cannot be negative.")]
        public int StockQuantity { get; set; }

        public bool IsAvailable { get; set; }

        [Url(ErrorMessage = "Image URL must be a valid URL.")]
        public string? ImageUrl { get; set; }

        [Required(ErrorMessage = "CategoryId is required.")]
        public Guid CategoryId { get; set; }

        public string? CategoryName { get; set; }

        public DateTime DateCreated { get; set; }
    }

}
