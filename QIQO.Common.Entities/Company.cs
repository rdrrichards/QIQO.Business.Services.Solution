using QIQO.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace QIQO.Business.Entities
{
    [DataContract]
    public class Company: IModel
    {
        [DataMember]
        public int CompanyKey { get; set; }
        [DataMember]
        public string CompanyCode { get; set; }
        [DataMember]
        public string CompanyName { get; set; }
        [DataMember]
        public string CompanyDesc { get; set; }
        [DataMember]
        public string AddedUserID { get; set; }
        [DataMember]
        public DateTime AddedDateTime { get; set; }
        [DataMember]
        public string UpdateUserID { get; set; }
        [DataMember]
        public DateTime UpdateDateTime { get; set; }

        [DataMember]
        public List<Employee> Employees { get; set; } = new List<Employee>();
        [DataMember]
        public List<ChartOfAccount> GLAccounts { get; set; } = new List<ChartOfAccount>();
        [DataMember]
        public List<Ledger> Ledgers { get; set; } = new List<Ledger>();
        [DataMember]
        public List<EntityAttribute> CompanyAttributes { get; set; } = new List<EntityAttribute>();
        [DataMember]
        public List<Address> CompanyAddresses { get; set; } = new List<Address>();
    }
}
