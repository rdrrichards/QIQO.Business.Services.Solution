using QIQO.Business.Entities;
using QIQO.Common.Contracts;
using System.Collections.Generic;

namespace QIQO.Business.Contracts
{
    public interface IAddressBusinessEngine : IBusinessEngine
    {
        bool AddressDelete(Address address);
        int AddressSave(Address address);
        Address GetAddressByID(int address_key);
        List<Address> GetAddressesByEntityID(int entity_key, QIQOEntityType entity_type);
        List<Address> GetAddressesByCompany(Company company);
    }
}