using QIQO.Business.Entities;
using QIQO.Common.Contracts;

namespace QIQO.Business.Contracts
{
    public interface IOrderStatusBusinessEngine : IStatusBusinessEngine<OrderStatus>, IBusinessEngine
    {
    }
    public interface IOrderItemStatusBusinessEngine : IStatusBusinessEngine<OrderItemStatus>, IBusinessEngine
    {
    }
}
