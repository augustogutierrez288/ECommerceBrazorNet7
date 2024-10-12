using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ECommerceBrazorNet7.Model;
using ECommerceBrazorNet7.DTO;
using ECommerceBrazorNet7.Repository.Contract;
using ECommerceBrazorNet7.Services.Contract;
using AutoMapper;

namespace ECommerceBrazorNet7.Services.Implementation
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _modelRepository;
        private readonly IMapper _mapper;

        public SaleService(ISaleRepository modelRepository, IMapper mapper)
        {
            this._modelRepository = modelRepository;
            this._mapper = mapper;
        }

        public async Task<SaleDTO> Register(SaleDTO model)
        {
            try
            {
                var dbModel = this._mapper.Map<Sale>(model);
                var generateSales = await this._modelRepository.Create(dbModel);

                if (generateSales.IdSale == 0)
                    throw new TaskCanceledException("No se pudo registrar");
                return this._mapper.Map<SaleDTO>(generateSales);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
