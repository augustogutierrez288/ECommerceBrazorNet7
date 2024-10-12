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
    public class DashboardService : IDashboardService
    {

        private readonly ISaleRepository _saleRepository;
        private readonly IGenericRepository<User> _userRepository;
        private readonly IGenericRepository<Product> _productRepository;

        public DashboardService(
            ISaleRepository saleRepository,
            IGenericRepository<User> userRepository, 
            IGenericRepository<Product> productRepository
            )
        {
            this._saleRepository = saleRepository;
            this._userRepository = userRepository;
            this._productRepository = productRepository;
        }

        private string Income()
        {
            var consult = this._saleRepository.Consult();
            decimal? income = consult.Sum(x => x.Total);
            return Convert.ToString(income);
        }

        private int Sales()
        {
            var consult = this._saleRepository.Consult();
            int total = consult.Count();
            return total;
        }

        private int Clients()
        {
            var consult = this._userRepository.Consult(u => u.Role.ToLower() == "cliente");
            int total = consult.Count();
            return total;
        }

        private int Products()
        {
            var consult = this._productRepository.Consult();
            int total = consult.Count();
            return total;
        }

        public DashboardDTO Resume()
        {
            try
            {
                DashboardDTO dashboardDTO = new DashboardDTO()
                {
                    TotalIncome = Income(),
                    TotalSales = Sales(),
                    TotalClients = Clients(),
                    TotalProducts = Products(),
                };

                return dashboardDTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
