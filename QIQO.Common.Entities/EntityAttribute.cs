using System;
using System.Runtime.Serialization;

namespace QIQO.Business.Entities
{
    [DataContract]
    public class EntityAttribute
    {
        [DataMember]
        public int AttributeKey { get; set; }
        [DataMember]
        public int EntityKey { get; set; }
        [DataMember]
        public QIQOEntityType EntityType { get; set; } = QIQOEntityType.Account;
        [DataMember]
        public EntityType EntityTypeData { get; set; }
        [DataMember]
        public QIQOAttributeType AttributeType { get; set; } = QIQOAttributeType.AccountContact_CNCT_MAIN;
        [DataMember]
        public AttributeType AttributeTypeData { get; set; }

        [DataMember]
        public string AttributeValue { get; set; }
        [DataMember]
        public int AttributeDataTypeKey { get; set; }
        [DataMember]
        public QIQOAttributeDataType AttributeDataType { get; set; } = QIQOAttributeDataType.String;
        [DataMember]
        public string AttributeDisplayFormat { get; set; }
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
