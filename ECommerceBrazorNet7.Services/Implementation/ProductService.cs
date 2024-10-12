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
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product> _modelRepository;
        private readonly IMapper _mapper;

        public ProductService(IGenericRepository<Product> modelRepository, IMapper mapper)
        {
            this._modelRepository = modelRepository;
            this._mapper = mapper;
        }

        public async Task<ProductDTO> GetProduct(int id)
        {
            try
            {
                var consult = this._modelRepository.Consult(p => p.IdProduct == id);
                consult = consult.Include(p => p.IdCategoryNavigation);
                var fromDBModel = await consult.FirstOrDefaultAsync();

                if (fromDBModel != null)
                    return this._mapper.Map<ProductDTO>(fromDBModel);
                else
                    throw new TaskCanceledException("No se encontraron coincidencias");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ProductDTO>> ListProduct(string found)
        {
            try
            {
                var consult = this._modelRepository.Consult(p =>
                    p.NameProduct.ToLower().Contains(found.ToLower())
                );

                consult = consult.Include(p => p.IdCategoryNavigation);

                List<ProductDTO> list = this._mapper.Map<List<ProductDTO>>(await consult.ToListAsync());
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ProductDTO>> ProductCatalog(string catalog, string found)
        {
            try
            {
                var consult = this._modelRepository.Consult(p =>
                    p.NameProduct.ToLower().Contains(found.ToLower()) && p.IdCategoryNavigation.NameCategory.ToLower().Contains(catalog.ToLower())
                );

                List<ProductDTO> list = this._mapper.Map<List<ProductDTO>>(await consult.ToListAsync());
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ProductDTO> CreateProduct(ProductDTO model)
        {
            try
            {
                var dbModel = this._mapper.Map<Product>(model);
                var rspModel = await this._modelRepository.Create(dbModel);

                if (rspModel.IdProduct != 0)
                {
                    return this._mapper.Map<ProductDTO>(rspModel);
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
        public async Task<bool> UpdateProduct(ProductDTO model)
        {
            try
            {
                var consult = this._modelRepository.Consult(p => p.IdProduct == model.IdProduct);
                var fromDBModel = await consult.FirstOrDefaultAsync();

                if (fromDBModel != null)
                {
                    fromDBModel.NameProduct = model.NameProduct;
                    fromDBModel.Description = model.Description;
                    fromDBModel.IdCategory = model.IdCategory;
                    fromDBModel.Price = model.Price;
                    fromDBModel.OfferPrice = model.OfferPrice;
                    fromDBModel.Amount = model.Amount;
                    fromDBModel.Picture = model.Picture;

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

        public async Task<bool> DeleteProduct(int id)
        {
            try
            {
                var consult = this._modelRepository.Consult(p => p.IdProduct == id);
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
    }
}
