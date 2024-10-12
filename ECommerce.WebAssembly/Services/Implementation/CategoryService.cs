using ECommerceBrazorNet7.DTO;
using ECommerce.WebAssembly.Services.Contract;
using System.Net.Http.Json;
using System.Data;
using System;

namespace ECommerce.WebAssembly.Services.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<List<CategoryDTO>>> ListCategory(string found)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<CategoryDTO>>>($"Category/List/{found}");
        }

        public async Task<ResponseDTO<CategoryDTO>> GetCategory(int id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<CategoryDTO>>($"Category/GetCategory/{id}");
        }

        public async Task<ResponseDTO<CategoryDTO>> CreateCategory(CategoryDTO model)
        {
            var response = await _httpClient.PostAsJsonAsync("Category/CreateCategory", model);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<CategoryDTO>>();

            return result!;
        }

        public async Task<ResponseDTO<bool>> Updatecategory(CategoryDTO model)
        {
            var response = await _httpClient.PutAsJsonAsync("Category/UpdateCategory", model);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();

            return result!;
        }

        public async Task<ResponseDTO<bool>> DeleteCategory(int id)
        {
            return await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>($"Category/DeleteCategory?id={id}");
        }
    }
}
