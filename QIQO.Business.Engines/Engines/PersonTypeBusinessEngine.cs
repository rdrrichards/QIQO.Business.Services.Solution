using QIQO.Business.Contracts;
using QIQO.Business.Entities;
using QIQO.Common.Contracts;
using QIQO.Common.Core.Caching;
using QIQO.Common.Core.Logging;
using QIQO.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QIQO.Business.Engines
{
    public class PersonTypeBusinessEngine : EngineBase, IPersonTypeBusinessEngine
    {
        private readonly ICache _cache; // = Unity.Container.Resolve<ICache>();
        private readonly IPersonTypeRepository _repo_prod_type;
        private readonly IPersonEntityService _prod_es;
        public PersonTypeBusinessEngine(IDataRepositoryFactory data_repo_fact, ICache cache, IEntityServiceFactory ent_serv_fact)
            : base(data_repo_fact, null, ent_serv_fact)
        {
            _cache = cache;
            _repo_prod_type = _data_repository_factory.GetDataRepository<IPersonTypeRepository>();
            _prod_es = _entity_service_factory.GetEntityService<IPersonEntityService>();
        }

        public PersonType GetTypeByKey(int type)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var person_types = _cache.Get(CacheKeys.PersonTypes) as List<PersonType>;
                if (person_types != null)
                    return person_types.Where(item => item.PersonTypeKey == type).FirstOrDefault();  //account_type_entry;

                return GetTypes().Where(item => item.PersonTypeKey == type).FirstOrDefault();
            });
        }

        public List<PersonType> GetTypes()
        {
            return ExecuteFaultHandledOperation(() =>
            {
                List<PersonType> person_types = _cache.Get(CacheKeys.PersonTypes) as List<PersonType>;
                if (person_types == null)
                {
                    Log.Debug("PersonTypeRepository GetAll called");
                    person_types = new List<PersonType>();
                    var person_type_data = _repo_prod_type.GetAll();

                    foreach (var account_type in person_type_data)
                    {
                        person_types.Add(_prod_es.Map(account_type));
                    }
                    
                    _cache.Set(CacheKeys.PersonTypes, person_types);
                    Log.Debug("PersonTypeRepository GetAll complete");
                }
                return person_types;
            });
        }

        public List<PersonType> GetTypesByCategory(string category)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var person_types = _cache.Get(CacheKeys.PersonTypes) as List<PersonType>;
                if (person_types != null)
                    return person_types.Where(item => item.PersonTypeCategory == category).ToList(); 
                return GetTypes().Where(item => item.PersonTypeCategory == category).ToList();
            });
        }

        public int AddOrUpdateType(PersonType type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            return ExecuteFaultHandledOperation(() =>
            {
                var person_type_data = _prod_es.Map(type);
                return _repo_prod_type.Insert(person_type_data);
            });
        }

        public bool DeleteType(PersonType type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            return ExecuteFaultHandledOperation(() =>
            {
                var person_type_data = _prod_es.Map(type);
                _repo_prod_type.Delete(person_type_data);
                return true;
            });
        }
    }
}