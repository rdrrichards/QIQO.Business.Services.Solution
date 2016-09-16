using QIQO.Common.Contracts;
using QIQO.Data.Entities;
using System.Collections.Generic;

namespace QIQO.Data.Interfaces
{
    public interface IOrderItemRepository : IRepository<OrderItemData>
    {
        IEnumerable<OrderItemData> GetAll(OrderHeaderData order);
    }
}