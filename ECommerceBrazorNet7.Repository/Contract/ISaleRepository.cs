using ECommerceBrazorNet7.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBrazorNet7.Repository.Contract
{
    public interface ISaleRepository: IGenericRepository<Sale>
    {
        Task<Sale> Register(Sale model);

    }
}
