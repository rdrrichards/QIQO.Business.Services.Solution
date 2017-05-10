using QIQO.Common.Contracts;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace QIQO.Business.Entities
{
    [DataContract]
    public class Representative : Employee
    {
        [DataMember]
        public List<Account> Accounts { get; set; } = new List<Account>();
        public Representative() { }
        public Representative(QIQOPersonType RepType)
        {
            CompanyRoleType = RepType;
        }
    }
}