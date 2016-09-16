using QIQO.Business.Contracts;
using QIQO.Business.Entities;
using QIQO.Common.Contracts;
using QIQO.Common.Core;
using System.Collections.Generic;
using System.Security.Permissions;
using System.ServiceModel;

namespace QIQO.Business.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall,
        ConcurrencyMode = ConcurrencyMode.Multiple,
        ReleaseServiceInstanceOnTransactionComplete = false)]
    public class OrderService : ServiceBase, IOrderService
    {
        private IBusinessEngineFactory _business_engine_factory;

        public OrderService(IBusinessEngineFactory bus_eng_factory)
        {
            _business_engine_factory = bus_eng_factory;
        }

        [OperationBehavior(TransactionScopeRequired = true, Impersonation = ImpersonationOption.Allowed)]
        [PrincipalPermission(SecurityAction.Demand, Role = Security.QIQOCompanyAdminRole)]
        [PrincipalPermission(SecurityAction.Demand, Role = Security.QIQOOrderEntryAdminRole)]
        [PrincipalPermission(SecurityAction.Demand, Role = Security.QIQOOrderEntryUser)]
        public int CreateOrder(Order order)
        {
            IOrderBusinessEngine order_be = _business_engine_factory.GetBusinessEngine<IOrderBusinessEngine>();
            return order_be.OrderSave(order);
        }

        [OperationBehavior(TransactionScopeRequired = true, Impersonation = ImpersonationOption.Allowed)]
        [PrincipalPermission(SecurityAction.Demand, Role = Security.QIQOCompanyAdminRole)]
        [PrincipalPermission(SecurityAction.Demand, Role = Security.QIQOOrderEntryAdminRole)]
        [PrincipalPermission(SecurityAction.Demand, Role = Security.QIQOOrderEntryUser)]
        public bool DeleteOrder(Order order)
        {
            IOrderBusinessEngine order_be = _business_engine_factory.GetBusinessEngine<IOrderBusinessEngine>();
            return order_be.OrderDelete(order);
        }

        public Order GetOrder(int order_key)
        {
            IOrderBusinessEngine order_be = _business_engine_factory.GetBusinessEngine<IOrderBusinessEngine>();
            return order_be.GetOrderByID(order_key);
        }

        public List<Order> GetOrdersByAccount(Account account)
        {
            IOrderBusinessEngine order_be = _business_engine_factory.GetBusinessEngine<IOrderBusinessEngine>();
            return order_be.GetOpenOrdersByAccount(account);
        }

        public List<Order> GetOrdersByCompany(Company company)
        {
            IOrderBusinessEngine order_be = _business_engine_factory.GetBusinessEngine<IOrderBusinessEngine>();
            return order_be.GetOpenOrdersByCompany(company);
        }

        public List<Order> FindOrdersByCompany(Company company, string search_pattern)
        {
            IOrderBusinessEngine order_be = _business_engine_factory.GetBusinessEngine<IOrderBusinessEngine>();
            return order_be.FindOrdersByCompany(company, search_pattern);
        }

        public List<Order> GetInvoicableOrdersByAccount(int company_key, int account_key)
        {
            IOrderBusinessEngine order_be = _business_engine_factory.GetBusinessEngine<IOrderBusinessEngine>();
            return order_be.GetInvoicableOrdersByAccount(company_key, account_key);
        }
    }
}