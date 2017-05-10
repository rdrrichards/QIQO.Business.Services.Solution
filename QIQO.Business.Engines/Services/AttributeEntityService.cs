using QIQO.Business.Contracts;
using QIQO.Business.Entities;
using QIQO.Data.Entities;

namespace QIQO.Business.Engines
{

    public class AttributeEntityService : IAttributeEntityService
    {
        public EntityAttribute Map(AttributeData attribute_data)
        {
            return new EntityAttribute()
            {
                AttributeKey = attribute_data.AttributeKey,
                EntityKey = attribute_data.EntityKey,
                EntityType = (QIQOEntityType)attribute_data.EntityTypeKey,
                AttributeType = (QIQOAttributeType)attribute_data.AttributeTypeKey,
                AttributeValue = attribute_data.AttributeValue,
                AttributeDataTypeKey = attribute_data.AttributeDataTypeKey,
                AttributeDisplayFormat = attribute_data.AttributeDisplayFormat,
                AddedUserID = attribute_data.AuditAddUserId,
                AddedDateTime = attribute_data.AuditAddDatetime,
                UpdateUserID = attribute_data.AuditUpdateUserId,
                UpdateDateTime = attribute_data.AuditUpdateDatetime,
            };
        }

        public AttributeData Map(EntityAttribute attribute)
        {
            return new AttributeData()
            {
                AttributeKey = attribute.AttributeKey,
                EntityKey = attribute.EntityKey,
                EntityTypeKey = (int)attribute.EntityType,
                AttributeTypeKey = (int)attribute.AttributeType,
                AttributeValue = attribute.AttributeValue,
                AttributeDataTypeKey = attribute.AttributeDataTypeKey,
                AttributeDisplayFormat = attribute.AttributeDisplayFormat
            };
        }
    }
}