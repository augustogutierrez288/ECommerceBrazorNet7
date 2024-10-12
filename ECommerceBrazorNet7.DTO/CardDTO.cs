using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBrazorNet7.DTO
{
    public class CardDTO
    {
        [Required(ErrorMessage = "Ingrese titular")]
        public string? Holder {  get; set; }

        [Required(ErrorMessage = "Ingrese numero")]
        public string? Number { get; set; }

        [Required(ErrorMessage = "Ingrese vigencia")]
        public string? Validity { get; set; }

        [Required(ErrorMessage = "Ingrese codigo de seguridad")]
        public string? CVV { get; set; }
    }
}
