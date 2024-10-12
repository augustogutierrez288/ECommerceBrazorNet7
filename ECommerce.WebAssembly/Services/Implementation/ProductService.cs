using ECommerceBrazorNet7.DTO;
using ECommerce.WebAssembly.Services.Contract;
using System.Net.Http.Json;
using System.Data;

namespace ECommerce.WebAssembly.Services.Implementation
{
    public class ProductService: IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<ProductDTO>> GetProduct(int id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<ProductDTO>>($"Product/GetProduct/{id}");
        }

        public async Task<ResponseDTO<List<ProductDTO>>> ListProduct(string found)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<ProductDTO>>>($"Product/List/{found}");
        }

        public async Task<ResponseDTO<List<ProductDTO>>> ProductCatalog(string category, string found)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<ProductDTO>>>($"Product/Catalog/{category}/{found}");
        }

        public async Task<ResponseDTO<ProductDTO>> CreateProduct(ProductDTO model)
        {
            var response = await _httpClient.PostAsJsonAsync("Product/CreateProduct", model);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<ProductDTO>>();

            return result!;
        }

        public async Task<ResponseDTO<bool>> UpdateProduct(ProductDTO model)
        {
            var response = await _httpClient.PutAsJsonAsync("Product/UpdateProduct", model);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();

            return result!;
        }

        public async Task<ResponseDTO<bool>> DeleteProduct(int id)
        {
            return await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>($"Product/DeleteProduct/{id}");
        }
        
    }
}
