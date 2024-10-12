using ECommerceBrazorNet7.DTO;

namespace ECommerce.WebAssembly.Services.Contract
{
    public interface ICategoryService
    {
        Task<ResponseDTO<List<CategoryDTO>>> ListCategory(string found);

        Task<ResponseDTO<CategoryDTO>> GetCategory(int id);

        Task<ResponseDTO<CategoryDTO>> CreateCategory(CategoryDTO model);

        Task<ResponseDTO<bool>> Updatecategory(CategoryDTO model);

        Task<ResponseDTO<bool>> DeleteCategory(int id);
    }
}
