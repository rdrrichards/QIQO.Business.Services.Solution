using QIQO.Common.Contracts;
using System;

namespace QIQO.Data.Entities
{
    public class InvoiceStatusData : CommonData, IEntity
    { // InvoiceStatus class opener
        public int InvoiceStatusKey { get; set; }
        public string InvoiceStatusCode { get; set; }
        public string InvoiceStatusName { get; set; }
        public string InvoiceStatusType { get; set; }
        public string InvoiceStatusDesc { get; set; }

        public int EntityRowKey
        {
            get { return InvoiceStatusKey; }
            set { InvoiceStatusKey = value; }
        }
    } // InvoiceStatus class closer
}