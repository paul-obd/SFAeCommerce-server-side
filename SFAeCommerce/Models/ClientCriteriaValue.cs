using System;
using System.Collections.Generic;

#nullable disable

namespace SFAeCommerce.Models
{
    public partial class ClientCriteriaValue
    {
        public int ClientCriteriaValueId { get; set; }
        public int? CriteriaId { get; set; }
        public string ClientCriteriaValueErpCode { get; set; }
        public string Description { get; set; }
        public string AltDescription { get; set; }
        public bool? IsActive { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastEdited { get; set; }

        public virtual Criterion Criteria { get; set; }
    }
}
