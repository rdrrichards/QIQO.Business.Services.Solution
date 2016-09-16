using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace QIQO.Business.Entities
{
    [KnownType(typeof(Representative))]
    [DataContract]
    public class Employee : PersonBase
    {
        [DataMember]
        public int ParentEmployeeKey { get; set; }
        [DataMember]
        public List<Company> Companies { get; set; } = new List<Company>();
        [DataMember]
        public string RoleInCompany { get; set; }
        [DataMember]
        public int EntityPersonKey { get; set; }
        [DataMember]
        public DateTime StartDate { get; set; }
        [DataMember]
        public DateTime EndDate { get; set; }
        [DataMember]
        public string Comment { get; set; }
        [DataMember]
        public QIQOPersonType CompanyRoleType { get; set; } = QIQOPersonType.EmployeeHourly;
    }
}
