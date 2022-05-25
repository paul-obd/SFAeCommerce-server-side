using SFAeCommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFAeCommerce.Entitties
{
    public class LoginClientDto
    {
        public Client client { get; set; }
        public string token { get; set; }
    }
}
