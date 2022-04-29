using System;
using System.Collections.Generic;

#nullable disable

namespace SFAeCommerce.Models
{
    public partial class Currency
    {
        public string CurrencyCode { get; set; }
        public string Description { get; set; }
        public string AltDescription { get; set; }
        public string Symbol { get; set; }
        public double Ratio { get; set; }
        public bool IsMain { get; set; }
        public bool? IsActive { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastEdited { get; set; }
        public string ErpCurrencyCode { get; set; }
        public double? DeadAmount { get; set; }
    }
}
