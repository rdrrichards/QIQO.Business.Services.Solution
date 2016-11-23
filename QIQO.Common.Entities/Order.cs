using QIQO.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace QIQO.Business.Entities
{
    [DataContract]
    public class Order: IModel
    {
        [DataMember]
        public int OrderKey { get; set; }
        [DataMember]
        public int AccountKey { get; set; }
        [DataMember]
        public Account Account { get; set; }
        [DataMember]
        public int AccountContactKey { get; set; }
        [DataMember]
        public string OrderNumber { get; set; }
        [DataMember]
        public PersonBase OrderAccountContact { get; set; } = new PersonBase();
        [DataMember]
        public int OrderItemCount { get; set; }
        [DataMember]
        public decimal OrderValueSum { get; set; }

        [DataMember]
        public DateTime OrderEntryDate { get; set; }
        [DataMember]
        public DateTime OrderStatusDate { get; set; }
        [DataMember]
        public DateTime? OrderShipDate { get; set; }
        [DataMember]
        public DateTime? OrderCompleteDate { get; set; }
        [DataMember]
        public DateTime? DeliverByDate { get; set; }

        [DataMember]
        public int SalesRepKey { get; set; }
        [DataMember]
        public Representative SalesRep { get; set; } = new Representative(QIQOPersonType.SalesRepresentative);
        [DataMember]
        public int AccountRepKey { get; set; }
        [DataMember]
        public Representative AccountRep { get; set; } = new Representative(QIQOPersonType.AccountRepresentative);

        [DataMember]
        public QIQOOrderStatus OrderStatus { get; set; } = QIQOOrderStatus.Open;
        [DataMember]
        public OrderStatus OrderStatusData { get; set; } = new OrderStatus();

        [DataMember]
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
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
