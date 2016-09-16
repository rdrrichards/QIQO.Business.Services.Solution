using QIQO.Business.Entities;
using QIQO.Common.Contracts;
using QIQO.Data.Entities;

namespace QIQO.Business.Contracts
{
    public interface IEntityAttributeEntityService : IEntityService
    {
        EntityAttribute Map(AttributeData entity_attrib_data);
        AttributeData Map(EntityAttribute entity_attrib);
    }
}