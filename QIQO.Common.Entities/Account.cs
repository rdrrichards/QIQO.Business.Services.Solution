using System;
using QIQO.Common.Contracts;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace QIQO.Business.Entities
{
    [DataContract]
    public class Account : IAccountOwnedEntity, IModel
    {
        [DataMember]
        public int AccountKey { get; set; }
        [DataMember]
        public int CompanyKey { get; set; }
        [DataMember]
        public QIQOAccountType AccountType { get; set; } = QIQOAccountType.Business;
        [DataMember]
        public AccountType AccountTypeData { get; set; } = new AccountType();
        [DataMember]
        public string AccountCode { get; set; }
        [DataMember]
        public string AccountName { get; set; }
        [DataMember]
        public string AccountDesc { get; set; }
        [DataMember]
        public string AccountDBA { get; set; }
        [DataMember]
        public DateTime AccountStartDate { get; set; }
        [DataMember]
        public DateTime AccountEndDate { get; set; }
        [DataMember]
        public string AddedUserID { get; set; }
        [DataMember]
        public DateTime AddedDateTime { get; set; }
        [DataMember]
        public string UpdateUserID { get; set; }
        [DataMember]
        public DateTime UpdateDateTime { get; set; }

        //public QIQOEntityType EntityType { get; private set; }

        [DataMember]
        public List<Address> Addresses { get; set; } = new List<Address>();

        [DataMember]
        public List<EntityAttribute> AccountAttributes { get; set; } = new List<EntityAttribute>();

        [DataMember]
        public List<FeeSchedule> FeeSchedules { get; set; } = new List<FeeSchedule>();

        [DataMember]
        public List<AccountPerson> Employees { get; set; } = new List<AccountPerson>();

        [DataMember]
        public List<Contact> Contacts { get; set; } = new List<Contact>();
        [DataMember]
        public List<Comment> Comments { get; set; } = new List<Comment>();

        public int OwnerAccountKey
        {
            get { return AccountKey; }
        }
    }
}
