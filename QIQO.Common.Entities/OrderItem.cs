using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace QIQO.Business.Entities
{
    [DataContract]
    public class OrderItem
    {
        [DataMember]
        public int OrderItemKey { get; set; }
        [DataMember]
        public int OrderKey { get; set; }
        [DataMember]
        public int OrderItemSeq { get; set; }
        [DataMember]
        public int ProductKey { get; set; }
        [DataMember]
        public string ProductCode { get; set; }
        [DataMember]
        public string ProductName { get; set; }
        [DataMember]
        public string ProductDesc { get; set; }
        [DataMember]
        public int OrderItemQuantity { get; set; }

        [DataMember]
        public Address OrderItemShipToAddress { get; set; } = new Address();
        [DataMember]
        public Address OrderItemBillToAddress { get; set; } = new Address();

        [DataMember]
        public DateTime? OrderItemShipDate { get; set; }
        [DataMember]
        public DateTime? OrderItemCompleteDate { get; set; }

        [DataMember]
        public decimal ItemPricePer { get; set; }
        [DataMember]
        public decimal OrderItemLineSum { get; set; }

        [DataMember]
        public Representative SalesRep { get; set; } = new Representative(QIQOPersonType.SalesRepresentative);
        [DataMember]
        public Representative AccountRep { get; set; } = new Representative(QIQOPersonType.AccountRepresentative);

        [DataMember]
        public QIQOOrderItemStatus OrderItemStatus { get; set; } = QIQOOrderItemStatus.Open;
        [DataMember]
        public OrderItemStatus OrderItemStatusData { get; set; } = new OrderItemStatus();

        [DataMember]
        public Product OrderItemProduct { get; set; } = new Product();
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
