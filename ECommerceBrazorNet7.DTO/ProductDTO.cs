using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBrazorNet7.DTO
{
    public class ProductDTO
    {
        public int IdProduct { get; set; }
        [Required(ErrorMessage = "Ingrese nombre del producto")]
        public string? NameProduct { get; set; }

        [Required(ErrorMessage = "Ingrese una descripcion")]
        public string? Description { get; set; }

        public int? IdCategory { get; set; }

        [Required(ErrorMessage = "Ingrese el precio")]
        public decimal? Price { get; set; }

        [Required(ErrorMessage = "Ingrese el precio de oferta")]
        public decimal? OfferPrice { get; set; }

        [Required(ErrorMessage = "Ingrese la cantidad")]
        public int? Amount { get; set; }

        [Required(ErrorMessage = "Ingrese la imagen")]
        public string? Picture { get; set; }

        public DateTime? CreationDate { get; set; }

        public virtual CategoryDTO? IdCategoryNavigation { get; set; }

    }
}
