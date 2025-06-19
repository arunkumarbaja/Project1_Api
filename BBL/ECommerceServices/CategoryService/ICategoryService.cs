using DTO.CategoryDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBL.ECommerceServices.CategoryService
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
        Task<CategoryDto?> GetCategoryByIdAsync(Guid id);
        Task<CategoryDto> AddCategoryAsync(CreateCategoryDto dto);
        Task<bool> UpdateCategoryAsync(UpdateCategoryDto dto);
        Task<bool> DeleteCategoryAsync(Guid id);
        Task<bool> CategoryExistsAsync(Guid id);
    }
}
