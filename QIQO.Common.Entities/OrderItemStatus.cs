using QIQO.Common.Contracts;
using System;
using System.Runtime.Serialization;

namespace QIQO.Business.Entities
{
    [DataContract]
    public class OrderItemStatus: IModel
    {
        [DataMember]
        public int OrderItemStatusKey { get; set; }
        [DataMember]
        public string OrderItemStatusCode { get; set; }
        [DataMember]
        public string OrderItemStatusName { get; set; }
        [DataMember]
        public string OrderItemStatusDesc { get; set; }
        [DataMember]
        public string OrderItemStatusType { get; set; }
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
