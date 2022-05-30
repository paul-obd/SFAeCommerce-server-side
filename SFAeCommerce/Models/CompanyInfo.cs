using System;
using System.Collections.Generic;

#nullable disable

namespace SFAeCommerce.Models
{
    public partial class CompanyInfo
    {
        public int CompanyInfoId { get; set; }
        public string CompanyName { get; set; }
        public long? Phone1 { get; set; }
        public long? Phone2 { get; set; }
        public string Email { get; set; }
        public string InstagramLink { get; set; }
        public string FacebookLink { get; set; }
        public string LinkedinLink { get; set; }
        public string TwitterLink { get; set; }
        public string Location { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
    }
}
