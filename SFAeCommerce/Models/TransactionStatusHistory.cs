using System;
using System.Collections.Generic;

#nullable disable

namespace SFAeCommerce.Models
{
    public partial class TransactionStatusHistory
    {
        public long TransactionStatusHistoryId { get; set; }
        public long TransactionHeaderId { get; set; }
        public string TransactionHeaderCode { get; set; }
        public byte LineId { get; set; }
        public string UserCode { get; set; }
        public int TransactionStatus { get; set; }
        public bool? IsActive { get; set; }
        public byte IsProcessed { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastEdited { get; set; }
        public string LastEditedBy { get; set; }
        public string SourceFunction { get; set; }
        public string Originater { get; set; }
        public long? WarehouseDispatchingListId { get; set; }
        public string WarehouseDispatchingListCode { get; set; }
    }
}
