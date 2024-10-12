using System;
using System.Collections.Generic;

namespace ECommerceBrazorNet7.Model;

public partial class Sale
{
    public int IdSale { get; set; }

    public int? IdUser { get; set; }

    public decimal? Total { get; set; }

    public DateTime? CreationDate { get; set; }

    public virtual User? IdUserNavigation { get; set; }

    public virtual ICollection<SalesDetail> SalesDetails { get; set; } = new List<SalesDetail>();
}
