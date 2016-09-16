using QIQO.Common.Contracts;
using System;

namespace QIQO.Data.Entities
{
    public class AttributeTypeData : CommonData, IEntity
    { // AttributeType class opener
        public int AttributeTypeKey { get; set; }
        public string AttributeTypeCategory { get; set; }
        public string AttributeTypeCode { get; set; }
        public string AttributeTypeName { get; set; }
        public string AttributeTypeDesc { get; set; }
        public int AttributeDataTypeKey { get; set; }
        public string AttributeDefaultFormat { get; set; }

        public int EntityRowKey
        {
            get { return AttributeTypeKey; }
            set { AttributeTypeKey = value; }
        }
    } // AttributeType class closer
}