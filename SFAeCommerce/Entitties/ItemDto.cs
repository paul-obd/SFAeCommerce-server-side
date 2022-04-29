
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFAeCommerce.Entitties
{
    public class ItemDto
    {

        public string Item_code { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public string Folder_path { get; set; }
        public string Base_path { get; set; }
        public string Physical_file_name { get; set; }
    }
}
