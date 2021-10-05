using Microsoft.AspNetCore.Mvc.Rendering;
using SmallExample.Controllers;
using SmallExample.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmallExample.ViewModel
{
    public class UserViewModel
    {
        public UserViewModel(SelectList listado)
        {
            this.ListaTiposUsuarios = listado;
        }

        [Required]
        public string Username { get; set; }
        public string Address { get; set; }

        [EmailAddress(ErrorMessage ="el email debe estar correctamente formateado")]
        public string Email { get; set; }
        [Display(Name ="Selecione tipo de usuario")]
        public int UserTypeId { get; set; }
        public SelectList ListaTiposUsuarios { get; set; }
    }
}
