using QIQO.Business.Contracts;
using QIQO.Business.Entities;
using QIQO.Data.Entities;

namespace QIQO.Business.Engines
{

    public class AttributeTypeEntityService : IAttributeTypeEntityService
    {
        public AttributeType Map(AttributeTypeData attribute_type_data)
        {
            return new AttributeType()
            {
                AttributeTypeKey = attribute_type_data.AttributeTypeKey,
                AttributeTypeCategory = attribute_type_data.AttributeTypeCategory,
                AttributeTypeCode = attribute_type_data.AttributeTypeCode,
                AttributeTypeName = attribute_type_data.AttributeTypeName,
                AttributeTypeDesc = attribute_type_data.AttributeTypeDesc,
                AttributeDataTypeKey = (QIQOAttributeDataType)attribute_type_data.AttributeDataTypeKey,
                AttributeDefaultFormat = attribute_type_data.AttributeDefaultFormat,
                AddedUserID = attribute_type_data.AuditAddUserId,
                AddedDateTime = attribute_type_data.AuditAddDatetime,
                UpdateUserID = attribute_type_data.AuditUpdateUserId,
                UpdateDateTime = attribute_type_data.AuditUpdateDatetime
            };
        }

        public AttributeTypeData Map(AttributeType attribute_type)
        {
            return new AttributeTypeData()
            {
                AttributeTypeKey = attribute_type.AttributeTypeKey,
                AttributeTypeCategory = attribute_type.AttributeTypeCategory,
                AttributeTypeCode = attribute_type.AttributeTypeCode,
                AttributeTypeName = attribute_type.AttributeTypeName,
                AttributeTypeDesc = attribute_type.AttributeTypeDesc,
                AttributeDataTypeKey = (int)attribute_type.AttributeDataTypeKey,
                AttributeDefaultFormat = attribute_type.AttributeDefaultFormat
            };
        }
    }
}