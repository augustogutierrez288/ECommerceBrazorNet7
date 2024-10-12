using System;
using System.Collections.Generic;

namespace ECommerceBrazorNet7.Model;

public partial class Product
{
    public int IdProduct { get; set; }

    public string? NameProduct { get; set; }

    public string? Description { get; set; }

    public int? IdCategory { get; set; }

    public decimal? Price { get; set; }

    public decimal? OfferPrice { get; set; }

    public int? Amount { get; set; }

    public string? Picture { get; set; }

    public DateTime? CreationDate { get; set; }

    public virtual Category? IdCategoryNavigation { get; set; }

    public virtual ICollection<SalesDetail> SalesDetails { get; set; } = new List<SalesDetail>();
}
