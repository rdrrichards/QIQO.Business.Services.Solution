using QIQO.Common.Contracts;
using System;

namespace QIQO.Data.Entities
{
    public class OrderItemData : CommonData, IEntity
    { // OrderItem class opener
        public int OrderItemKey { get; set; }
        public int OrderKey { get; set; }
        public int OrderItemSeq { get; set; }
        public int ProductKey { get; set; }
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }
        public int OrderItemQuantity { get; set; }
        public int ShiptoAddrKey { get; set; }
        public int BilltoAddrKey { get; set; }
        public DateTime? OrderItemShipDate { get; set; }
        public DateTime? OrderItemCompleteDate { get; set; }
        public decimal OrderItemPricePer { get; set; }
        public decimal OrderItemLineSum { get; set; }
        public int OrderItemAccountRepKey { get; set; }
        public int OrderItemSalesRepKey { get; set; }
        public int OrderItemStatusKey { get; set; }

        public int EntityRowKey
        {
            get { return OrderItemKey; }
            set { OrderItemKey = value; }
        }
    } // OrderItem class closer
}