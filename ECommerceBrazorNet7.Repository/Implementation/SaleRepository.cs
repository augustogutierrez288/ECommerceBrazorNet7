using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceBrazorNet7.Model;
using ECommerceBrazorNet7.Repository.Contract;
using ECommerceBrazorNet7.Repository.DBContext;

namespace ECommerceBrazorNet7.Repository.Implementation
{
    public class SaleRepository : GenericRepository<Sale>, ISaleRepository
    {

        private readonly DbecommerceContext _dbContext;

        public SaleRepository(DbecommerceContext dbContext) : base(dbContext)
        {
            {
                this._dbContext = dbContext;
            }
        }

        public async Task<Sale> Register(Sale model)
        {
            Sale generatedSales = new Sale();

            using (var transaction = this._dbContext.Database.BeginTransaction())
            {
                try
                {
                    foreach (SalesDetail sd in model.SalesDetails)
                    {
                        Product productFound = this._dbContext.Products.Where(p => p.IdProduct == sd.IdProduct).First();

                        productFound.Amount = productFound.Amount - sd.Amount;
                        this._dbContext.Products.Update(productFound);
                    }

                    await this._dbContext.SaveChangesAsync();
                    await this._dbContext.Sales.AddAsync(model);
                    await this._dbContext.SaveChangesAsync();
                    generatedSales = model;

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }

            return generatedSales;
        }
    }
}
