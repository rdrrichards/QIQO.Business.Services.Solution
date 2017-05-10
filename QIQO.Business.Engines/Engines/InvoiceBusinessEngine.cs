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
    public class InvoiceBusinessEngine : EngineBase, IInvoiceBusinessEngine
    {
        private readonly IInvoiceRepository _invoice_repo;
        private readonly IInvoiceItemRepository _invoice_item_repo;
        private readonly ICommentBusinessEngine _comment_be;
        private readonly IEmployeeBusinessEngine _employee_be;
        private readonly IAddressBusinessEngine _address_be;
        private readonly IProductBusinessEngine _product_be;
        private readonly IAccountBusinessEngine _account_be;
        private readonly IInvoiceEntityService _invoice_se;
        private readonly IInvoiceItemEntityService _invoice_item_se;
        public InvoiceBusinessEngine(IDataRepositoryFactory data_repo_fact, IBusinessEngineFactory bus_eng_fact, IEntityServiceFactory ent_serv_fact)
            : base(data_repo_fact, bus_eng_fact, ent_serv_fact)
        {
            _invoice_repo = _data_repository_factory.GetDataRepository<IInvoiceRepository>();
            _invoice_item_repo = _data_repository_factory.GetDataRepository<IInvoiceItemRepository>();
            _comment_be = _business_engine_factory.GetBusinessEngine<ICommentBusinessEngine>();
            _employee_be = _business_engine_factory.GetBusinessEngine<IEmployeeBusinessEngine>();
            _address_be = _business_engine_factory.GetBusinessEngine<IAddressBusinessEngine>();
            _product_be = _business_engine_factory.GetBusinessEngine<IProductBusinessEngine>();
            _account_be = _business_engine_factory.GetBusinessEngine<IAccountBusinessEngine>();
            _invoice_se = _entity_service_factory.GetEntityService<IInvoiceEntityService>();
            _invoice_item_se = _entity_service_factory.GetEntityService<IInvoiceItemEntityService>();
        }

        public int InvoiceSave(Invoice invoice)
        {
            if (invoice == null)
                throw new ArgumentNullException(nameof(invoice));

            return ExecuteFaultHandledOperation(() =>
            {
                var inv_data = _invoice_se.Map(invoice);

                inv_data.InvoiceItemCount = invoice.InvoiceItems.Sum(item => item.InvoiceItemQuantity);
                inv_data.InvoiceValueSum = invoice.InvoiceItems.Sum(item => item.InvoiceItemLineSum);
                int invoice_key = _invoice_repo.Insert(inv_data);

                Log.Info($"Invoice Item start [{invoice.InvoiceItems.Count}] items to process");
                foreach (var inv_item in invoice.InvoiceItems)
                {
                    var inv_item_data = _invoice_item_se.Map(inv_item);
                    //Log.Info($"Order Item converted [{order_item_data.ProductName}] sucessfully!");
                    inv_item_data.InvoiceKey = invoice_key;
                    inv_item_data.InvoiceItemKey = inv_item.InvoiceItemKey;

                    int invoice_item_key = _invoice_item_repo.Save(inv_item_data);
                    Log.Info($"Order Item [{invoice_item_key}] saved to the database sucessfully!");
                }

                Log.Info($"Invoice Comments start [{invoice.Comments.Count}] items to process");
                foreach (var comment in invoice.Comments)
                {
                    comment.EntityKey = invoice_key;
                    comment.EntityTypeKey = (int)QIQOEntityType.Invoice;

                    int comment_key = _comment_be.CommentSave(comment);
                    Log.Info($"Invoice Comment [{comment_key}] saved to the database sucessfully!");
                }

                return invoice_key;
            });
        }

        public Invoice GetInvoiceByCode(string invoice_code, Company company)
        {
            return GetInvoiceByCode(invoice_code, company.CompanyCode);
        }

        public Invoice GetInvoiceByCode(string invoice_code, string company_code)
        {
            Log.Info("Accessing InvoiceBusinessEngine GetInvoiceByCode function");
            return ExecuteFaultHandledOperation(() =>
            {
                var invoice_data = _invoice_repo.GetByCode(invoice_code, company_code);
                Log.Info("InvoiceBusinessEngine GetInvoiceByCode function completed");

                if (invoice_data.InvoiceKey != 0)
                {
                    return Map(invoice_data);
                }
                else
                {
                    NotFoundException ex = new NotFoundException(string.Format("Invoice with code {0} is not in database", invoice_code));
                    throw new FaultException<NotFoundException>(ex, ex.Message);
                }
            });
        }

        public Invoice GetInvoiceByID(int invoice_key)
        {
            Log.Info("Accessing InvoiceBusinessEngine GetInvoiceByID function");
            return ExecuteFaultHandledOperation(() =>
            {
                var invoice_data = _invoice_repo.GetByID(invoice_key);
                Log.Info("InvoiceBusinessEngine GetByID function completed");

                if (invoice_data.InvoiceKey != 0)
                {
                    var invoice = Map(invoice_data);
                    invoice.Account = _account_be.GetAccountByID(invoice.AccountKey, true);

                    var invoice_items_data = _invoice_item_repo.GetAll(invoice_data);
                    foreach (var inv_item_date in invoice_items_data)
                        invoice.InvoiceItems.Add(Map(inv_item_date));

                    invoice.Comments = _comment_be.GetCommentsByEntity(invoice_key, QIQOEntityType.Invoice);
                    return invoice;
                }
                else
                {
                    NotFoundException ex = new NotFoundException(string.Format("Invoice with key {0} is not in database", invoice_key));
                    throw new FaultException<NotFoundException>(ex, ex.Message);
                }
            });
        }

        public List<Invoice> GetOpenInvoicesByCompany(Company company)
        {
            if (company == null)
                throw new ArgumentNullException(nameof(company));

            return ExecuteFaultHandledOperation(() =>
            {
                var invoices = new List<Invoice>();
                var comp = new CompanyData() { CompanyKey = company.CompanyKey };

                var invoices_data = _invoice_repo.GetAllOpen(comp);

                foreach (InvoiceData invoice_data in invoices_data)
                {
                    Invoice invoice = Map(invoice_data);
                    invoice.Account = _account_be.GetAccountByID(invoice.AccountKey);
                    invoices.Add(invoice);
                }
                return invoices;
            });
        }

        public List<Invoice> GetOpenInvoicesByAccount(Account account)
        {
            if (account == null)
                throw new ArgumentNullException(nameof(account));

            return ExecuteFaultHandledOperation(() =>
            {
                var invoices = new List<Invoice>();
                var acct = new AccountData() { AccountKey = account.AccountKey };

                var invoices_data = _invoice_repo.GetAllOpen(acct);

                foreach (InvoiceData invoice_data in invoices_data)
                {
                    Invoice invoice = Map(invoice_data);
                    invoice.Account = _account_be.GetAccountByID(invoice.AccountKey);
                    invoice.InvoiceItems = GetInvoiceItemsByInvoice(invoice);
                    invoices.Add(invoice);
                }
                return invoices;
            });
        }

        public List<Invoice> FindInvoicesByCompany(Company company, string search_pattern)
        {
            if (company == null)
                throw new ArgumentNullException(nameof(company));

            return ExecuteFaultHandledOperation(() =>
            {
                var order_headers = new List<Invoice>();
                var orders_data = _invoice_repo.FindAll(company.CompanyKey, search_pattern);

                foreach (InvoiceData inv_data in orders_data)
                {
                    Invoice inv = Map(inv_data);
                    inv.Account = _account_be.GetAccountByID(inv.AccountKey, false);
                    order_headers.Add(inv);
                }
                return order_headers;
            });
        }

        private List<InvoiceItem> GetInvoiceItemsByInvoice(Invoice invoice)
        {
            if (invoice == null)
                throw new ArgumentNullException(nameof(invoice));

            return ExecuteFaultHandledOperation(() =>
            {
                var inv_items = new List<InvoiceItem>();
                var inv_hdr_data = new InvoiceData() { InvoiceKey = invoice.InvoiceKey };

                var invs_item_data = _invoice_item_repo.GetAll(inv_hdr_data);

                foreach (InvoiceItemData inv_item_data in invs_item_data)
                {
                    inv_items.Add(Map(inv_item_data));
                }
                return inv_items;
            });
        }

        public InvoiceItem GetInvoiceItemsByOrderItemKey(int order_item_key)
        {
            if (order_item_key == 0)
                throw new InvalidOperationException(nameof(order_item_key));

            return ExecuteFaultHandledOperation(() =>
            {
                var invoice_item_data = _invoice_item_repo.GetByOrderItemID(order_item_key);
                if (invoice_item_data != null && invoice_item_data.InvoiceItemKey != 0)
                    return Map(invoice_item_data);
                else
                    return null;
            });
        }

        public List<Invoice> GetInvoicesByCompany(Company company)
        {
            if (company == null)
                throw new ArgumentNullException(nameof(company));

            return ExecuteFaultHandledOperation(() =>
            {
                var invoices = new List<Invoice>();
                var comp = new CompanyData() { CompanyKey = company.CompanyKey };
                var invoices_data = _invoice_repo.GetAll(comp);

                foreach (InvoiceData inv_data in invoices_data)
                {
                    var inv = Map(inv_data);
                    invoices.Add(inv);
                }
                return invoices;
            });
        }

        public bool InvoiceDelete(Invoice invoice)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var invoice_data = _invoice_se.Map(invoice);
                foreach (InvoiceItem inv_item in invoice.InvoiceItems)
                {
                    bool oid_ret = DeleteInvoiceItem(inv_item);
                }
                _invoice_repo.Delete(invoice_data);
                return true;
            });
        }

        public bool DeleteInvoiceItem(InvoiceItem invoice_item)
        {
            if (invoice_item == null)
                throw new ArgumentNullException(nameof(invoice_item));

            return ExecuteFaultHandledOperation(() =>
            {
                var inv_itm = _invoice_item_se.Map(invoice_item);
                inv_itm.OrderItemKey = invoice_item.InvoiceItemKey;
                _invoice_item_repo.Delete(inv_itm);
                return true;
            });
        }

        private Invoice Map(InvoiceData invoice_data)
        {
            var invoice = _invoice_se.Map(invoice_data);
            invoice.AccountRep = _employee_be.GetAccountRepByKey(invoice_data.AccountRepKey);
            invoice.SalesRep = _employee_be.GetSalesRepByKey(invoice_data.SalesRepKey);
            invoice.InvoiceAccountContact = _employee_be.GetEmployeeByID(invoice_data.AccountContactKey);
            return invoice;
        }

        private InvoiceItem Map(InvoiceItemData invoice_item_data)
        {
            var invoiceItem = _invoice_item_se.Map(invoice_item_data);
            invoiceItem.OrderItemShipToAddress = _address_be.GetAddressByID(invoice_item_data.ShiptoAddrKey);
            invoiceItem.OrderItemBillToAddress = _address_be.GetAddressByID(invoice_item_data.BilltoAddrKey);
            invoiceItem.InvoiceItemProduct = _product_be.GetProductByID(invoice_item_data.ProductKey);
            invoiceItem.AccountRep = _employee_be.GetSalesRepByKey(invoice_item_data.InvoiceItemAccountRepKey);
            invoiceItem.SalesRep = _employee_be.GetAccountRepByKey(invoice_item_data.InvoiceItemSalesRepKey);
            return invoiceItem;
        }
    }
}