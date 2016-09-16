using QIQO.Common.Contracts;
using QIQO.Data.Entities;
using System.Collections.Generic;

namespace QIQO.Data.Interfaces
{
    public interface IInvoiceItemRepository : IRepository<InvoiceItemData>
    {
        IEnumerable<InvoiceItemData> GetAll(InvoiceData invoice);
        InvoiceItemData GetByOrderItemID(int order_item_key);
    }
}