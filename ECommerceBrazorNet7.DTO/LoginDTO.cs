﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBrazorNet7.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Ingrese correo electronico")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Ingresar contraseña")]
        public string? Password { get; set; }
    }
}
