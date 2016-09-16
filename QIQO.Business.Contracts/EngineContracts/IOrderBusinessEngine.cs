using QIQO.Business.Entities;
using QIQO.Common.Contracts;
using System.Collections.Generic;

namespace QIQO.Business.Contracts
{
    public interface IOrderBusinessEngine : IBusinessEngine
    {
        int OrderSave(Order order_header);
        Order GetOrderByCode(string order_header_code, Company company);
        Order GetOrderByCode(string order_header_code, string company_code);
        Order GetOrderByID(int order_header_key);
        List<Order> GetOrdersByCompany(Company company);
        bool OrderDelete(Order order);
        bool DeleteOrderItem(OrderItem order_item);
        List<Order> GetOpenOrdersByCompany(Company company);
        List<Order> GetOpenOrdersByAccount(Account account);
        List<Order> FindOrdersByCompany(Company company, string search_pattern);
        List<Order> GetInvoicableOrdersByAccount(int company_key, int account_key);
    }
}