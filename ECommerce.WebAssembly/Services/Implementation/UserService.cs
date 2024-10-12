using ECommerceBrazorNet7.DTO;
using ECommerce.WebAssembly.Services.Contract;
using System.Net.Http.Json;

namespace ECommerce.WebAssembly.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<List<UserDTO>>> ListUser(string role, string found)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<UserDTO>>>($"User/List/{role}/{found}");
        }

        public async Task<ResponseDTO<UserDTO>> GetUser(int id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<UserDTO>>($"User/GetUser/{id}");
        }

        public async Task<ResponseDTO<SessionDTO>> Authorization(LoginDTO model)
        {
            var response = await _httpClient.PostAsJsonAsync("User/Authorization", model);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<SessionDTO>>();

            return result!;
        }

        public async Task<ResponseDTO<UserDTO>> CreateUser(UserDTO model)
        {
            var response = await _httpClient.PostAsJsonAsync("User/CreateUser", model);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<UserDTO>>();

            return result!;
        }       

        public async Task<ResponseDTO<bool>> UpdateUser(UserDTO model)
        {
            var response = await _httpClient.PutAsJsonAsync("User/UpdateUser", model);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();

            return result!;
        }

        public async Task<ResponseDTO<bool>> DeleteUser(int id)
        {
            return await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>($"User/DeleteUser/{id}");
        }
    }
}
