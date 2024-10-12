using ECommerceBrazorNet7.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceBrazorNet7.DTO;

namespace ECommerceBrazorNet7.Services.Contract
{
    public interface IProductService
    {
        
        Task<List<ProductDTO>> ListProduct(string found);

        Task<List<ProductDTO>> ProductCatalog(string catalog, string found);

        Task<ProductDTO> GetProduct(int id);

        Task<ProductDTO> CreateProduct(ProductDTO model);

        Task<bool> UpdateProduct(ProductDTO model);

        Task<bool> DeleteProduct(int id);
    }
}
