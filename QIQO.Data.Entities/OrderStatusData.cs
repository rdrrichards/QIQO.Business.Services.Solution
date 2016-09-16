using QIQO.Common.Contracts;
using System;

namespace QIQO.Data.Entities
{
    public class OrderStatusData : CommonData, IEntity, IStatusData
    { // OrderStatus class opener
        public int OrderStatusKey { get; set; }
        public string OrderStatusCode { get; set; }
        public string OrderStatusName { get; set; }
        public string OrderStatusType { get; set; }
        public string OrderStatusDesc { get; set; }

        public int EntityRowKey
        {
            get { return OrderStatusKey; }
            set { OrderStatusKey = value; }
        }
    } // OrderStatus class closer
}