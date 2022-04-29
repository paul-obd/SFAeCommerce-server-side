using System;
using System.Collections.Generic;

#nullable disable

namespace SFAeCommerce.Models
{
    public partial class TransactionStatus
    {
        public int StatusId { get; set; }
        public string Description { get; set; }
        public string AltDescription { get; set; }
        public string Color { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastEdited { get; set; }
        public string MobileColor { get; set; }
        public bool AllowFilterBy { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsCustom { get; set; }
        public string LevelId { get; set; }
    }
}
