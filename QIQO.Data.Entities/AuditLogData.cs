using QIQO.Common.Contracts;
using System;

namespace QIQO.Data.Entities
{
    public class AuditLogData : CommonData, IEntity
    { // AuditLog class opener
        public int AuditLogKey { get; set; }
        public string AuditAction { get; set; }
        public string AuditBusObj { get; set; }
        public DateTime AuditDatetime { get; set; }
        public string AuditUserId { get; set; }
        public string AuditAppName { get; set; }
        public string AuditHostName { get; set; }
        public string AuditComment { get; set; }
        public string AuditDataOld { get; set; }
        public string AuditDataNew { get; set; }

        public int EntityRowKey
        {
            get { return AuditLogKey; }
            set { AuditLogKey = value; }
        }
    } // AuditLog class closer
}