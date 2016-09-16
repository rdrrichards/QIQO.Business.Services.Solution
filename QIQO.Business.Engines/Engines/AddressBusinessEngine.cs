using QIQO.Business.Contracts;
using QIQO.Business.Entities;
using QIQO.Common.Contracts;
using QIQO.Common.Core;
using QIQO.Common.Core.Logging;
using QIQO.Data.Entities;
using QIQO.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace QIQO.Business.Engines
{
    public class AddressBusinessEngine : EngineBase, IAddressBusinessEngine
    {
        private readonly IAddressRepository _address_repo;
        private readonly IAddressTypeBusinessEngine _address_type_be;
        private readonly IAddressEntityService _addr_es;
        public AddressBusinessEngine(IDataRepositoryFactory data_repo_fact, IBusinessEngineFactory bus_eng_fact, IEntityServiceFactory ent_serv_fact)
            : base(data_repo_fact, bus_eng_fact, ent_serv_fact)
        {
            _address_repo = _data_repository_factory.GetDataRepository<IAddressRepository>();
            _address_type_be = _business_engine_factory.GetBusinessEngine<IAddressTypeBusinessEngine>();
            _addr_es = _entity_service_factory.GetEntityService<IAddressEntityService>();
        }

        public bool AddressDelete(Address address)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var address_data = _addr_es.Map(address);
                _address_repo.Delete(address_data);
                return true;
            });
        }

        public int AddressSave(Address address)
        {
            if (address == null)
                throw new ArgumentNullException(nameof(address));

            return ExecuteFaultHandledOperation(() =>
            {
                var prod_data = _addr_es.Map(address);
                return _address_repo.Insert(prod_data);
            });
        }
        
        public Address GetAddressByID(int address_key)
        {
            Log.Info("Accessing AddressBusinessEngine GetAddressByID function");
            return ExecuteFaultHandledOperation(() =>
            {
                var address_data = _address_repo.GetByID(address_key);
                Log.Info("AddressBusinessEngine GetByID function completed");

                if (address_data.AddressKey != 0)
                {
                    var addr = _addr_es.Map(address_data);
                    addr.AddressTypeData = _address_type_be.GetTypeByKey(address_data.AddressTypeKey);
                    return addr;
                }
                else
                {
                    NotFoundException ex = new NotFoundException(string.Format($"Address with key {address_key} is not in database"));
                    throw new FaultException<NotFoundException>(ex, ex.Message);
                }
            });
        }

        public List<Address> GetAddressesByEntityID(int entity_key, QIQOEntityType entity_type)
        {
            Log.Info("Accessing AddressBusinessEngine GetAddressByID function");
            return ExecuteFaultHandledOperation(() =>
            {
                var address_data = _address_repo.GetAll(entity_key, (int) entity_type);
                var addresses = new List<Address>();

                Log.Info("AddressBusinessEngine GetByID function completed");

                foreach (AddressData addr in address_data)
                {
                    var addrss = _addr_es.Map(addr);
                    addrss.AddressTypeData = _address_type_be.GetTypeByKey(addr.AddressTypeKey);
                    addresses.Add(addrss);
                }
                return addresses;
            });
        }

        public List<Address> GetAddressesByCompany(Company company)
        {
            return GetAddressesByEntityID(company.CompanyKey, QIQOEntityType.Company);
        }        
    }
}