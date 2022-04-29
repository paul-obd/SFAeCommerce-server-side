using System;
using System.Collections.Generic;

#nullable disable

namespace SFAeCommerce.Models
{
    public partial class ItemTaxAssignment
    {
        public long ItemTaxAssignmentId { get; set; }
        public int AssignedType { get; set; }
        public string AssignedCode { get; set; }
        public byte TargetType { get; set; }
        public string TargetCode { get; set; }
        public string TaxCode { get; set; }
        public bool? IsActive { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastEdited { get; set; }
    }
}
