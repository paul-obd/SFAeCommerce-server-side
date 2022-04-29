using System;
using System.Collections.Generic;

#nullable disable

namespace SFAeCommerce.Models
{
    public partial class AttributeValue
    {
        public string AttributeValueCode { get; set; }
        public string AttributeCode { get; set; }
        public string Description { get; set; }
        public string AltDescription { get; set; }
        public string ParentAttributeValueCode { get; set; }
        public bool? IsActive { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastEdited { get; set; }
    }
}
