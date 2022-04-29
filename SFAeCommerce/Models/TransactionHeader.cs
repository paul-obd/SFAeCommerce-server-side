using System;
using System.Collections.Generic;

#nullable disable

namespace SFAeCommerce.Models
{
    public partial class TransactionHeader
    {
        public long TransactionHeaderId { get; set; }
        public string TransactionHeaderCode { get; set; }
        public string TripCode { get; set; }
        public long VisitId { get; set; }
        public string UserCode { get; set; }
        public string SourceCode { get; set; }
        public int SourceType { get; set; }
        public string DestinationCode { get; set; }
        public int DestinationType { get; set; }
        public int TransactionType { get; set; }
        public int TransactionStatus { get; set; }
        public long OrderId { get; set; }
        public string ItemBrandCode { get; set; }
        public string CurrencyCode { get; set; }
        public decimal CurrencyRate { get; set; }
        public int PrintCount { get; set; }
        public bool? IsActive { get; set; }
        public byte IsProcessed { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastEdited { get; set; }
        public decimal TotalAmount { get; set; }
        public long ParentTransactionHeaderId { get; set; }
        public string ShipTo { get; set; }
        public string Comment { get; set; }
        public DateTime ExpectedDeliveryDate { get; set; }
        public string Barcode { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public decimal FarBy { get; set; }
        public int ReasonId { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal TotalTax { get; set; }
        public string NextApproverUserCode { get; set; }
        public int? Sequence { get; set; }
        public decimal ClientTotalAmount { get; set; }
        public decimal ClientTotalDue { get; set; }
        public string BillTo { get; set; }
        public decimal StampValue { get; set; }
        public double? HeaderDiscountPercentage { get; set; }
        public decimal? HeaderDiscountValue { get; set; }
        public string AppVersion { get; set; }
        public string CurrentUserCode { get; set; }
        public string ErpTransactionHeaderCode { get; set; }
        public int ExpectedPaymentType { get; set; }
        public DateTime? ExpectedPaymentDate { get; set; }
        public decimal? CompletedIn { get; set; }
        public bool IsExpress { get; set; }
        public int? IsTreated { get; set; }
        public int? ProblemId { get; set; }
        public string DistributorCode { get; set; }
        public double? AddedPrice { get; set; }
    }
}
