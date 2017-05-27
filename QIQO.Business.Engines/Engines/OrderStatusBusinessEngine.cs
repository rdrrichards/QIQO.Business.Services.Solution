using QIQO.Common.Contracts;
using System.Collections.Generic;
using QIQO.Business.Entities;
using QIQO.Common.Core.Logging;
using QIQO.Data.Interfaces;
using QIQO.Data.Entities;
using QIQO.Common.Core.Caching;
using QIQO.Business.Contracts;
using System.Linq;

namespace QIQO.Business.Engines
{
    public class OrderStatusBusinessEngine : EngineBase, IOrderStatusBusinessEngine
    {
        private ICache _cache;
        private readonly IOrderStatusRepository _order_status_repo;
        private readonly IOrderStatusEntityService _order_status_es;

        public OrderStatusBusinessEngine(IDataRepositoryFactory data_repo_fact, ICache cache, IEntityServiceFactory ent_serv_fact)
            : base(data_repo_fact, null, ent_serv_fact)
        {
            _cache = cache;
            _order_status_repo = _data_repository_factory.GetDataRepository<IOrderStatusRepository>();
            _order_status_es = _entity_service_factory.GetEntityService<IOrderStatusEntityService>();
            GetStatuses();
        }

        public bool DeleteStatus(OrderStatus status)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var order_status_data = _order_status_es.Map(status);
                _order_status_repo.Delete(order_status_data);
                return true;
            });
        }

        public OrderStatus GetStatusByID(int status_key)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var order_statuses = _cache.Get(CacheKeys.OrderStatuses) as List<OrderStatus>;
                if (order_statuses != null)
                    return order_statuses.Where(item => item.OrderStatusKey == status_key).FirstOrDefault();
                return GetStatuses().Where(item => item.OrderStatusKey == status_key).FirstOrDefault();
            });
        }

        public List<OrderStatus> GetStatuses()
        {
            return ExecuteFaultHandledOperation(() =>
            {
                List<OrderStatus> order_statuses = _cache.Get(CacheKeys.OrderStatuses) as List<OrderStatus>;
                if (order_statuses == null)
                {
                    Log.Info("GetStatuses Order Status called");
                    order_statuses = new List<OrderStatus>();
                    var statuses_data = _order_status_repo.GetAll();

                    foreach (OrderStatusData status_data in statuses_data)
                    {
                        order_statuses.Add(_order_status_es.Map(status_data));
                    }
                    
                    _cache.Set(CacheKeys.OrderStatuses, order_statuses);
                    Log.Debug("GetStatuses Order Status complete");
                }
                return order_statuses;
            });
        }

        public int UpdateStatus(OrderStatus status)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                int order_status_key = _order_status_repo.Save(_order_status_es.Map(status));
                return order_status_key;
            });
        }
    }

}
