using System;
using QIQO.Common.Contracts;
using System.Runtime.Serialization;

namespace QIQO.Business.Entities
{
    [DataContract]
    public class ContactType : IType, IModel
    {
        [DataMember]
        public int ContactTypeKey { get; set; }

        [DataMember]
        public string ContactTypeCategory { get; set; }
        [DataMember]
        public string ContactTypeCode { get; set; }
        [DataMember]
        public string ContactTypeName { get; set; }
        [DataMember]
        public string ContactTypeDesc { get; set; }
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
            get { return ContactTypeKey; }

            set { ContactTypeKey = value; }
        }
    }
}
