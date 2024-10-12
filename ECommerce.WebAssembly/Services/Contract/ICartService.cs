using ECommerceBrazorNet7.DTO;

namespace ECommerce.WebAssembly.Services.Contract
{
    public interface ICartService
    {
        event Action ShowItems;

        int AmountProduct();

        Task AddToCart(CartDTO model);

        Task DeleteFromCart(int idProduct);

        Task<List<CartDTO>> ReturnCart();

        Task ClearCart();
    }
}
