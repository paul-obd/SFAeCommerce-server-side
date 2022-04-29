using System;
using System.Collections.Generic;

#nullable disable

namespace SFAeCommerce.Models
{
    public partial class WarehouseCurrentStock
    {
        public long WarehouseCurrentStockId { get; set; }
        public string WarehouseCode { get; set; }
        public string ItemCode { get; set; }
        public string UomCode { get; set; }
        public decimal Quantity { get; set; }
        public string SecondaryUomCode { get; set; }
        public decimal? SecondaryUomQuantity { get; set; }
        public byte Status { get; set; }
        public int? ReasonId { get; set; }
        public bool? IsActive { get; set; }
        public byte IsProcessed { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastEdited { get; set; }
        public int ItemIdentifier { get; set; }

        public virtual Item ItemCodeNavigation { get; set; }
    }
}
