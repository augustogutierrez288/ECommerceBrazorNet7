using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceBrazorNet7.DTO;

namespace ECommerceBrazorNet7.Services.Contract
{
    public interface ICategoryService
    {
        Task<List<CategoryDTO>> ListCategory(string found);

        Task<CategoryDTO> GetCategory(int id);

        Task<CategoryDTO> CreateCategory(CategoryDTO model);

        Task<bool> UpdateCategory(CategoryDTO model);

        Task<bool> DeleteCategory(int id);
    }
}
