﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBrazorNet7.DTO
{
    public class SaleDTO
    {
        public int IdSale { get; set; }

        public int? IdUser { get; set; }

        public decimal? Total { get; set; }

        public virtual ICollection<SalesDetailDTO> SalesDetails { get; set; } = new List<SalesDetailDTO>();
    }
}
