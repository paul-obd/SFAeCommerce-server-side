using System;
using System.Collections.Generic;

#nullable disable

namespace SFAeCommerce.Models
{
    public partial class ItemBrand
    {
        public string ItemBrandCode { get; set; }
        public string Description { get; set; }
        public string AltDescription { get; set; }
        public long? ImageId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastEdited { get; set; }
        public string CurrencyCode { get; set; }
    }
}
