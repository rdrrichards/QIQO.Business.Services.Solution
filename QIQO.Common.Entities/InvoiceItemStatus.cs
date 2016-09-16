using System;
using System.Runtime.Serialization;

namespace QIQO.Business.Entities
{
    [DataContract]
    public class InvoiceItemStatus
    {
        [DataMember]
        public int InvoiceItemStatusKey { get; set; }
        [DataMember]
        public string InvoiceItemStatusType { get; set; }
        [DataMember]
        public string InvoiceItemStatusCode { get; set; }
        [DataMember]
        public string InvoiceItemStatusName { get; set; }
        [DataMember]
        public string InvoiceItemStatusDesc { get; set; }
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
