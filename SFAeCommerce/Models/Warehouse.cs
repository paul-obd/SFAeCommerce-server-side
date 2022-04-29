using System;
using System.Collections.Generic;

#nullable disable

namespace SFAeCommerce.Models
{
    public partial class Warehouse
    {
        public string WarehouseCode { get; set; }
        public string Description { get; set; }
        public string AltDescription { get; set; }
        public string MainWarehouseCode { get; set; }
        public bool? IsActive { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastEdited { get; set; }
        public string Type { get; set; }
        public decimal Volume { get; set; }
        public decimal MaxWeight { get; set; }
        public double? Width { get; set; }
        public double? Height { get; set; }
        public double? Depth { get; set; }
    }
}
