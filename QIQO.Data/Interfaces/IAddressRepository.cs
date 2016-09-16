using QIQO.Common.Contracts;
using QIQO.Data.Entities;
using System.Collections.Generic;

namespace QIQO.Data.Interfaces
{
    public interface IAddressRepository : IRepository<AddressData>
    {
        IEnumerable<AddressData> GetAll(int entity_key, int entity_type);
    }
}