using DTO.ProductDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL.ECommerceServices.ProductService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();
        Task<ProductDto?> GetProductByIdAsync(Guid id);
        Task<IEnumerable<ProductDto>> GetProductsByCategoryAsync(Guid categoryId);
        Task<ProductDto> AddProductAsync(CreateProductDto dto);
        Task<bool> UpdateProductAsync(UpdateProductDto dto);
        Task<bool> DeleteProductAsync(Guid id);
        Task<bool> IsProductAvailable(Guid id);
        Task<int> GetProductStockAsync(Guid id);
    }
}
