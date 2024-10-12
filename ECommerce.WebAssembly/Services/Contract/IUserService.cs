using ECommerceBrazorNet7.DTO;

namespace ECommerce.WebAssembly.Services.Contract
{
    public interface IUserService
    {
        Task<ResponseDTO<List<UserDTO>>> ListUser(string role, string found);

        Task<ResponseDTO<UserDTO>> GetUser(int id);

        Task<ResponseDTO<SessionDTO>> Authorization(LoginDTO model);

        Task<ResponseDTO<UserDTO>> CreateUser(UserDTO model);

        Task<ResponseDTO<bool>> UpdateUser(UserDTO model);

        Task<ResponseDTO<bool>> DeleteUser(int id);
    }
}
