using System;
using System.Collections.Generic;

#nullable disable

namespace SFAeCommerce.Models
{
    public partial class ItemPriceList
    {
        public long ItemPriceListId { get; set; }
        public string PriceListCode { get; set; }
        public string ItemCode { get; set; }
        public string UomCode { get; set; }
        public decimal Price { get; set; }
        public string CurrencyCode { get; set; }
        public bool? IsActive { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastEdited { get; set; }
        public bool IsTtc { get; set; }
        public double PriceMargin { get; set; }
        public double DefaultDiscount { get; set; }
        public decimal? AddedPrice { get; set; }
        public decimal? ReturnPrice { get; set; }

        public virtual Item ItemCodeNavigation { get; set; }
    }
}
