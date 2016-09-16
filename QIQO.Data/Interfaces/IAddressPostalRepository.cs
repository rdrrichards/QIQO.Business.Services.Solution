using QIQO.Common.Contracts;
using QIQO.Data.Entities;
using System.Collections.Generic;

namespace QIQO.Data.Interfaces
{
    public interface IAddressPostalRepository : IRepository<AddressPostalData>
    {
        IEnumerable<AddressPostalData> GetAllByCountry(string country);
        IEnumerable<AddressPostalData> GetStatesByCountry(string country);
        IEnumerable<AddressPostalData> GetCountiesByState(string state);
    }
}