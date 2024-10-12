using ECommerce.WebAssembly.Services.Contract;
using ECommerceBrazorNet7.DTO;
using System.Data;
using System.Net.Http.Json;
using System;

namespace ECommerce.WebAssembly.Services.Implementation
{
    public class DashboardService : IDashboardService
    {
        private readonly HttpClient _httpClient;

        public DashboardService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<DashboardDTO>> Resume()
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<DashboardDTO>>($"Dashboard/Resume");
        }
    }
}
