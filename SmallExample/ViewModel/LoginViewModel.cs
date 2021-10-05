using SmallExample.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmallExample.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name ="Nombre de usuario")]
        public string Username { get; set; }

        [Display(Name = "Ingrese su contraseña")]
        [DataType(DataType.Password)]        
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name = "Confirme su contraseña")]
        public string RePassword { get; set; }

        public string Address { get; set; }

        [EmailAddress(ErrorMessage ="No tiene formato de email")]
        public string Email { get; set; }

        [Display(Name ="Tipo de usuario")]
        public int UserTypeId { get; set; }

        //public UserType UserType { get; set; }
    }
}
