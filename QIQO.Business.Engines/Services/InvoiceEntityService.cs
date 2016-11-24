using QIQO.Business.Contracts;
using QIQO.Business.Entities;
using QIQO.Data.Entities;
using System;

namespace QIQO.Business.Engines
{
    public class InvoiceEntityService : IInvoiceEntityService
    {
        public Invoice Map(InvoiceData invoice_data)
        {
            return new Invoice()
            {
                InvoiceKey = invoice_data.InvoiceKey,
                OrderEntryDate = invoice_data.OrderEntryDate,
                AccountKey = invoice_data.AccountKey,
                AccountContactKey = invoice_data.AccountContactKey,
                InvoiceNumber = invoice_data.InvoiceNum,
                InvoiceCompleteDate = invoice_data.InvoiceCompleteDate,
                InvoiceItemCount = invoice_data.InvoiceItemCount,
                InvoiceValueSum = invoice_data.InvoiceValueSum,
                InvoiceStatusDate = invoice_data.InvoiceStatusDate,
                OrderShipDate = invoice_data.OrderShipDate,
                AddedUserID = invoice_data.AuditAddUserId,
                AddedDateTime = invoice_data.AuditAddDatetime,
                UpdateUserID = invoice_data.AuditUpdateUserId,
                UpdateDateTime = invoice_data.AuditUpdateDatetime,
                InvoiceStatus = (QIQOInvoiceStatus)invoice_data.InvoiceStatusKey,
                AccountRepKey = invoice_data.AccountRepKey,
                SalesRepKey = invoice_data.SalesRepKey,
                FromEntityKey = invoice_data.FromEntityKey,
                InvoiceEntryDate = invoice_data.InvoiceEntryDate
            };
        }

        public InvoiceData Map(Invoice invoice)
        {
            return new InvoiceData()
            {
                InvoiceKey = invoice.InvoiceKey,
                InvoiceEntryDate = invoice.InvoiceEntryDate,
                OrderEntryDate = invoice.OrderEntryDate,
                InvoiceStatusDate = invoice.InvoiceStatusDate,
                AccountKey = invoice.AccountKey,
                AccountContactKey = invoice.AccountContactKey,
                InvoiceNum = invoice.InvoiceNumber,
                InvoiceCompleteDate = invoice.InvoiceCompleteDate,
                InvoiceItemCount = invoice.InvoiceItemCount,
                InvoiceValueSum = invoice.InvoiceValueSum,
                OrderShipDate = invoice.OrderShipDate,
                InvoiceStatusKey = (int)invoice.InvoiceStatus,
                AccountRepKey = invoice.AccountRep.EntityPersonKey,
                SalesRepKey = invoice.SalesRep.EntityPersonKey
            };
        }
    }
    public class InvoiceItemEntityService : IInvoiceItemEntityService
    {
        public InvoiceItem Map(InvoiceItemData invoice_item_data)
        {
            return new InvoiceItem()
            {
                InvoiceKey = invoice_item_data.InvoiceKey,
                InvoiceItemSeq = invoice_item_data.InvoiceItemSeq,
                InvoiceItemKey = invoice_item_data.InvoiceItemKey,
                ProductKey = invoice_item_data.ProductKey,
                ProductName = invoice_item_data.ProductName,
                ProductDesc = invoice_item_data.ProductDesc,
                InvoiceItemQuantity = invoice_item_data.InvoiceItemQuantity,
                OrderItemShipDate = invoice_item_data.OrderItemShipDate,
                InvoiceItemCompleteDate = invoice_item_data.InvoiceItemCompleteDate,
                ItemPricePer = invoice_item_data.InvoiceItemPricePer,
                InvoiceItemLineSum = invoice_item_data.InvoiceItemLineSum,
                AddedUserID = invoice_item_data.AuditAddUserId,
                AddedDateTime = invoice_item_data.AuditAddDatetime,
                UpdateUserID = invoice_item_data.AuditUpdateUserId,
                UpdateDateTime = invoice_item_data.AuditUpdateDatetime,
                InvoiceItemStatus = (QIQOInvoiceItemStatus)invoice_item_data.InvoiceItemStatusKey,
                FromEntityKey = invoice_item_data.OrderItemKey
            };
        }

        public InvoiceItemData Map(InvoiceItem invoice_item)
        {
            return new InvoiceItemData()
            {
                InvoiceKey = invoice_item.InvoiceKey,
                InvoiceItemKey = invoice_item.InvoiceItemKey,
                InvoiceItemSeq = invoice_item.InvoiceItemSeq,
                ProductKey = invoice_item.ProductKey,
                ProductName = invoice_item.ProductName,
                ProductDesc = invoice_item.ProductDesc,
                InvoiceItemQuantity = invoice_item.InvoiceItemQuantity,
                ShiptoAddrKey = invoice_item.OrderItemShipToAddress.AddressKey,
                BilltoAddrKey = invoice_item.OrderItemBillToAddress.AddressKey,
                OrderItemShipDate = invoice_item.OrderItemShipDate,
                InvoiceItemCompleteDate = invoice_item.InvoiceItemCompleteDate,
                InvoiceItemPricePer = invoice_item.ItemPricePer,
                InvoiceItemLineSum = invoice_item.InvoiceItemLineSum,
                InvoiceItemStatusKey = (int)invoice_item.InvoiceItemStatus,
                InvoiceItemAccountRepKey = invoice_item.AccountRep.EntityPersonKey,
                InvoiceItemSalesRepKey = invoice_item.SalesRep.EntityPersonKey,
                OrderItemKey = invoice_item.FromEntityKey,
                InvoiceItemEntryDate = DateTime.Now
            };
        }
    }
}
