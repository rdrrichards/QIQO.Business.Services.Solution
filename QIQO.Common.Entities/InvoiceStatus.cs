using QIQO.Common.Contracts;
using System;
using System.Runtime.Serialization;

namespace QIQO.Business.Entities
{
    [DataContract]
    public class InvoiceStatus: IModel
    {
        [DataMember]
        public int InvoiceStatusKey { get; set; }
        [DataMember]
        public string InvoiceStatusCode { get; set; }
        [DataMember]
        public string InvoiceStatusName { get; set; }
        [DataMember]
        public string InvoiceStatusDesc { get; set; }
        [DataMember]
        public string InvoiceStatusType { get; set; }
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
