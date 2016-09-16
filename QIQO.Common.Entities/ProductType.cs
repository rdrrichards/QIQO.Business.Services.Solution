using System;
using QIQO.Common.Contracts;
using System.Runtime.Serialization;

namespace QIQO.Business.Entities
{
    [DataContract]
    public class ProductType : IType
    {
        [DataMember]
        public int ProductTypeKey { get; set; }

        [DataMember]
        public string ProductTypeCategory { get; set; }
        [DataMember]
        public string ProductTypeCode { get; set; }
        [DataMember]
        public string ProductTypeName { get; set; }
        [DataMember]
        public string ProductTypeDesc { get; set; }
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
            get { return ProductTypeKey; }

            set { ProductTypeKey = value; }
        }
    }
}
