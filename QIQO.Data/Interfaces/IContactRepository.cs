using QIQO.Common.Contracts;
using QIQO.Data.Entities;
using System.Collections.Generic;

namespace QIQO.Data.Interfaces
{
    public interface IContactRepository : IRepository<ContactData>
    {
        IEnumerable<ContactData> GetAll(int entity_key, int entity_type_key);
    }
}