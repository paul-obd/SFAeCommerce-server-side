using System;
using System.Collections.Generic;

#nullable disable

namespace SFAeCommerce.Models
{
    public partial class PriceListAssignment
    {
        public long PriceListAssignmentId { get; set; }
        public string PriceListCode { get; set; }
        public byte AssignedType { get; set; }
        public string AssignedCode { get; set; }
        public bool? IsActive { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastEdited { get; set; }
        public string DistributorCode { get; set; }
    }
}
