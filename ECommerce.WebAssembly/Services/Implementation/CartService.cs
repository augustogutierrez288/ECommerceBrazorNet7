using Blazored.LocalStorage;
using Blazored.Toast.Services;
using ECommerceBrazorNet7.DTO;
using ECommerce.WebAssembly.Services.Contract;

namespace ECommerce.WebAssembly.Services.Implementation
{
    public class CartService : ICartService
    {
        private ILocalStorageService _localStorageService;
        private ISyncLocalStorageService _syncLocalStorageService;
        private IToastService _toastService;

        public CartService(
            ILocalStorageService localStorageService, 
            ISyncLocalStorageService syncLocalStorageService, 
            IToastService toastService
            )
        {
            _localStorageService = localStorageService;
            _syncLocalStorageService = syncLocalStorageService;
            _toastService = toastService;
        }

        public event Action ShowItems;

        public async Task AddToCart(CartDTO model)
        {
            try
            {
                var cart = await _localStorageService.GetItemAsync<List<CartDTO>>("cart");

                if (cart == null) 
                    cart = new List<CartDTO>();

                var itemsFound = cart.FirstOrDefault(i => i.Product.IdProduct == model.Product.IdProduct );

                if (itemsFound != null) 
                    cart.Remove(itemsFound);

                cart.Add(model);
                await _localStorageService.SetItemAsync("cart", cart);

                if (itemsFound != null)
                    _toastService.ShowSuccess("Product fue actualizado en carrito");
                else
                    _toastService.ShowSuccess("Producto fue agregado al carrito");

                ShowItems.Invoke();
            }
            catch
            {
                _toastService.ShowError("No se pudo agregar al carrito");
            }
        }

        public int AmountProduct()
        {
            var cart = _syncLocalStorageService.GetItem<List<CartDTO>>("cart");
            return cart == null ? 0 : cart.Count();
        }

        public async Task<List<CartDTO>> ReturnCart()
        {
            var cart = await _localStorageService.GetItemAsync<List<CartDTO>>("cart");

            if (cart == null)
                cart = new List<CartDTO>();

            return cart;
        }

        public async Task DeleteFromCart(int idProduct)
        {
            try
            {
                var cart = await _localStorageService.GetItemAsync<List<CartDTO>>("cart");

                if(cart != null)
                {
                    var element = cart.FirstOrDefault(i => i.Product.IdProduct == idProduct);
                    if(element != null)
                    {
                        cart.Remove(element);
                        await _localStorageService.SetItemAsync("cart", cart);
                        ShowItems.Invoke();
                    }
                }
            }
            catch
            {

            }
        }

        public async Task ClearCart()
        {
            await _localStorageService.RemoveItemAsync("cart");
            ShowItems.Invoke();
        }
    }
}
