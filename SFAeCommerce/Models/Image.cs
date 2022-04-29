using System;
using System.Collections.Generic;

#nullable disable

namespace SFAeCommerce.Models
{
    public partial class Image
    {
        public long ImageId { get; set; }
        public string Description { get; set; }
        public string AltDescription { get; set; }
        public string OwnerCode { get; set; }
        public byte OwnerType { get; set; }
        public string FolderPath { get; set; }
        public string BasePath { get; set; }
        public string PhysicalFileName { get; set; }
        public bool IsUploaded { get; set; }
        public bool? IsActive { get; set; }
        public byte IsProcessed { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastEdited { get; set; }
        public string UserCode { get; set; }
    }
}
