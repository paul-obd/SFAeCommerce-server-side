using System;
using System.Collections.Generic;

#nullable disable

namespace SFAeCommerce.Models
{
    public partial class Item
    {
        public Item()
        {
            AttributeValueEntities = new HashSet<AttributeValueEntity>();
            Images = new HashSet<Image>();
            ItemPriceLists = new HashSet<ItemPriceList>();
            WarehouseCurrentStocks = new HashSet<WarehouseCurrentStock>();
        }

        public string ItemCode { get; set; }
        public string Description { get; set; }
        public string AltDescription { get; set; }
        public string ItemErpCode { get; set; }
        public string TaxCode { get; set; }
        public string BaseUomCode { get; set; }
        public string MainUomCode { get; set; }
        public string BrandCode { get; set; }
        public byte DistributionType { get; set; }
        public int? ShortageLimit { get; set; }
        public bool? IsActive { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastEdited { get; set; }
        public string PurchaseUomCode { get; set; }
        public string StockUomCode { get; set; }
        public bool IsConsignment { get; set; }
        public int ReturnType { get; set; }
        public int Status { get; set; }
        public bool IsDual { get; set; }
        public int? ItemType { get; set; }
        public int ItemOrder { get; set; }
        public bool IsNew { get; set; }

        public virtual ICollection<AttributeValueEntity> AttributeValueEntities { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<ItemPriceList> ItemPriceLists { get; set; }
        public virtual ICollection<WarehouseCurrentStock> WarehouseCurrentStocks { get; set; }
    }
}
