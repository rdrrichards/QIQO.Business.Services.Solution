using QIQO.Common.Contracts;
using System;
using System.Runtime.Serialization;

namespace QIQO.Business.Entities
{
    [DataContract]
    public class AccountPerson : PersonBase, IModel
    {
        //[DataMember]
        //public Account Account { get; set; } = new Account();
                
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
        public QIQOPersonType CompanyRoleType { get; set; } = QIQOPersonType.AccountEmployee;

        public AccountPerson() { }
        public AccountPerson(QIQOPersonType Role)
        {
            PersonTypeData = new PersonType() { PersonTypeKey = (int)Role };
        }
    }
}