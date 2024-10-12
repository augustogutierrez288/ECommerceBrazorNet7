using ECommerceBrazorNet7.DTO;
using ECommerce.WebAssembly.Services.Contract;
using System.Net.Http.Json;

namespace ECommerce.WebAssembly.Services.Implementation
{
    public class SaleService : ISaleService
    {
        private readonly HttpClient _httpClient;

        public SaleService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<SaleDTO>> Register(SaleDTO model)
        {
            var response = await _httpClient.PostAsJsonAsync("Sale/Register", model);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<SaleDTO>>();

            return result!;
        }
    }
}
