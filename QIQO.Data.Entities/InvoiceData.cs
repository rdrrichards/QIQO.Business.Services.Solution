using QIQO.Common.Contracts;
using System;

namespace QIQO.Data.Entities
{
    public class InvoiceData : CommonData, IEntity
    { // Invoice class opener
        public int InvoiceKey { get; set; }
        public int FromEntityKey { get; set; }
        public int AccountKey { get; set; }
        public int AccountContactKey { get; set; }
        public string InvoiceNum { get; set; }
        public DateTime InvoiceEntryDate { get; set; }
        public DateTime OrderEntryDate { get; set; }
        public int InvoiceStatusKey { get; set; }
        public DateTime InvoiceStatusDate { get; set; }
        public DateTime? OrderShipDate { get; set; }
        public int AccountRepKey { get; set; }
        public int SalesRepKey { get; set; }
        public DateTime? InvoiceCompleteDate { get; set; }
        public decimal InvoiceValueSum { get; set; }
        public int InvoiceItemCount { get; set; }

        public int EntityRowKey
        {
            get { return InvoiceKey; }
            set { InvoiceKey = value; }
        }
    } // Invoice class closer
}