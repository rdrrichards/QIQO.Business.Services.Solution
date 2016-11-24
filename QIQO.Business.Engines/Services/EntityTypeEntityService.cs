using QIQO.Business.Contracts;
using QIQO.Business.Entities;
using QIQO.Data.Entities;

namespace QIQO.Business.Engines
{

    //public class EntityPersonEntityService : IEntityPersonEntityService, IEntityService<EntityPerson, EntityPersonData>
    //{
    //    public EntityPerson Map(EntityPersonData entity_person_data)
    //    {
    //        return new EntityPerson()
    //        {
    //            EntityPersonKey = entity_person_data.EntityPersonKey,
    //            PersonKey = entity_person_data.PersonKey,
    //            PersonTypeKey = entity_person_data.PersonTypeKey,
    //            EntityPersonSeq = entity_person_data.EntityPersonSeq,
    //            PersonRole = entity_person_data.PersonRole,
    //            EntityKey = entity_person_data.EntityKey,
    //            EntityTypeKey = entity_person_data.EntityTypeKey,
    //            Comment = entity_person_data.Comment,
    //            StartDate = entity_person_data.StartDate,
    //            EndDate = entity_person_data.EndDate,
    //            AuditAddUserId = entity_person_data.AuditAddUserId,
    //            AuditAddDatetime = entity_person_data.AuditAddDatetime,
    //            AuditUpdateUserId = entity_person_data.AuditUpdateUserId,
    //            AuditUpdateDatetime = entity_person_data.AuditUpdateDatetime,
    //        };
    //    }

    //    public EntityPersonData Map(EntityPerson entity_person)
    //    {
    //        return new EntityPersonData()
    //        {
    //            EntityPersonKey = entity_person.EntityPersonKey,
    //            PersonKey = entity_person.PersonKey,
    //            PersonTypeKey = entity_person.PersonTypeKey,
    //            EntityPersonSeq = entity_person.EntityPersonSeq,
    //            PersonRole = entity_person.PersonRole,
    //            EntityKey = entity_person.EntityKey,
    //            EntityTypeKey = entity_person.EntityTypeKey,
    //            Comment = entity_person.Comment,
    //            StartDate = entity_person.StartDate,
    //            EndDate = entity_person.EndDate,
    //            AuditAddUserId = entity_person.AuditAddUserId,
    //            AuditAddDatetime = entity_person.AuditAddDatetime,
    //            AuditUpdateUserId = entity_person.AuditUpdateUserId,
    //            AuditUpdateDatetime = entity_person.AuditUpdateDatetime,
    //        };
    //    }
    //}

    public class EntityTypeEntityService : IEntityTypeEntityService
    {
        public EntityType Map(EntityTypeData entity_type_data)
        {
            return new EntityType()
            {
                EntityTypeKey = entity_type_data.EntityTypeKey,
                EntityTypeCode = entity_type_data.EntityTypeCode,
                EntityTypeName = entity_type_data.EntityTypeName,
                AddedUserID = entity_type_data.AuditAddUserId,
                AddedDateTime = entity_type_data.AuditAddDatetime,
                UpdateUserID = entity_type_data.AuditUpdateUserId,
                UpdateDateTime = entity_type_data.AuditUpdateDatetime,
            };
        }

        public EntityTypeData Map(EntityType entity_type)
        {
            return new EntityTypeData()
            {
                EntityTypeKey = entity_type.EntityTypeKey,
                EntityTypeCode = entity_type.EntityTypeCode,
                EntityTypeName = entity_type.EntityTypeName
            };
        }
    }
}