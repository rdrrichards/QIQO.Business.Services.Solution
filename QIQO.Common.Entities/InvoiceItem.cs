using QIQO.Common.Contracts;
using System;
using System.Runtime.Serialization;

namespace QIQO.Business.Entities
{
    [DataContract]
    public class InvoiceItem: IModel
    {
        [DataMember]
        public int InvoiceItemKey { get; set; }
        [DataMember]
        public int FromEntityKey { get; set; }
        [DataMember]
        public int InvoiceKey { get; set; }
        [DataMember]
        public int InvoiceItemSeq { get; set; }
        [DataMember]
        public int ProductKey { get; set; }
        [DataMember]
        public string ProductName { get; set; }
        [DataMember]
        public string ProductDesc { get; set; }
        [DataMember]
        public int InvoiceItemQuantity { get; set; }

        [DataMember]
        public Address OrderItemShipToAddress { get; set; } = new Address();
        [DataMember]
        public Address OrderItemBillToAddress { get; set; } = new Address();

        //public DateTime InvoiceEntry
        [DataMember]
        public DateTime? OrderItemShipDate { get; set; }
        [DataMember]
        public DateTime? InvoiceItemCompleteDate { get; set; }

        [DataMember]
        public decimal ItemPricePer { get; set; }
        [DataMember]
        public decimal InvoiceItemLineSum { get; set; }

        [DataMember]
        public Representative SalesRep { get; set; } = new Representative(QIQOPersonType.SalesRepresentative);
        [DataMember]
        public Representative AccountRep { get; set; } = new Representative(QIQOPersonType.AccountRepresentative);

        [DataMember]
        public QIQOInvoiceItemStatus InvoiceItemStatus { get; set; } = QIQOInvoiceItemStatus.New;
        [DataMember]
        public InvoiceItemStatus InvoiceItemStatusData { get; set; } = new InvoiceItemStatus();

        [DataMember]
        public Product InvoiceItemProduct { get; set; } = new Product();
        [DataMember]
        public string AddedUserID { get; set; }
        [DataMember]
        public DateTime AddedDateTime { get; set; }
        [DataMember]
        public string UpdateUserID { get; set; }
        [DataMember]
        public DateTime UpdateDateTime { get; set; }
    }
}
