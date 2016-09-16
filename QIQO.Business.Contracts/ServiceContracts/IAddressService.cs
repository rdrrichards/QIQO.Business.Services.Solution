using QIQO.Business.Entities;
using QIQO.Common.Core;
using System.Collections.Generic;
using System.ServiceModel;

namespace QIQO.Business.Contracts
{
    [ServiceContract]
    public interface IAddressService
    {
        [OperationContract]
        List<Address> GetAddressesByEntity(int entity_key, QIQOEntityType entity_type);

        [OperationContract]
        List<Address> GetAddressesByCompany(Company company);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        int CreateAddress(Address address);

        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        bool DeleteAddress(Address address);

        [OperationContract]
        Address GetAddress(int address_key);

        [OperationContract]
        List<AddressPostal> GetStateListByCountry(string country);

        [OperationContract]
        [FaultContract(typeof(NotFoundException))]
        AddressPostal GetAddressInfoByPostal(string postal_code);
    }
}