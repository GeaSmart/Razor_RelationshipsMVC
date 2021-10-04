using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmallExample.Entities
{
    public class User
    {
        
        [Required(ErrorMessage ="este campo es obligatorio")]
        [Key]
        public string Username { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int UserTypeId { get; set; }

        //propiedad de navegación
        public UserType UserType { get; set; }        
    }
}
