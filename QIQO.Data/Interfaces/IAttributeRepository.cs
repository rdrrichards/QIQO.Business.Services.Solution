using QIQO.Common.Contracts;
using QIQO.Data.Entities;
using System.Collections.Generic;

namespace QIQO.Data.Interfaces
{
    public interface IAttributeRepository : IRepository<AttributeData>
    {
        IEnumerable<AttributeData> GetAll(int entity_key, int entity_type_key);
    }
}