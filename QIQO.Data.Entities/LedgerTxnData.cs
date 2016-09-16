using QIQO.Common.Contracts;
using System;

namespace QIQO.Data.Entities
{
    public class LedgerTxnData : CommonData, IEntity
    { // LedgerTxn class opener
        public int LedgerTxnKey { get; set; }
        public int LedgerKey { get; set; }
        public string TxnComment { get; set; }
        public string AcctFrom { get; set; }
        public string DeptFrom { get; set; }
        public string LobFrom { get; set; }
        public string AcctTo { get; set; }
        public string DeptTo { get; set; }
        public string LobTo { get; set; }
        public int TxnNum { get; set; }
        public DateTime? PostDate { get; set; }
        public DateTime EntryDate { get; set; }
        public decimal Credit { get; set; }
        public decimal Debit { get; set; }
        public int EntityRowKey { get; set; }
        public int EntityTypeKey { get; set; }

        public int EntityKey
        {
            get { return LedgerTxnKey; }
            set { LedgerTxnKey = value; }
        }
    } // LedgerTxn class closer
}