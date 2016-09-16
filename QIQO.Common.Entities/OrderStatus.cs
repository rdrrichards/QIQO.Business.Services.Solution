using QIQO.Common.Contracts;
using System;
using System.Runtime.Serialization;

namespace QIQO.Business.Entities
{
    [DataContract]
    public class OrderStatus : IStatus
    {
        [DataMember]
        public int OrderStatusKey { get; set; }
        [DataMember]
        public string OrderStatusCode { get; set; }
        [DataMember]
        public string OrderStatusName { get; set; }
        [DataMember]
        public string OrderStatusDesc { get; set; }
        [DataMember]
        public string OrderStatusType { get; set; }
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
