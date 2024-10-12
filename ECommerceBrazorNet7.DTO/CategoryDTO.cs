using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBrazorNet7.DTO
{
    public class CategoryDTO
    {
        public int IdCategory { get; set; }

        [Required(ErrorMessage = "Ingrese nombre")]
        public string? NameCategory { get; set; }

    }
}
