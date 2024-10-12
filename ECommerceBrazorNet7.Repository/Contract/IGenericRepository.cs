using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBrazorNet7.Repository.Contract
{
    public interface IGenericRepository<TModel> where TModel : class
    {
        IQueryable<TModel> Consult(Expression<Func<TModel, bool>> ? filter = null);

        Task<TModel> Create(TModel model);
        Task<bool> Update(TModel model);
        Task<bool> Delete(TModel model);

    }
}
