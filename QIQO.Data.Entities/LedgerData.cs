using QIQO.Common.Contracts;
using System;

namespace QIQO.Data.Entities
{
    public class LedgerData : CommonData, IEntity
    { // Ledger class opener
        public int LedgerKey { get; set; }
        public int CompanyKey { get; set; }
        public string LedgerCode { get; set; }
        public string LedgerName { get; set; }
        public string LedgerDesc { get; set; }

        public int EntityRowKey
        {
            get { return LedgerKey; }
            set { LedgerKey = value; }
        }
    } // Ledger class closer
}