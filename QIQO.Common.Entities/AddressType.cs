using System;
using QIQO.Common.Contracts;
using System.Runtime.Serialization;

namespace QIQO.Business.Entities
{
    [DataContract]
    public class AddressType : IType, IModel
    {
        [DataMember]
        public int AddressTypeKey { get; set; }

        //public string AddressCategory { get; set; }
        [DataMember]
        public string AddressTypeCode { get; set; }
        [DataMember]
        public string AddressTypeName { get; set; }
        [DataMember]
        public string AddressTypeDesc { get; set; }
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
            get { return AddressTypeKey; }

            set { AddressTypeKey = value; }
        }
    }
}
