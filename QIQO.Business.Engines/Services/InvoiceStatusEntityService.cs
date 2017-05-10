using QIQO.Business.Contracts;
using QIQO.Business.Entities;
using QIQO.Data.Entities;

namespace QIQO.Business.Engines
{

    public class InvoiceStatusEntityService : IInvoiceStatusEntityService
    {
        public InvoiceStatus Map(InvoiceStatusData invoice_status_data)
        {
            return new InvoiceStatus()
            {
                InvoiceStatusKey = invoice_status_data.InvoiceStatusKey,
                InvoiceStatusCode = invoice_status_data.InvoiceStatusCode,
                InvoiceStatusName = invoice_status_data.InvoiceStatusName,
                InvoiceStatusType = invoice_status_data.InvoiceStatusType,
                InvoiceStatusDesc = invoice_status_data.InvoiceStatusDesc,
                AddedUserID = invoice_status_data.AuditAddUserId,
                AddedDateTime = invoice_status_data.AuditAddDatetime,
                UpdateUserID = invoice_status_data.AuditUpdateUserId,
                UpdateDateTime = invoice_status_data.AuditUpdateDatetime,
            };
        }

        public InvoiceStatusData Map(InvoiceStatus invoice_status)
        {
            return new InvoiceStatusData()
            {
                InvoiceStatusKey = invoice_status.InvoiceStatusKey,
                InvoiceStatusCode = invoice_status.InvoiceStatusCode,
                InvoiceStatusName = invoice_status.InvoiceStatusName,
                InvoiceStatusType = invoice_status.InvoiceStatusType,
                InvoiceStatusDesc = invoice_status.InvoiceStatusDesc
            };
        }
    }
}