using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmallExample.ViewModel
{
    public class LoginViewModel
    {
        
        public string Username { get; set; }

        [DataType(DataType.Password)]        
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password")]
        public string RePassword { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
}
