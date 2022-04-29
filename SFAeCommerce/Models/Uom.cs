using System;
using System.Collections.Generic;

#nullable disable

namespace SFAeCommerce.Models
{
    public partial class Uom
    {
        public string UomCode { get; set; }
        public string Description { get; set; }
        public string AltDescription { get; set; }
        public string Symbol { get; set; }
        public bool? IsActive { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastEdited { get; set; }
        public int DecimalDigits { get; set; }
    }
}
