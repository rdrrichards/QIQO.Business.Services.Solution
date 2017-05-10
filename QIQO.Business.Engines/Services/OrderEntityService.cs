using QIQO.Business.Contracts;
using QIQO.Business.Entities;
using QIQO.Data.Entities;

namespace QIQO.Business.Engines
{
    public class OrderEntityService : IOrderEntityService
    {
        public Order Map(OrderHeaderData order_data)
        {
            return new Order()
            {
                OrderKey = order_data.OrderKey,
                OrderEntryDate = order_data.OrderEntryDate,
                AccountKey = order_data.AccountKey,
                AccountContactKey = order_data.AccountContactKey,
                OrderNumber = order_data.OrderNum,
                OrderCompleteDate = order_data.OrderCompleteDate,
                OrderItemCount = order_data.OrderItemCount,
                OrderValueSum = order_data.OrderValueSum,
                OrderStatusDate = order_data.OrderStatusDate,
                OrderShipDate = order_data.OrderShipDate,
                AddedUserID = order_data.AuditAddUserId,
                AddedDateTime = order_data.AuditAddDatetime,
                UpdateUserID = order_data.AuditUpdateUserId,
                UpdateDateTime = order_data.AuditUpdateDatetime,
                OrderStatus = (QIQOOrderStatus)order_data.OrderStatusKey,
                DeliverByDate = order_data.DeliverByDate,
                AccountRepKey = order_data.AccountRepKey,
                SalesRepKey = order_data.SalesRepKey
            };
        }

        public OrderHeaderData Map(Order order)
        {
            return new OrderHeaderData()
            {
                OrderKey = order.OrderKey,
                OrderEntryDate = order.OrderEntryDate,
                AccountKey = order.AccountKey,
                AccountContactKey = order.AccountContactKey,
                OrderNum = order.OrderNumber,
                OrderCompleteDate = order.OrderCompleteDate,
                OrderItemCount = order.OrderItemCount,
                OrderValueSum = order.OrderValueSum,
                OrderStatusDate = order.OrderStatusDate,
                OrderShipDate = order.OrderShipDate,
                OrderStatusKey = (int)order.OrderStatus,
                DeliverByDate = order.DeliverByDate,
                AccountRepKey = order.AccountRep.EntityPersonKey,
                SalesRepKey = order.SalesRep.EntityPersonKey
            };
        }
    }
    public class OrderItemEntityService : IOrderItemEntityService
    {
        public OrderItem Map(OrderItemData order_item_data)
        {
            return new OrderItem()
            {
                OrderItemKey = order_item_data.OrderItemKey,
                OrderKey = order_item_data.OrderKey,
                OrderItemSeq = order_item_data.OrderItemSeq,
                ProductKey = order_item_data.ProductKey,
                ProductName = order_item_data.ProductName,
                ProductDesc = order_item_data.ProductDesc,
                OrderItemQuantity = order_item_data.OrderItemQuantity,
                OrderItemShipDate = order_item_data.OrderItemShipDate,
                OrderItemCompleteDate = order_item_data.OrderItemCompleteDate,
                ItemPricePer = order_item_data.OrderItemPricePer,
                OrderItemLineSum = order_item_data.OrderItemLineSum,
                AddedUserID = order_item_data.AuditAddUserId,
                AddedDateTime = order_item_data.AuditAddDatetime,
                UpdateUserID = order_item_data.AuditUpdateUserId,
                UpdateDateTime = order_item_data.AuditUpdateDatetime,
                OrderItemStatus = (QIQOOrderItemStatus)order_item_data.OrderItemStatusKey
            };
        }

        public OrderItemData Map(OrderItem order_item)
        {
            return new OrderItemData()
            {
                OrderKey = order_item.OrderKey,
                OrderItemSeq = order_item.OrderItemSeq,
                ProductKey = order_item.ProductKey,
                ProductName = order_item.ProductName,
                ProductDesc = order_item.ProductDesc,
                OrderItemQuantity = order_item.OrderItemQuantity,
                ShiptoAddrKey = order_item.OrderItemShipToAddress.AddressKey,
                BilltoAddrKey = order_item.OrderItemBillToAddress.AddressKey,
                OrderItemShipDate = order_item.OrderItemShipDate,
                OrderItemCompleteDate = order_item.OrderItemCompleteDate,
                OrderItemPricePer = order_item.ItemPricePer,
                OrderItemLineSum = order_item.OrderItemLineSum,
                OrderItemStatusKey = (int)order_item.OrderItemStatus,
                OrderItemAccountRepKey = order_item.AccountRep.EntityPersonKey,
                OrderItemSalesRepKey = order_item.SalesRep.EntityPersonKey
            };
        }
    }
    public class OrderItemStatusEntityService : IOrderItemStatusEntityService
    {
        public OrderItemStatus Map(OrderStatusData order_status_data)
        {
            return new OrderItemStatus()
            {
                OrderItemStatusKey = order_status_data.OrderStatusKey,
                OrderItemStatusType = order_status_data.OrderStatusType,
                OrderItemStatusCode = order_status_data.OrderStatusCode,
                OrderItemStatusName = order_status_data.OrderStatusName,
                OrderItemStatusDesc = order_status_data.OrderStatusDesc,
                AddedUserID = order_status_data.AuditAddUserId,
                AddedDateTime = order_status_data.AuditAddDatetime,
                UpdateUserID = order_status_data.AuditUpdateUserId,
                UpdateDateTime = order_status_data.AuditUpdateDatetime
            };
        }

        public OrderStatusData Map(OrderItemStatus order_status)
        {
            return new OrderStatusData()
            {
                OrderStatusKey = order_status.OrderItemStatusKey,
                OrderStatusType = order_status.OrderItemStatusType,
                OrderStatusCode = order_status.OrderItemStatusCode,
                OrderStatusName = order_status.OrderItemStatusName,
                OrderStatusDesc = order_status.OrderItemStatusDesc
            };
        }
    }
    public class OrderStatusEntityService : IOrderStatusEntityService
    {
        public OrderStatus Map(OrderStatusData order_status_data)
        {
            return new OrderStatus()
            {
                OrderStatusKey = order_status_data.OrderStatusKey,
                OrderStatusType = order_status_data.OrderStatusType,
                OrderStatusCode = order_status_data.OrderStatusCode,
                OrderStatusName = order_status_data.OrderStatusName,
                OrderStatusDesc = order_status_data.OrderStatusDesc,
                AddedUserID = order_status_data.AuditAddUserId,
                AddedDateTime = order_status_data.AuditAddDatetime,
                UpdateUserID = order_status_data.AuditUpdateUserId,
                UpdateDateTime = order_status_data.AuditUpdateDatetime
            };
        }

        public OrderStatusData Map(OrderStatus order_status)
        {
            return new OrderStatusData()
            {
                OrderStatusKey = order_status.OrderStatusKey,
                OrderStatusType = order_status.OrderStatusType,
                OrderStatusCode = order_status.OrderStatusCode,
                OrderStatusName = order_status.OrderStatusName,
                OrderStatusDesc = order_status.OrderStatusDesc
            };
        }
    }
}
