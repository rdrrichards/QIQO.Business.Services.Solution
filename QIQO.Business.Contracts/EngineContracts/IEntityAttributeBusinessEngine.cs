using QIQO.Business.Entities;
using QIQO.Common.Contracts;
using System.Collections.Generic;

namespace QIQO.Business.Contracts
{
    public interface IEntityAttributeBusinessEngine : IBusinessEngine
    {
        List<EntityAttribute> GetAttributeByEntity(int entity_key, QIQOEntityType entity_type);
        List<EntityAttribute> GetAllAttribute();
        int EntityAttributeUpdate(EntityAttribute attribute);
        bool EntityAttributeDelete(EntityAttribute attribute);
        EntityAttribute GetEntityAttributeByKey(int attrib_key, int entity_key);
    }
}