using System;
using System.Collections.Generic;

#nullable disable

namespace SFAeCommerce.Models
{
    public partial class AttributeValueEntity
    {
        public string AttributeValueEntityCode { get; set; }
        public string EntityCode { get; set; }
        public string AttributeCode { get; set; }
        public string AttributeValueCode { get; set; }
        public string AttributeValue { get; set; }
        public bool? IsActive { get; set; }
        public byte IsProcessed { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastEdited { get; set; }

        public virtual Item EntityCodeNavigation { get; set; }
    }
}
