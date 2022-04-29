using System;
using System.Collections.Generic;

#nullable disable

namespace SFAeCommerce.Models
{
    public partial class Attribute
    {
        public string AttributeCode { get; set; }
        public string Description { get; set; }
        public string AltDescription { get; set; }
        public int AttributeType { get; set; }
        public int EntityType { get; set; }
        public string ParentAttributeCode { get; set; }
        public bool? IsActive { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastEdited { get; set; }
        public int SortOrder { get; set; }
        public bool IsRequired { get; set; }
    }
}
