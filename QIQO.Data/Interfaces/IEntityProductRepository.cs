using QIQO.Common.Contracts;
using QIQO.Data.Entities;
using System.Collections.Generic;

namespace QIQO.Data.Interfaces
{
    public interface IEntityProductRepository : IRepository<EntityProductData>
    {
        IEnumerable<EntityProductData> GetAll(int entity_key, int entity_type_key);
    }
}