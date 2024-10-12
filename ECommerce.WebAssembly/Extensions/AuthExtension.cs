using Blazored.LocalStorage;
using ECommerceBrazorNet7.DTO;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace ECommerce.WebAssembly.Extensions
{
    public class AuthExtension : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;
        private ClaimsPrincipal _noInformation = new ClaimsPrincipal(new ClaimsIdentity());

        public AuthExtension(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var userSession = await _localStorage.GetItemAsync<SessionDTO>("userSession");

            if(userSession == null)
                return await Task.FromResult(new AuthenticationState(_noInformation));
            
            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, userSession.IdUser.ToString()),
                    new Claim(ClaimTypes.Name, userSession.FullName),
                    new Claim(ClaimTypes.Email, userSession.Email),
                    new Claim(ClaimTypes.Role, userSession.Role),

                }, "JwtAuth"));

            return await Task.FromResult(new AuthenticationState(claimsPrincipal));
        }

        public async Task UpdateStateAuthentication(SessionDTO? userSession)
        {
            ClaimsPrincipal claimsPrincipal;

            if(userSession != null)
            {
                claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, userSession.IdUser.ToString()),
                    new Claim(ClaimTypes.Name, userSession.FullName),
                    new Claim(ClaimTypes.Email, userSession.Email),
                    new Claim(ClaimTypes.Role, userSession.Role),

                }, "JwtAuth"));

                await _localStorage.SetItemAsync("userSession", userSession);
            }
            else
            {
                claimsPrincipal = _noInformation;
                await _localStorage.RemoveItemAsync("userSession");
            }

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }
    }
}
