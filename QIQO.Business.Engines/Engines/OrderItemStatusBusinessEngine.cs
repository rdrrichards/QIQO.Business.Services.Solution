using QIQO.Business.Contracts;
using QIQO.Business.Entities;
using QIQO.Common.Contracts;
using QIQO.Common.Core.Caching;
using QIQO.Common.Core.Logging;
using QIQO.Data.Entities;
using QIQO.Data.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace QIQO.Business.Engines
{
    public class OrderItemStatusBusinessEngine : EngineBase, IOrderItemStatusBusinessEngine
    {
        private readonly ICache _cache;
        private readonly IOrderStatusRepository _order_status_repo;
        private readonly IOrderItemStatusEntityService _order_item_status_es;
        public OrderItemStatusBusinessEngine(IDataRepositoryFactory data_repo_fact, ICache cache, IEntityServiceFactory ent_serv_fact)
        : base(data_repo_fact, null, ent_serv_fact)
        {
            _cache = cache;
            _order_status_repo = _data_repository_factory.GetDataRepository<IOrderStatusRepository>();
            _order_item_status_es = _entity_service_factory.GetEntityService<IOrderItemStatusEntityService>();
        }
        public bool DeleteStatus(OrderItemStatus status)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var order_status_data = _order_item_status_es.Map(status);
                _order_status_repo.Delete(order_status_data);
                return true;
            });
        }

        public OrderItemStatus GetStatusByID(int status_key)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var order_statuses = _cache.Get(CacheKeys.OrderItemStatuses) as List<OrderItemStatus>;
                if (order_statuses != null)
                    return order_statuses.Where(item => item.OrderItemStatusKey == status_key).FirstOrDefault();
                return GetStatuses().Where(item => item.OrderItemStatusKey == status_key).FirstOrDefault();
            });
        }

        public List<OrderItemStatus> GetStatuses()
        {
            return ExecuteFaultHandledOperation(() =>
            {
                List<OrderItemStatus> order_statuses = _cache.Get(CacheKeys.OrderItemStatuses) as List<OrderItemStatus>;
                if (order_statuses == null)
                {
                    Log.Info("GetStatuses Order Status called");
                    order_statuses = new List<OrderItemStatus>();
                    var statuses_data = _order_status_repo.GetAll();

                    foreach (OrderStatusData status_data in statuses_data)
                    {
                        order_statuses.Add(_order_item_status_es.Map(status_data));
                    }
                    
                    _cache.Set(CacheKeys.OrderItemStatuses, order_statuses);
                    Log.Debug("GetStatuses Order Status complete");
                }
                return order_statuses;
            });
        }

        public int UpdateStatus(OrderItemStatus status)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                int order_status_key = _order_status_repo.Save(_order_item_status_es.Map(status));
                return order_status_key;
            });
        }
    }
}