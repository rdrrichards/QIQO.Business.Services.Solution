using QIQO.Business.Entities;
using QIQO.Common.Contracts;
using System.Collections.Generic;

namespace QIQO.Business.Contracts
{
    public interface IStatusBusinessEngine<T> : IBusinessEngine
    {
        //List<OrderStatus> GetOrderStatuses();
        //List<OrderItemStatus> GetOrderItemStatuses();
        List<T> GetStatuses();
        T GetStatusByID(int status_key);
        int UpdateStatus(T status);
        bool DeleteStatus(T status);
    }
} // namespace closer
