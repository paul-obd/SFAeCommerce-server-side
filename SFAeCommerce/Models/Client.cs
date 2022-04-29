using System;
using System.Collections.Generic;

#nullable disable

namespace SFAeCommerce.Models
{
    public partial class Client
    {
        public string ClientCode { get; set; }
        public string ErpClientCode { get; set; }
        public string Description { get; set; }
        public string AltDescription { get; set; }
        public string CurrencyCode { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public int? Type { get; set; }
        public string ParentClientCode { get; set; }
        public int StatusId { get; set; }
        public string GeneratorUserCode { get; set; }
        public DateTime? GenerationDate { get; set; }
        public string ApproverUserCode { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public string CreatorUserCode { get; set; }
        public byte IsProcessed { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastEdited { get; set; }
        public byte ClientType { get; set; }
        public string Barcode { get; set; }
        public string NfcCode { get; set; }
        public string DefaultUserCode { get; set; }
        public int BillingAddressType { get; set; }
        public int? UniqueIdentifier { get; set; }
    }
}
