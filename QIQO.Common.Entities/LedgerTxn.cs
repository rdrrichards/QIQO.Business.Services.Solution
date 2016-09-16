using System;
using System.Runtime.Serialization;

namespace QIQO.Business.Entities
{
    [DataContract]
    public class LedgerTxn
    {
        [DataMember]
        public int LedgerTxnKey { get; set; }
        [DataMember]
        public int LedgerKey { get; set; }
        [DataMember]
        public string Comment { get; set; }
        [DataMember]
        public string AccountFrom { get; set; }
        [DataMember]
        public string AccountTo { get; set; }

        [DataMember]
        public DateTime EntryDate { get; set; }
        [DataMember]
        public DateTime PostDate { get; set; }

        [DataMember]
        public decimal Credit { get; set; }
        [DataMember]
        public decimal Debit { get; set; }

        [DataMember]
        public int EntityKey { get; set; }
        [DataMember]
        public QIQOEntityType EntityType { get; set; } = QIQOEntityType.Account;

        [DataMember]
        public int LedgerTxnNum { get; set; }
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
