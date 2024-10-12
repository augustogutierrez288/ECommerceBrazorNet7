using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using ECommerceBrazorNet7.Model;
using ECommerceBrazorNet7.DTO;
using ECommerceBrazorNet7.Repository.Contract;
using ECommerceBrazorNet7.Services.Contract;
using AutoMapper;

namespace ECommerceBrazorNet7.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> _modelRepository;
        private readonly IMapper _mapper;

        public UserService(IGenericRepository<User> modelRepository, IMapper mapper)
        {
            this._modelRepository = modelRepository;
            this._mapper = mapper;

        }

        public async Task<SessionDTO> Authorization(LoginDTO model)
        {
            try
            {
                var consult = this._modelRepository.Consult(p => p.Email == model.Email && p.Password == model.Password);
                var fromDBModel = await consult.FirstOrDefaultAsync();

                if (fromDBModel != null) 
                {
                    return this._mapper.Map<SessionDTO>(fromDBModel);
                }
                else
                {
                    throw new TaskCanceledException("No se encontraron coincidencias");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UserDTO> CreateUser(UserDTO model)
        {
            try
            {
                var dbModel = this._mapper.Map<User>(model);
                var rspModel = await this._modelRepository.Create(dbModel);

                if(rspModel.IdUser != 0)
                {
                    return this._mapper.Map<UserDTO>(rspModel);
                }
                else
                {
                    throw new TaskCanceledException("No se pudo crear");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteUser(int id)
        {
            try
            {
                var consult = this._modelRepository.Consult(p => p.IdUser == id);
                var fromDBModel = await consult.FirstOrDefaultAsync();

                if (fromDBModel != null)
                {
                    var response = await this._modelRepository.Delete(fromDBModel);
                    if(!response)
                        throw new TaskCanceledException("No se pudo eliminar");
                    return response;
                }
                else
                {
                    throw new TaskCanceledException("No se encontro resultado");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UserDTO> GetUser(int id)
        {
            try
            {
                var consult = this._modelRepository.Consult(p => p.IdUser == id);

                var fromDBModel = await consult.FirstOrDefaultAsync();

                if (fromDBModel != null)
                    return this._mapper.Map<UserDTO>(fromDBModel);
                else
                    throw new TaskCanceledException("No se encontraron coincidencias");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<UserDTO>> ListUser(string role, string found)
        {
            try
            {
                var consult = this._modelRepository.Consult(p =>
                    p.Role == role && p.FullName.ToLower().Contains(found.ToLower())
                );

                List<UserDTO> list = this._mapper.Map<List<UserDTO>>(await consult.ToListAsync());
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateUser(UserDTO model)
        {
            try
            {
                var consult = this._modelRepository.Consult(p => p.IdUser == model.IdUser);
                var fromDBModel = await consult.FirstOrDefaultAsync();

                if(fromDBModel != null)
                {
                    fromDBModel.FullName = model.FullName;
                    fromDBModel.Email = model.Email;
                    fromDBModel.Password = model.Password;
                    var response = await this._modelRepository.Update(fromDBModel);

                    if (!response)
                        throw new TaskCanceledException("No se pudo editar");
                    return response;
                    
                }
                else
                {
                    throw new TaskCanceledException("No se pudo encontrar");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
