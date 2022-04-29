using System;
using System.Collections.Generic;

#nullable disable

namespace SFAeCommerce.Models
{
    public partial class PriceList
    {
        public string PriceListCode { get; set; }
        public string Description { get; set; }
        public string AltDescription { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsActive { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastEdited { get; set; }
    }
}
