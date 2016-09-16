using QIQO.Business.Contracts;
using QIQO.Business.Entities;
using QIQO.Data.Entities;


namespace QIQO.Business.Engines
{
    public class EntityAttributeEntityService : IEntityAttributeEntityService
    {
        public EntityAttribute Map(AttributeData entity_attrib_data)
        {
            return new EntityAttribute()
            {
                AttributeKey = entity_attrib_data.AttributeKey,
                EntityKey = entity_attrib_data.EntityKey,
                EntityType = (QIQOEntityType)entity_attrib_data.EntityTypeKey,
                AttributeType = (QIQOAttributeType)entity_attrib_data.AttributeTypeKey,
                AttributeValue = entity_attrib_data.AttributeValue,
                AttributeDataTypeKey = entity_attrib_data.AttributeDataTypeKey,
                AttributeDisplayFormat = entity_attrib_data.AttributeDisplayFormat,
                AttributeDataType = (QIQOAttributeDataType)entity_attrib_data.AttributeDataTypeKey,
                AddedUserID = entity_attrib_data.AuditAddUserId,
                AddedDateTime = entity_attrib_data.AuditAddDatetime,
                UpdateUserID = entity_attrib_data.AuditUpdateUserId,
                UpdateDateTime = entity_attrib_data.AuditUpdateDatetime
            };            
        }

        public AttributeData Map(EntityAttribute entity_attrib)
        {
            return new AttributeData()
            {
                AttributeKey = entity_attrib.AttributeKey,
                EntityKey = entity_attrib.EntityKey,
                EntityTypeKey = (int)entity_attrib.EntityType,
                AttributeTypeKey = (int)entity_attrib.AttributeType,
                AttributeValue = entity_attrib.AttributeValue,
                AttributeDataTypeKey = entity_attrib.AttributeDataTypeKey,
                AttributeDisplayFormat = entity_attrib.AttributeDisplayFormat
            };
        }
    }
}
