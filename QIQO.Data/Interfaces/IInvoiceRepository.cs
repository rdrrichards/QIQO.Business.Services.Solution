using QIQO.Common.Contracts;
using QIQO.Data.Entities;
using System.Collections.Generic;

namespace QIQO.Data.Interfaces
{
    public interface IInvoiceRepository : IRepository<InvoiceData>
    {
        IEnumerable<InvoiceData> GetAll(CompanyData company);
        IEnumerable<InvoiceData> GetAll(AccountData account);
        IEnumerable<InvoiceData> GetAllOpen(CompanyData company);
        IEnumerable<InvoiceData> GetAllOpen(AccountData account);
        IEnumerable<InvoiceData> FindAll(int company_key, string pattern);
    }
}