using System;
using QIQO.Common.Contracts;
using System.Runtime.Serialization;

namespace QIQO.Business.Entities
{
    [DataContract]
    public class AttributeType : IType, IModel
    {
        [DataMember]
        public int AttributeTypeKey { get; set; }

        [DataMember]
        public string AttributeTypeCategory { get; set; }
        [DataMember]
        public string AttributeTypeCode { get; set; }
        [DataMember]
        public string AttributeTypeName { get; set; }
        [DataMember]
        public string AttributeTypeDesc { get; set; }
        [DataMember]
        public QIQOAttributeDataType AttributeDataTypeKey { get; set; } = QIQOAttributeDataType.String;
        [DataMember]
        public string AttributeDefaultFormat { get; set; }
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
            get { return AttributeTypeKey; }

            set { AttributeTypeKey = value; }
        }
    }
}
