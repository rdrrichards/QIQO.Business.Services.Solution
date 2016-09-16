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
    public class InvoiceService : ServiceBase, IInvoiceService
    {
        private IBusinessEngineFactory _business_engine_factory;

        public InvoiceService(IBusinessEngineFactory bus_eng_factory)
        {
            _business_engine_factory = bus_eng_factory;
        }

        [OperationBehavior(TransactionScopeRequired = true, Impersonation = ImpersonationOption.Allowed)]
        [PrincipalPermission(SecurityAction.Demand, Role = Security.QIQOCompanyAdminRole)]
        [PrincipalPermission(SecurityAction.Demand, Role = Security.QIQOInvoiceEntryAdminRole)]
        public int CreateInvoice(Invoice invoice)
        {
            IInvoiceBusinessEngine invoice_be = _business_engine_factory.GetBusinessEngine<IInvoiceBusinessEngine>();
            return invoice_be.InvoiceSave(invoice);
        }

        [OperationBehavior(TransactionScopeRequired = true, Impersonation = ImpersonationOption.Allowed)]
        [PrincipalPermission(SecurityAction.Demand, Role = Security.QIQOCompanyAdminRole)]
        [PrincipalPermission(SecurityAction.Demand, Role = Security.QIQOInvoiceEntryAdminRole)]
        public bool DeleteInvoice(Invoice invoice)
        {
            IInvoiceBusinessEngine invoice_be = _business_engine_factory.GetBusinessEngine<IInvoiceBusinessEngine>();
            return invoice_be.InvoiceDelete(invoice);
        }

        public Invoice GetInvoice(int invoice)
        {
            IInvoiceBusinessEngine invoice_be = _business_engine_factory.GetBusinessEngine<IInvoiceBusinessEngine>();
            return invoice_be.GetInvoiceByID(invoice);
        }

        public List<Invoice> GetInvoicesByAccount(Account account)
        {
            IInvoiceBusinessEngine invoice_be = _business_engine_factory.GetBusinessEngine<IInvoiceBusinessEngine>();
            return invoice_be.GetOpenInvoicesByAccount(account);
        }

        public List<Invoice> GetInvoicesByCompany(Company company)
        {
            IInvoiceBusinessEngine invoice_be = _business_engine_factory.GetBusinessEngine<IInvoiceBusinessEngine>();
            return invoice_be.GetOpenInvoicesByCompany(company);
        }

        public List<Invoice> FindInvoicesByCompany(Company company, string search_pattern)
        {
            IInvoiceBusinessEngine invoice_be = _business_engine_factory.GetBusinessEngine<IInvoiceBusinessEngine>();
            return invoice_be.FindInvoicesByCompany(company, search_pattern);
        }

        public InvoiceItem GetInvoiceItemByOrderItemKey(int order_item_key)
        {
            IInvoiceBusinessEngine invoice_be = _business_engine_factory.GetBusinessEngine<IInvoiceBusinessEngine>();
            return invoice_be.GetInvoiceItemsByOrderItemKey(order_item_key);
        }
    }
}