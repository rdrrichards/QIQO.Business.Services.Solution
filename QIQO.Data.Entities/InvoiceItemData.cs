using QIQO.Common.Contracts;
using System;

namespace QIQO.Data.Entities
{
    public class InvoiceItemData : CommonData, IEntity
    { // InvoiceItem class opener
        public int InvoiceItemKey { get; set; }
        public int InvoiceKey { get; set; }
        public int InvoiceItemSeq { get; set; }
        public int ProductKey { get; set; }
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }
        public int InvoiceItemQuantity { get; set; }
        public int ShiptoAddrKey { get; set; }
        public int BilltoAddrKey { get; set; }
        public DateTime? InvoiceItemEntryDate { get; set; }
        public DateTime? OrderItemShipDate { get; set; }
        public DateTime? InvoiceItemCompleteDate { get; set; }
        public decimal InvoiceItemPricePer { get; set; }
        public decimal InvoiceItemLineSum { get; set; }
        public int InvoiceItemAccountRepKey { get; set; }
        public int InvoiceItemSalesRepKey { get; set; }
        public int InvoiceItemStatusKey { get; set; }
        public int OrderItemKey { get; set; }

        public int EntityRowKey
        {
            get { return InvoiceItemKey; }
            set { InvoiceItemKey = value; }
        }
    } // InvoiceItem class closer
}