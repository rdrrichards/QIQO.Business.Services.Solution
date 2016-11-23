using QIQO.Common.Contracts;
using System;
using System.Runtime.Serialization;

namespace QIQO.Business.Entities
{
    [DataContract]
    public class AuditLog: IModel
    {
        [DataMember]
        public long AuditLogKey { get; set; }
        [DataMember]
        public string AuditAction { get; set; }
        [DataMember]
        public string AuditBusinessObject { get; set; }
        [DataMember]
        public DateTime AuditDateTime { get; set; }
        [DataMember]
        public string AuditUserID { get; set; }
        [DataMember]
        public string AuditApplicationName { get; set; }
        [DataMember]
        public string AuditHostName { get; set; }
        [DataMember]
        public string AuditComment { get; set; }
        [DataMember]
        public string AuditOldDataXML { get; set; }
        [DataMember]
        public string AuditNewDataXML { get; set; }
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
