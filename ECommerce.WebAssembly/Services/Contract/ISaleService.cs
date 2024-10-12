using ECommerceBrazorNet7.DTO;

namespace ECommerce.WebAssembly.Services.Contract
{
    public interface ISaleService
    {
        Task<ResponseDTO<SaleDTO>> Register(SaleDTO model);
    }
}
