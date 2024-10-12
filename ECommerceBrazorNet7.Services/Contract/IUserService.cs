using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceBrazorNet7.DTO;

namespace ECommerceBrazorNet7.Services.Contract
{
    public interface IUserService
    {
        Task<List<UserDTO>> ListUser(string role, string found);

        Task<UserDTO> GetUser(int id);

        Task<SessionDTO> Authorization(LoginDTO model);

        Task<UserDTO> CreateUser(UserDTO model);

        Task<bool> UpdateUser(UserDTO model);

        Task<bool> DeleteUser(int id);
    }
}
