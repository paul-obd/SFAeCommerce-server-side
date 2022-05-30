using System;
using System.Collections.Generic;

#nullable disable

namespace SFAeCommerce.Models
{
    public partial class Carousel
    {
        public int CarouselImageId { get; set; }
        public string BasePath { get; set; }
        public string FolderPath { get; set; }
        public string PhysicalFileName { get; set; }
    }
}
