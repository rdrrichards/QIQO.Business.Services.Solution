using QIQO.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace QIQO.Business.Entities
{
    [DataContract]
    public class Ledger: IModel
    {
        [DataMember]
        public int LedgerKey { get; set; }
        [DataMember]
        public int CompanyKey { get; set; }
        [DataMember]
        public string LedgeCode { get; set; }
        [DataMember]
        public string LedgeName { get; set; }
        [DataMember]
        public string LedgeDesc { get; set; }
        [DataMember]
        public string AddedUserID { get; set; }
        [DataMember]
        public DateTime AddedDateTime { get; set; }
        [DataMember]
        public string UpdateUserID { get; set; }
        [DataMember]
        public DateTime UpdateDateTime { get; set; }

        public List<LedgerTxn> LedgerTxns { get; set; } = new List<LedgerTxn>();
    }
}
