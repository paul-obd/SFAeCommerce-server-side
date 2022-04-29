using System;
using System.Collections.Generic;

#nullable disable

namespace SFAeCommerce.Models
{
    public partial class Criterion
    {
        public Criterion()
        {
            ClientCriteriaValues = new HashSet<ClientCriteriaValue>();
        }

        public int CriteriaId { get; set; }
        public string Description { get; set; }
        public string AltDescription { get; set; }
        public int CriteriaType { get; set; }
        public bool? IsEditable { get; set; }
        public bool? IsActive { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastEdited { get; set; }
        public bool? IsRequired { get; set; }
        public int? SortOrder { get; set; }
        public bool? ReportingVisibility { get; set; }
        public bool? IsSupervisorRequired { get; set; }

        public virtual ICollection<ClientCriteriaValue> ClientCriteriaValues { get; set; }
    }
}
