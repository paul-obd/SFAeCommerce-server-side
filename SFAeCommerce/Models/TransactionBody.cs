using System;
using System.Collections.Generic;

#nullable disable

namespace SFAeCommerce.Models
{
    public partial class TransactionBody
    {
        public long TransactionBodyId { get; set; }
        public long TransactionHeaderId { get; set; }
        public int LineId { get; set; }
        public string ItemCode { get; set; }
        public int? ItemStatus { get; set; }
        public string UomCode { get; set; }
        public double RequestedQuantity { get; set; }
        public double ApprovedQuantity { get; set; }
        public decimal? ItemDefaultPrice { get; set; }
        public decimal? TotalDefaultPrice { get; set; }
        public decimal? TaxPercentage { get; set; }
        public decimal? TotalTax { get; set; }
        public decimal? DefaultDiscountPercentage { get; set; }
        public decimal? PromotionDiscountPercentage { get; set; }
        public decimal? TotalFinalPrice { get; set; }
        public decimal? TotalFinalDiscount { get; set; }
        public long? PromotionId { get; set; }
        public string CurrencyCode { get; set; }
        public decimal? CurrencyRate { get; set; }
        public long? SectionId { get; set; }
        public bool IsActive { get; set; }
        public byte IsProcessed { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? LastEdited { get; set; }
        public string PackageBarcode { get; set; }
        public byte PackageType { get; set; }
        public string Comment { get; set; }
        public int ReasonId { get; set; }
        public double SuggestedQuantity { get; set; }
        public string SecondaryUomCode { get; set; }
        public decimal? SecondaryUomQuantity { get; set; }
        public decimal? SecondaryUomRequestedQuantity { get; set; }
        public string PriceListCode { get; set; }
        public string TaxCode { get; set; }
        public bool IsStockProcessed { get; set; }
        public string DummyVariable { get; set; }
        public string DummyVariableDescription { get; set; }
        public double? HeaderDiscountPercentage { get; set; }
        public decimal? HeaderDiscountValue { get; set; }
        public double? AddedPrice { get; set; }
    }
}
