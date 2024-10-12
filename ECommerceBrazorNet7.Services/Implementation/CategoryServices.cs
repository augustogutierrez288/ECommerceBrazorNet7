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
    public class CategoryServices : ICategoryService
    {
        private readonly IGenericRepository<Category> _modelRepository;
        private readonly IMapper _mapper;

        public CategoryServices(IGenericRepository<Category> modelRepository, IMapper mapper)
        {
            this._modelRepository = modelRepository;
            this._mapper = mapper;

        }

        public async Task<CategoryDTO> CreateCategory(CategoryDTO model)
        {
            try
            {
                var dbModel = this._mapper.Map<Category>(model);
                var rspModel = await this._modelRepository.Create(dbModel);

                if (rspModel.IdCategory != 0)
                {
                    return this._mapper.Map<CategoryDTO>(rspModel);
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

        public async Task<bool> DeleteCategory(int id)
        {
            try
            {
                var consult = this._modelRepository.Consult(p => p.IdCategory == id);
                var fromDBModel = await consult.FirstOrDefaultAsync();

                if (fromDBModel != null)
                {
                    var response = await this._modelRepository.Delete(fromDBModel);
                    if (!response)
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

        public async Task<CategoryDTO> GetCategory(int id)
        {
            try
            {
                var consult = this._modelRepository.Consult(p => p.IdCategory == id);

                var fromDBModel = await consult.FirstOrDefaultAsync();

                if (fromDBModel != null)
                    return this._mapper.Map<CategoryDTO>(fromDBModel);
                else
                    throw new TaskCanceledException("No se encontraron coincidencias");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<CategoryDTO>> ListCategory(string found)
        {
            try
            {
                var consult = this._modelRepository.Consult(p =>
                    p.NameCategory.ToLower().Contains(found.ToLower())
                );

                List<CategoryDTO> list = this._mapper.Map<List<CategoryDTO>>(await consult.ToListAsync());
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateCategory(CategoryDTO model)
        {
            try
            {
                var consult = this._modelRepository.Consult(p => p.IdCategory == model.IdCategory);
                var fromDBModel = await consult.FirstOrDefaultAsync();

                if (fromDBModel != null)
                {
                    fromDBModel.NameCategory = model.NameCategory;
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
