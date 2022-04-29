using System;
using System.Collections.Generic;

#nullable disable

namespace SFAeCommerce.Models
{
    public partial class ItemUom
    {
        public long ItemUomId { get; set; }
        public string ItemCode { get; set; }
        public string Barcode { get; set; }
        public string UomCode { get; set; }
        public double RatioToBaseUom { get; set; }
        public decimal? DefaultDiscount { get; set; }
        public bool? IsActive { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastEdited { get; set; }
        public decimal Weight { get; set; }
        public decimal Volume { get; set; }
        public string ConsignmentItemCode { get; set; }
        public string PricingUomCode { get; set; }
        public double? ConversionMargin { get; set; }
        public int? PackTypeId { get; set; }
        public string ItemUomErpCode { get; set; }
        public double? Width { get; set; }
        public double? Height { get; set; }
        public double? Depth { get; set; }
        public string LastModifiedBy { get; set; }
        public int IsProcessed { get; set; }
    }
}
