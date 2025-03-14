using OpenBazaar.Model.Categories.Dtos;
using OpenBazaar.Shared.Responses;

namespace OpenBazaar.Service.Categories.Abstracts;

public interface ICategoryService
{
    Task<ServiceResult<List<CategoryDto>>> GetAllAsync();
    Task<ServiceResult<CategoryDto>> GetByIdAsync(int id);
    Task<ServiceResult<CategoryDto>> CreateAsync(CreateCategoryRequest request);
    Task<ServiceResult> UpdateAsync(int id,UpdateCategoryRequest request);
    Task<ServiceResult> DeleteAsync(int id);
    Task<ServiceResult<CategoryWithListingsDto>> GetCategoryWithListingsAsync(int categoryId);
    Task<ServiceResult<List<CategoryWithListingsDto>>> GetCategoryWithListingsAsync();
}
