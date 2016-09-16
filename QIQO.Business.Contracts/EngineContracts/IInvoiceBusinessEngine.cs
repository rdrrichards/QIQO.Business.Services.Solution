using QIQO.Business.Entities;
using QIQO.Common.Contracts;
using System.Collections.Generic;

namespace QIQO.Business.Contracts
{
    public interface IInvoiceBusinessEngine : IBusinessEngine
    {
        bool InvoiceDelete(Invoice invoice);
        int InvoiceSave(Invoice invoice);
        Invoice GetInvoiceByCode(string invoice_code, Company company);
        Invoice GetInvoiceByCode(string invoice_code, string company_code);
        Invoice GetInvoiceByID(int invoice_key);
        List<Invoice> GetOpenInvoicesByCompany(Company company);
        List<Invoice> GetOpenInvoicesByAccount(Account account);
        List<Invoice> FindInvoicesByCompany(Company company, string search_pattern);
        InvoiceItem GetInvoiceItemsByOrderItemKey(int order_item_key);
    }
}