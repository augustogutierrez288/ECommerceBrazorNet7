using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using ECommerceBrazorNet7.Repository.Contract;
using ECommerceBrazorNet7.Repository.DBContext;

namespace ECommerceBrazorNet7.Repository.Implementation
{
    public class GenericRepository<TModel> : IGenericRepository<TModel> where TModel : class
    {
        private readonly DbecommerceContext _dbContext;

        public GenericRepository(DbecommerceContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public IQueryable<TModel> Consult(Expression<Func<TModel, bool>>? filter = null)
        {
            IQueryable<TModel> consult = (filter == null) ? this._dbContext.Set<TModel>() : this._dbContext.Set<TModel>().Where(filter);

            return consult;
        }

        public async Task<TModel> Create(TModel model)
        {
            try
            {
                this._dbContext.Set<TModel>().Add(model);
                await this._dbContext.SaveChangesAsync();

                return model;
            }
            catch 
            {
                throw;
            }
        }
        public async Task<bool> Update(TModel model)
        {
            try
            {
                this._dbContext.Set<TModel>().Update(model);
                await this._dbContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> Delete(TModel model)
        {
            try
            {
                this._dbContext.Set<TModel>().Remove(model);
                await this._dbContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}
