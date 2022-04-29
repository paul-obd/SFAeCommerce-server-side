using System;
using System.Collections.Generic;

#nullable disable

namespace SFAeCommerce.Models
{
    public partial class ClientCriteriaValueClient
    {
        public int ClientCriteriaValueId { get; set; }
        public string ClientCode { get; set; }
        public bool? IsActive { get; set; }
        public byte IsProcessed { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastEdited { get; set; }
        public int? MainClientCriteriaValueId { get; set; }
        public DateTime? CurrentCriteriaExpiryDate { get; set; }
        public int? NextClientCriteriaValueId { get; set; }
        public DateTime? NextCriteriaValueStartDate { get; set; }
        public DateTime? NextCriteriaValueEndDate { get; set; }
    }
}
