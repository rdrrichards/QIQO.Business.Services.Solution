using QIQO.Common.Contracts;
using System;
using System.Runtime.Serialization;

namespace QIQO.Business.Entities
{
    [DataContract]
    public class ChartOfAccount: IModel
    {
        [DataMember]
        public int ChartOfAccountKey { get; set; }
        [DataMember]
        public string AccountNo { get; set; }
        [DataMember]
        public string AccountType { get; set; }
        [DataMember]
        public string AccountName { get; set; }
        [DataMember]
        public string BalanceType { get; set; }
        [DataMember]
        public string BankAccountFlag { get; set; }
        [DataMember]
        public int CompanyKey { get; set; }
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
