using System;
using System.Collections.Generic;

namespace ECommerceBrazorNet7.Model;

public partial class SalesDetail
{
    public int IdSalesDetail { get; set; }

    public int? IdSale { get; set; }

    public int? IdProduct { get; set; }

    public int? Amount { get; set; }

    public decimal? Total { get; set; }

    public virtual Product? IdProductNavigation { get; set; }

    public virtual Sale? IdSaleNavigation { get; set; }
}
