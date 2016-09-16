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
    public class ContactTypeBusinessEngine : EngineBase, IContactTypeBusinessEngine
    {
        private readonly ICache _cache;
        private readonly IContactTypeRepository _contact_type_repo;
        private readonly IContactEntityService _contact_es;
        public ContactTypeBusinessEngine(IDataRepositoryFactory data_repo_fact, ICache cache, IEntityServiceFactory ent_serv_fact)
            : base(data_repo_fact, null, ent_serv_fact)
        {
            _cache = cache;
            _contact_type_repo = _data_repository_factory.GetDataRepository<IContactTypeRepository>();
            _contact_es = _entity_service_factory.GetEntityService<IContactEntityService>();
        }

        public ContactType GetTypeByKey(int type)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var contact_types = _cache.Get(CacheKeys.ContactTypes) as List<ContactType>;
                if (contact_types != null)
                    return contact_types.Where(item => item.ContactTypeKey == type).FirstOrDefault();  //account_type_entry;

                return GetTypes().Where(item => item.ContactTypeKey == type).FirstOrDefault();
            });
        }

        public List<ContactType> GetTypes()
        {
            return ExecuteFaultHandledOperation(() =>
            {
                List<ContactType> contact_types = _cache.Get(CacheKeys.ContactTypes) as List<ContactType>;
                if (contact_types == null)
                {
                    Log.Debug("ContactTypeRepository GetAll called");
                    contact_types = new List<ContactType>();

                    var contact_type_data = _contact_type_repo.GetAll();

                    foreach (ContactTypeData account_type in contact_type_data)
                    {
                        contact_types.Add(_contact_es.Map(account_type));
                    }
                    
                    _cache.Set(CacheKeys.ContactTypes, contact_types);
                    Log.Debug("ContactTypeRepository GetAll complete");
                }
                return contact_types;
            });
        }

        public List<ContactType> GetTypesByCategory(string category)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var contact_types = _cache.Get(CacheKeys.ContactTypes) as List<ContactType>;
                if (contact_types != null)
                    return contact_types.Where(item => item.ContactTypeCategory == category).ToList();  //account_type_entry;

                return GetTypes().Where(item => item.ContactTypeCategory == category).ToList();
            });
        }
        public int AddOrUpdateType(ContactType type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            return ExecuteFaultHandledOperation(() =>
            {
                var contact_type_data = _contact_es.Map(type);
                return _contact_type_repo.Insert(contact_type_data);
            });
        }

        public bool DeleteType(ContactType type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            return ExecuteFaultHandledOperation(() =>
            {
                var contact_type_data = _contact_es.Map(type);
                _contact_type_repo.Delete(contact_type_data);
                return true;
            });
        }
    }
}