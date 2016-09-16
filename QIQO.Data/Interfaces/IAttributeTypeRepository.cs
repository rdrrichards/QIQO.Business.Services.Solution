using QIQO.Common.Contracts;
using QIQO.Data.Entities;
using System.Collections.Generic;

namespace QIQO.Data.Interfaces
{
    public interface IAttributeTypeRepository : IRepository<AttributeTypeData>
    {
        IEnumerable<AttributeTypeData> GetAllByCategory(string category);
    }
}