using QIQO.Business.Contracts;
using QIQO.Business.Entities;
using QIQO.Common.Contracts;
using QIQO.Common.Core;
using QIQO.Common.Core.Logging;
using QIQO.Data.Entities;
using QIQO.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace QIQO.Business.Engines
{
    public class OrderBusinessEngine : EngineBase, IOrderBusinessEngine
    {
        private readonly IOrderHeaderRepository _order_header_repo;
        private readonly IOrderItemRepository _order_item_repo;
        private readonly ICommentBusinessEngine _comment_be;
        private readonly IEmployeeBusinessEngine _employee_be;
        private readonly IAddressBusinessEngine _address_be;
        private readonly IProductBusinessEngine _product_be;
        private readonly IAccountBusinessEngine _account_be;
        private readonly IOrderEntityService _order_se;
        private readonly IOrderItemEntityService _order_item_se;
        private readonly IOrderStatusBusinessEngine _order_status_be;
        private readonly IOrderItemStatusBusinessEngine _order_item_status_be;

        public OrderBusinessEngine(IDataRepositoryFactory data_repo_fact, IBusinessEngineFactory bus_eng_fact, IEntityServiceFactory ent_serv_fact)
            : base(data_repo_fact, bus_eng_fact, ent_serv_fact)
        {
            _order_header_repo = _data_repository_factory.GetDataRepository<IOrderHeaderRepository>();
            _order_item_repo = _data_repository_factory.GetDataRepository<IOrderItemRepository>();
            _comment_be = _business_engine_factory.GetBusinessEngine<ICommentBusinessEngine>();
            _employee_be = _business_engine_factory.GetBusinessEngine<IEmployeeBusinessEngine>();
            _address_be = _business_engine_factory.GetBusinessEngine<IAddressBusinessEngine>();
            _product_be = _business_engine_factory.GetBusinessEngine<IProductBusinessEngine>();
            _account_be = _business_engine_factory.GetBusinessEngine<IAccountBusinessEngine>();
            _order_status_be = _business_engine_factory.GetBusinessEngine<IOrderStatusBusinessEngine>();
            _order_item_status_be = _business_engine_factory.GetBusinessEngine<IOrderItemStatusBusinessEngine>();
            _order_se = _entity_service_factory.GetEntityService<IOrderEntityService>();
            _order_item_se = _entity_service_factory.GetEntityService<IOrderItemEntityService>();
        }
        public int OrderSave(Order order_header)
        {
            if (order_header == null)
                throw new ArgumentNullException(nameof(order_header));

            return ExecuteFaultHandledOperation(() =>
            {
                int order_header_key;
                var order_data = _order_se.Map(order_header);

                order_data.OrderItemCount = order_header.OrderItems.Sum(item => item.OrderItemQuantity);
                order_data.OrderValueSum = order_header.OrderItems.Sum(item => item.OrderItemLineSum);
                //order_data.OrderShipDate = order_header.OrderItems.Min(item => item.OrderItemShipDate).GetValueOrDefault();
                order_header_key = _order_header_repo.Save(order_data);

                Log.Info($"Order Item start [{order_header.OrderItems.Count}] items to process");
                foreach (var order_item in order_header.OrderItems)
                {
                    var order_item_data = _order_item_se.Map(order_item);
                    //Log.Info($"Order Item converted [{order_item_data.ProductName}] sucessfully!");
                    order_item_data.OrderKey = order_header_key;
                    order_item_data.OrderItemKey = order_item.OrderItemKey;

                    int order_item_key = _order_item_repo.Save(order_item_data);
                    Log.Info($"Order Item [{order_item_key}] saved to the database sucessfully!");
                }

                Log.Info($"Order Comments start [{order_header.Comments.Count}] items to process");
                foreach (var comment in order_header.Comments)
                {
                    comment.EntityKey = order_header_key;
                    comment.EntityTypeKey = (int)QIQOEntityType.Order;

                    int comment_key = _comment_be.CommentSave(comment);
                    Log.Info($"Order Comment [{comment_key}] saved to the database sucessfully!");
                }
                return order_header_key;
            });
        }

        public Order GetOrderByCode(string order_header_code, Company company)
        {
            return GetOrderByCode(order_header_code, company.CompanyCode);
        }

        public Order GetOrderByCode(string order_header_code, string company_code)
        {
            Log.Info("Accessing OrderBusinessEngine GetOrderByCode function");
            return ExecuteFaultHandledOperation(() =>
            {
                var order_header_data = _order_header_repo.GetByCode(order_header_code, company_code);
                Log.Info("OrderHeaderBusinessEngine GetOrderHeaderByCode function completed");

                if (order_header_data.OrderKey != 0)
                {
                    var order_header = Map(order_header_data);
                    return order_header;
                }
                else
                {
                    NotFoundException ex = new NotFoundException(string.Format("Order with code {0} is not in database", order_header_code));
                    throw new FaultException<NotFoundException>(ex, ex.Message);
                }
            });
        }

        public Order GetOrderByID(int order_header_key)
        {
            Log.Info("Accessing OrderHeaderBusinessEngine GetOrderHeaderByID function");
            return ExecuteFaultHandledOperation(() =>
            {
                var order_header_data = _order_header_repo.GetByID(order_header_key);
                Log.Info("OrderHeaderBusinessEngine GetByID function completed");

                if (order_header_data.OrderKey != 0)
                {
                    var order_header = Map(order_header_data);
                    order_header.Account = _account_be.GetAccountByID(order_header.AccountKey, true);

                    var order_items = new List<OrderItem>();
                    var order_items_data = _order_item_repo.GetAll(order_header_data);

                    foreach (var ord_item_data in order_items_data)
                    {
                        order_items.Add(MapOrderItemDataToOrderItem(ord_item_data));
                        //*****!! GET ORDER ITEM ADDRESSES, PRODUCT, TOO!!! ******// -> Done in MapOrderItemDataToOrderItem, dickweed!
                    }
                    order_header.OrderItems = order_items;
                    order_header.Comments = _comment_be.GetCommentsByEntity(order_header_data.OrderKey, QIQOEntityType.Order);
                    return order_header;
                }
                else
                {
                    NotFoundException ex = new NotFoundException(string.Format("Order with key {0} is not in database", order_header_key));
                    throw new FaultException<NotFoundException>(ex, ex.Message);
                }
            });
        }

        public List<Order> GetOpenOrdersByCompany(Company company)
        {
            if (company == null)
                throw new ArgumentNullException(nameof(company));

            return ExecuteFaultHandledOperation(() =>
            {
                var order_headers = new List<Order>();
                var comp = new CompanyData() { CompanyKey = company.CompanyKey };
                var orders_data = _order_header_repo.GetAllOpen(comp);

                foreach (var order_data in orders_data)
                {
                    var order_header = Map(order_data);
                    order_header.Account = _account_be.GetAccountByID(order_header.AccountKey, false);
                    order_headers.Add(order_header);
                }
                return order_headers;
            });
        }

        public List<Order> GetOpenOrdersByAccount(Account account)
        {
            if (account == null)
                throw new ArgumentNullException(nameof(account));

            return ExecuteFaultHandledOperation(() =>
            {
                var order_headers = new List<Order>();
                var acct_data = new AccountData() { AccountKey = account.AccountKey };
                var orders_data = _order_header_repo.GetAllOpen(acct_data);

                foreach (var order_data in orders_data)
                {
                    Order order_header = Map(order_data);
                    order_header.Account = _account_be.GetAccountByID(order_header.AccountKey, false);
                    order_header.OrderItems = GetOrderItemsByOrder(order_header);
                    order_headers.Add(order_header);
                }
                return order_headers;
            });
        }

        public List<Order> GetInvoicableOrdersByAccount(int company_key, int account_key)
        {
            if (company_key == 0)
                throw new InvalidOperationException(nameof(company_key));
            if (account_key == 0)
                throw new InvalidOperationException(nameof(account_key));

            return ExecuteFaultHandledOperation(() =>
            {
                var order_headers = new List<Order>();
                var orders_data = _order_header_repo.GetForInvoice(company_key, account_key);

                foreach (OrderHeaderData order_data in orders_data)
                {
                    var order_header = Map(order_data);
                    order_header.Account = _account_be.GetAccountByID(order_header.AccountKey, false);
                    order_header.OrderItems = GetOrderItemsByOrder(order_header);
                    order_headers.Add(order_header);
                }
                return order_headers;
            });
        }

        public List<Order> FindOrdersByCompany(Company company, string search_pattern)
        {
            if (company == null)
                throw new ArgumentNullException(nameof(company));

            return ExecuteFaultHandledOperation(() =>
            {
                var order_headers = new List<Order>();
                var orders_data = _order_header_repo.FindAll(company.CompanyKey, search_pattern);

                foreach (OrderHeaderData order_data in orders_data)
                {
                    var order_header = Map(order_data);
                    order_header.Account = _account_be.GetAccountByID(order_header.AccountKey, false);
                    order_headers.Add(order_header);
                }
                return order_headers;
            });
        }

        private List<OrderItem> GetOrderItemsByOrder(Order order)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order));

            var order_items = new List<OrderItem>();
            var order_hdr_data = new OrderHeaderData();
            order_hdr_data.OrderKey = order.OrderKey;

            return ExecuteFaultHandledOperation(() =>
            {
                var order_item_data = _order_item_repo.GetAll(order_hdr_data);

                foreach (OrderItemData ord_item_data in order_item_data)
                {
                    order_items.Add(MapOrderItemDataToOrderItem(ord_item_data));
                }
                return order_items;
            });
        }

        public List<Order> GetOrdersByCompany(Company company)
        {
            if (company == null)
                throw new ArgumentNullException(nameof(company));

            return ExecuteFaultHandledOperation(() =>
            {
                var order_headers = new List<Order>();
                var comp = new CompanyData() { CompanyKey = company.CompanyKey };
                var orders_data = _order_header_repo.GetAll(comp);

                foreach (OrderHeaderData order_data in orders_data)
                {
                    Order order_header = Map(order_data);
                    order_headers.Add(order_header);
                }
                return order_headers;
            });
        }

        public bool OrderDelete(Order order)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var order_data = _order_se.Map(order);
                foreach (OrderItem order_item in order.OrderItems)
                {
                    bool oid_ret = DeleteOrderItem(order_item);
                }
                _order_header_repo.Delete(order_data);
                return true;
            });
        }

        public bool DeleteOrderItem(OrderItem order_item)
        {
            if (order_item == null)
                throw new ArgumentNullException(nameof(order_item));

            return ExecuteFaultHandledOperation(() =>
            {
                var ord_itm = _order_item_se.Map(order_item);
                ord_itm.OrderItemKey = order_item.OrderItemKey;
                _order_item_repo.Delete(ord_itm);
                return true;
            });
        }

        private Order Map(OrderHeaderData order_data)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                Log.Debug($"MapOrderHeaderDataToOrder AccountContactKey: {order_data.AccountContactKey}");
                var order = _order_se.Map(order_data);
                order.OrderStatusData = _order_status_be.GetStatusByID(order_data.OrderStatusKey);
                order.AccountRep = _employee_be.GetAccountRepByKey(order_data.AccountRepKey);
                order.SalesRep = _employee_be.GetSalesRepByKey(order_data.SalesRepKey);
                order.OrderAccountContact = //new PersonBase() 
                        _employee_be.GetEmployeeByID(order_data.AccountContactKey) == null ? new PersonBase() :
                        _employee_be.GetEmployeeByID(order_data.AccountContactKey);
                return order;
            });
        }

        private OrderItem MapOrderItemDataToOrderItem(OrderItemData order_item_data)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var orderItem = _order_item_se.Map(order_item_data);
                orderItem.OrderItemShipToAddress = _address_be.GetAddressByID(order_item_data.ShiptoAddrKey);
                orderItem.OrderItemBillToAddress = _address_be.GetAddressByID(order_item_data.BilltoAddrKey);
                orderItem.OrderItemStatusData = _order_item_status_be.GetStatusByID(order_item_data.OrderItemStatusKey);
                orderItem.OrderItemProduct = _product_be.GetProductByID(order_item_data.ProductKey);
                orderItem.AccountRep = _employee_be.GetAccountRepByKey(order_item_data.OrderItemAccountRepKey);
                orderItem.SalesRep = _employee_be.GetSalesRepByKey(order_item_data.OrderItemSalesRepKey);
                return orderItem;
            });
        }
    }
}