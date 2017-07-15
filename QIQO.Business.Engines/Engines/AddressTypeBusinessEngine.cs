using QIQO.Business.Contracts;
using QIQO.Business.Entities;
using QIQO.Common.Contracts;
using QIQO.Common.Core.Caching;
using QIQO.Common.Core.Logging;
using QIQO.Data.Entities;
using QIQO.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QIQO.Business.Engines
{
    public class AddressTypeBusinessEngine : EngineBase, IAddressTypeBusinessEngine
    {
        private readonly ICache _cache;
        private readonly IAddressTypeRepository _repo_addr_type;
        private readonly IAddressTypeEntityService _addr_es;

        public AddressTypeBusinessEngine(IDataRepositoryFactory data_repo_fact, ICache cache, IEntityServiceFactory ent_serv_fact)
            : base(data_repo_fact, null, ent_serv_fact)
        {
            _cache = cache;
            _repo_addr_type = _data_repository_factory.GetDataRepository<IAddressTypeRepository>();
            _addr_es = _entity_service_factory.GetEntityService<IAddressTypeEntityService>();
            GetTypes();
        }

        public AddressType GetTypeByKey(int type)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var address_types = _cache.Get(CacheKeys.AddressTypes) as List<AddressType>;
                if (address_types != null)
                    return address_types.Where(item => item.AddressTypeKey == type).FirstOrDefault();

                return GetTypes().Where(item => item.AddressTypeKey == type).FirstOrDefault();
            });
        }

        public List<AddressType> GetTypes()
        {
            return ExecuteFaultHandledOperation(() =>
            {
                List<AddressType> address_types = _cache.Get(CacheKeys.AddressTypes) as List<AddressType>;
                if (address_types == null)
                {
                    Log.Debug("AddressTypeRepository GetAll called");
                    address_types = new List<AddressType>();

                    var address_type_data = _repo_addr_type.GetAll();

                    foreach (AddressTypeData account_type in address_type_data)
                    {
                        address_types.Add(_addr_es.Map(account_type));
                    }
                    
                    _cache.Set(CacheKeys.AddressTypes, address_types);
                    Log.Debug("AddressTypeRepository GetAll complete");
                }
                return address_types;
            });
        }

        public int AddOrUpdateType(AddressType type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            return ExecuteFaultHandledOperation(() =>
            {
                var address_type_data = _addr_es.Map(type);
                return _repo_addr_type.Insert(address_type_data);
            });
        }

        public bool DeleteType(AddressType type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            return ExecuteFaultHandledOperation(() =>
            {
                AddressTypeData address_type_data = _addr_es.Map(type);
                _repo_addr_type.Delete(address_type_data);
                return true;
            });
        }
    }
}