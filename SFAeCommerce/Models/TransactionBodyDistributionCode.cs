using System;
using System.Collections.Generic;

#nullable disable

namespace SFAeCommerce.Models
{
    public partial class TransactionBodyDistributionCode
    {
        public long TransactionBodyDistributionCodeId { get; set; }
        public long TransactionBodyId { get; set; }
        public string ItemCode { get; set; }
        public string UomCode { get; set; }
        public double Quantity { get; set; }
        public byte DistributionCodeType { get; set; }
        public string DistributionCodeFrom { get; set; }
        public string DistributionCodeTo { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public bool? IsActive { get; set; }
        public byte IsProcessed { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastEdited { get; set; }
        public long? TransactionHeaderId { get; set; }
        public DateTime SelectedDate { get; set; }
        public bool BreakPolicy { get; set; }
        public double RequestedQuantity { get; set; }
        public double SecondaryQuantity { get; set; }
        public double RequestedSecondaryQuantity { get; set; }
    }
}
