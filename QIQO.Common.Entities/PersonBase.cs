using QIQO.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace QIQO.Business.Entities
{
    [KnownType(typeof(Employee))]
    [DataContract]
    public class PersonBase : IModel
    {
        [DataMember]
        public int PersonKey { get; set; }
        [DataMember]
        public string PersonCode { get; set; }
        [DataMember]
        public string PersonFirstName { get; set; }
        [DataMember]
        public string PersonMI { get; set; }
        [DataMember]
        public string PersonLastName { get; set; }
        [DataMember]
        public string PersonFullNameFL { get; set; }
        [DataMember]
        public string PersonFullNameFML { get; set; }
        [DataMember]
        public string PersonFullNameLF { get; set; }
        [DataMember]
        public string PersonFullNameLFM { get; set; }
        [DataMember]
        public DateTime? PersonDOB { get; set; }
        [DataMember]
        public List<Address> Addresses { get; set; } = new List<Address>();
        [DataMember]
        public List<EntityAttribute> PersonAttributes { get; set; } = new List<EntityAttribute>();
        [DataMember]
        public string AddedUserID { get; set; }
        [DataMember]
        public DateTime AddedDateTime { get; set; }
        [DataMember]
        public string UpdateUserID { get; set; }
        [DataMember]
        public DateTime UpdateDateTime { get; set; }

        //public QIQOPersonType Type  { get; set; }
        [DataMember]
        public PersonType PersonTypeData { get; set; } = new PersonType();
    }
}
