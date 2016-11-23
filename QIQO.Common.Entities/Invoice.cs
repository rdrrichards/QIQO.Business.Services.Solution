using QIQO.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace QIQO.Business.Entities
{
    [DataContract]
    public class Invoice: IModel
    {
        [DataMember]
        public int InvoiceKey { get; set; }
        [DataMember]
        public int FromEntityKey { get; set; }
        [DataMember]
        public int AccountKey { get; set; }
        [DataMember]
        public Account Account { get; set; } = new Account();
        [DataMember]
        public int AccountContactKey { get; set; }
        [DataMember]
        public string InvoiceNumber { get; set; }
        [DataMember]
        public PersonBase InvoiceAccountContact { get; set; } = new PersonBase();
        [DataMember]
        public int InvoiceItemCount { get; set; }
        [DataMember]
        public decimal InvoiceValueSum { get; set; }

        [DataMember]
        public DateTime OrderEntryDate { get; set; }
        [DataMember]
        public DateTime InvoiceEntryDate { get; set; }
        [DataMember]
        public DateTime InvoiceStatusDate { get; set; }
        [DataMember]
        public DateTime? OrderShipDate { get; set; }
        [DataMember]
        public DateTime? InvoiceCompleteDate { get; set; }

        [DataMember]
        public int SalesRepKey { get; set; }
        [DataMember]
        public Representative SalesRep { get; set; } = new Representative(QIQOPersonType.SalesRepresentative);
        [DataMember]
        public int AccountRepKey { get; set; }
        [DataMember]
        public Representative AccountRep { get; set; } = new Representative(QIQOPersonType.AccountRepresentative);

        [DataMember]
        public QIQOInvoiceStatus InvoiceStatus { get; set; } = QIQOInvoiceStatus.New;
        [DataMember]
        public InvoiceStatus InvoiceStatusData { get; set; } = new InvoiceStatus();

        [DataMember]
        public List<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();
        [DataMember]
        public List<Comment> Comments { get; set; } = new List<Comment>();
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
