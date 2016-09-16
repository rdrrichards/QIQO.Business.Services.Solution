using QIQO.Common.Contracts;
using System;

namespace QIQO.Data.Entities
{
    public class OrderHeaderData : CommonData, IEntity
    { // OrderHeader class opener
        public int OrderKey { get; set; }
        public int AccountKey { get; set; }
        public int AccountContactKey { get; set; }
        public string OrderNum { get; set; }
        public DateTime OrderEntryDate { get; set; }
        public int OrderStatusKey { get; set; }
        public DateTime OrderStatusDate { get; set; }
        public DateTime? OrderShipDate { get; set; }
        public int AccountRepKey { get; set; }
        public DateTime? OrderCompleteDate { get; set; }
        public decimal OrderValueSum { get; set; }
        public int OrderItemCount { get; set; }
        public DateTime? DeliverByDate { get; set; }
        public int SalesRepKey { get; set; }

        public int EntityRowKey
        {
            get { return OrderKey; }
            set { OrderKey = value; }
        }
    } // OrderHeader class closer
}