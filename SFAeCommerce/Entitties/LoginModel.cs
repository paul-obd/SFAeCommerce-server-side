using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SFAeCommerce.Entitties
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Client Code is required")]
        public string ClientCode { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
