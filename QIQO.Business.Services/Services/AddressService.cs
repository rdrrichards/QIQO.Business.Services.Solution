using QIQO.Business.Contracts;
using QIQO.Business.Entities;
using QIQO.Common.Contracts;
using QIQO.Common.Core;
using System.Collections.Generic;
using System.Security.Permissions;
using System.ServiceModel;

namespace QIQO.Business.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall,
        ConcurrencyMode = ConcurrencyMode.Multiple,
        ReleaseServiceInstanceOnTransactionComplete = false)]
    public class AddressService : ServiceBase, IAddressService
    {
        private IBusinessEngineFactory _business_engine_factory;

        public AddressService(IBusinessEngineFactory bus_eng_factory)
        {
            _business_engine_factory = bus_eng_factory;
        }

        [OperationBehavior(TransactionScopeRequired = true, Impersonation = ImpersonationOption.Allowed)]
        public int CreateAddress(Address address)
        {
            IAddressBusinessEngine address_be = _business_engine_factory.GetBusinessEngine<IAddressBusinessEngine>();
            return address_be.AddressSave(address);
        }

        [OperationBehavior(TransactionScopeRequired = true, Impersonation = ImpersonationOption.Allowed)]
        public bool DeleteAddress(Address address)
        {
            IAddressBusinessEngine address_be = _business_engine_factory.GetBusinessEngine<IAddressBusinessEngine>();
            return address_be.AddressDelete(address);
        }

        public Address GetAddress(int address_key)
        {
            IAddressBusinessEngine address_be = _business_engine_factory.GetBusinessEngine<IAddressBusinessEngine>();
            return address_be.GetAddressByID(address_key);
        }

        public List<Address> GetAddressesByCompany(Company company)
        {
            IAddressBusinessEngine address_be = _business_engine_factory.GetBusinessEngine<IAddressBusinessEngine>();
            return address_be.GetAddressesByCompany(company);
        }

        public List<Address> GetAddressesByEntity(int entity_key, QIQOEntityType entity_type)
        {
            IAddressBusinessEngine address_be = _business_engine_factory.GetBusinessEngine<IAddressBusinessEngine>();
            return address_be.GetAddressesByEntityID(entity_key, entity_type);
        }

        //** Postal Code Related Services
        public AddressPostal GetAddressInfoByPostal(string postal_code)
        {
            IAddressPostalBusinessEngine address_postal_be = _business_engine_factory.GetBusinessEngine<IAddressPostalBusinessEngine>();
            return address_postal_be.GetAddressPostalByCode(postal_code);
        }

        public List<AddressPostal> GetStateListByCountry(string country)
        {
            IAddressPostalBusinessEngine address_postal_be = _business_engine_factory.GetBusinessEngine<IAddressPostalBusinessEngine>();
            return address_postal_be.GetStateListByCountry(country);
        }
    }
}