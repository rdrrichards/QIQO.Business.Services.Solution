using QIQO.Business.Entities;
using System.Collections.Generic;
using System.ServiceModel;

namespace QIQO.Business.Contracts
{
    [ServiceContract]
    public interface IInvoiceService
    {
        [OperationContract]
        List<Invoice> GetInvoicesByAccount(Account account);

        [OperationContract]
        List<Invoice> GetInvoicesByCompany(Company company);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        int CreateInvoice(Invoice invoice);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        bool DeleteInvoice(Invoice invoice);

        [OperationContract]
        Invoice GetInvoice(int invoice);

        [OperationContract]
        List<Invoice> FindInvoicesByCompany(Company company, string search_pattern);

        [OperationContract]
        InvoiceItem GetInvoiceItemByOrderItemKey(int order_item_key);
    }
}