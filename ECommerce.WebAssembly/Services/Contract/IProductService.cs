using ECommerceBrazorNet7.DTO;

namespace ECommerce.WebAssembly.Services.Contract
{
    public interface IProductService
    {
        Task<ResponseDTO<List<ProductDTO>>> ListProduct(string found);

        Task<ResponseDTO<List<ProductDTO>>> ProductCatalog(string category, string found);

        Task<ResponseDTO<ProductDTO>> GetProduct(int id);

        Task<ResponseDTO<ProductDTO>> CreateProduct(ProductDTO model);

        Task<ResponseDTO<bool>> UpdateProduct(ProductDTO model);

        Task<ResponseDTO<bool>> DeleteProduct(int id);
    }
}
