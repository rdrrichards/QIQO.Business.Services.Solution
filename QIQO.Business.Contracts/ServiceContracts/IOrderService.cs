using QIQO.Business.Entities;
using System.Collections.Generic;
using System.ServiceModel;

namespace QIQO.Business.Contracts
{
    [ServiceContract]
    public interface IOrderService
    {
        [OperationContract]
        List<Order> GetOrdersByAccount(Account account);

        [OperationContract]
        List<Order> GetOrdersByCompany(Company company);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        int CreateOrder(Order order);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        bool DeleteOrder(Order order);

        [OperationContract]
        Order GetOrder(int order_key);

        [OperationContract]
        List<Order> FindOrdersByCompany(Company company, string search_pattern);

        [OperationContract]
        List<Order> GetInvoicableOrdersByAccount(int company_key, int account_key);
    }
}