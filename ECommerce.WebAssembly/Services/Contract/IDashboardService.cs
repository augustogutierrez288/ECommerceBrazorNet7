using ECommerceBrazorNet7.DTO;
using System.Net.Http;

namespace ECommerce.WebAssembly.Services.Contract
{
    public interface IDashboardService
    {
        public Task<ResponseDTO<DashboardDTO>> Resume();
       
    }
}
