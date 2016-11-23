using System;
using QIQO.Common.Contracts;
using System.Runtime.Serialization;

namespace QIQO.Business.Entities
{
    [DataContract]
    public class PersonType : IType, IModel
    {
        [DataMember]
        public int PersonTypeKey { get; set; }

        [DataMember]
        public string PersonTypeCategory { get; set; }
        [DataMember]
        public string PersonTypeCode { get; set; }
        [DataMember]
        public string PersonTypeName { get; set; }
        [DataMember]
        public string PersonTypeDesc { get; set; }
        [DataMember]
        public string AddedUserID { get; set; }
        [DataMember]
        public DateTime AddedDateTime { get; set; }
        [DataMember]
        public string UpdateUserID { get; set; }
        [DataMember]
        public DateTime UpdateDateTime { get; set; }

        public int TypeRowKey
        {
            get { return PersonTypeKey; }

            set { PersonTypeKey = value; }
        }
    }
}
