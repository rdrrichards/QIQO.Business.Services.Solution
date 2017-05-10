using QIQO.Common.Contracts;
using System;
using System.Runtime.Serialization;

namespace QIQO.Business.Entities
{
    [DataContract]
    public class Address : IModel
    {
        [DataMember]
        public int AddressKey { get; set; }
        [DataMember]
        public QIQOAddressType AddressType { get; set; } = QIQOAddressType.Billing;
        [DataMember]
        public AddressType AddressTypeData { get; set; } = new AddressType();
        [DataMember]
        public int EntityKey { get; set; }
        [DataMember]
        public QIQOEntityType EntityType { get; set; } = QIQOEntityType.Account;
        [DataMember]
        public string AddressLine1 { get; set; }
        [DataMember]
        public string AddressLine2 { get; set; }
        [DataMember]
        public string AddressLine3 { get; set; }
        [DataMember]
        public string AddressLine4 { get; set; }
        [DataMember]
        public string AddressCity { get; set; }
        [DataMember]
        public string AddressState { get; set; }
        [DataMember]
        public string AddressCounty { get; set; }
        [DataMember]
        public string AddressCountry { get; set; }
        [DataMember]
        public string AddressPostalCode { get; set; }
        [DataMember]
        public string AddressNotes { get; set; }
        [DataMember]
        public bool AddressDefaultFlag { get; set; }
        [DataMember]
        public bool AddressActiveFlag { get; set; }
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
