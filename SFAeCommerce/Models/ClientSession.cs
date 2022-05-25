using System;
using System.Collections.Generic;

#nullable disable

namespace SFAeCommerce.Models
{
    public partial class ClientSession
    {
        public int ClientSessionId { get; set; }
        public string ClientCode { get; set; }
        public bool IsLoggedIn { get; set; }

        public virtual Client ClientCodeNavigation { get; set; }
    }
}
