using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBrazorNet7.DTO
{
    public class UserDTO
    {
        public int IdUser { get; set; }

        [Required(ErrorMessage = "Ingrese nombre completo")]
        public string? FullName { get; set; }

        [Required(ErrorMessage = "Ingrese correo electronico")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Ingresar contraseña")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Confirme contraseña")]
        public string? ConfirmPassword { get; set; }

        public string? Role { get; set; }

    }
}
