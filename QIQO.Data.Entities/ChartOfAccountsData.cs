using QIQO.Common.Contracts;
using System;

namespace QIQO.Data.Entities
{
    public class ChartOfAccountsData : CommonData, IEntity
    { // ChartOfAccounts class opener
        public int CoaKey { get; set; }
        public int CompanyKey { get; set; }
        public string AcctNo { get; set; }
        public string AcctType { get; set; }
        public string DepartmentNo { get; set; }
        public string LobNo { get; set; }
        public string AcctName { get; set; }
        public string BalanceType { get; set; }
        public string BankAcctFlg { get; set; }
        public string Report { get; set; }

        public int EntityRowKey
        {
            get { return CoaKey; }
            set { CoaKey = value; }
        }
    } // ChartOfAccounts class closer
}