using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceBrazorNet7.DTO;

namespace ECommerceBrazorNet7.Services.Contract
{
    public interface ISaleService
    {
        Task<SaleDTO> Register(SaleDTO model);
    }
}
