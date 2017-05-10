using System;
using QIQO.Common.Contracts;
using System.Runtime.Serialization;

namespace QIQO.Business.Entities
{
    [DataContract]
    public class AccountType : IType, IModel
    {
        [DataMember]
        public int AccountTypeKey { get; set; }

        //public string AccountTypeCategory { get; set; }
        [DataMember]
        public string AccountTypeCode { get; set; }
        [DataMember]
        public string AccountTypeName { get; set; }
        [DataMember]
        public string AccountTypeDesc { get; set; }
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
            get { return AccountTypeKey; }

            set { AccountTypeKey = value; }
        }
    }
}
