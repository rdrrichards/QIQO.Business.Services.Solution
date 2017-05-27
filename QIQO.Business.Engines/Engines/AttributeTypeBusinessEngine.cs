using System;
using System.Linq;
using QIQO.Business.Entities;
using QIQO.Data.Interfaces;
using QIQO.Common.Contracts;
using System.Collections.Generic;
using QIQO.Data.Entities;
using QIQO.Business.Contracts;
using QIQO.Common.Core.Caching;
using QIQO.Common.Core.Logging;

namespace QIQO.Business.Engines
{
    public class AttributeTypeBusinessEngine : EngineBase, IAttributeTypeBusinessEngine
    {
        private readonly ICache _cache;
        private readonly IAttributeTypeRepository _repo_attr_type;
        private readonly IAttributeTypeEntityService _attr_type_es;

        public AttributeTypeBusinessEngine(IDataRepositoryFactory data_repo_fact, ICache cache, IEntityServiceFactory ent_serv_fact)
            : base(data_repo_fact, null, ent_serv_fact)
        {
            _cache = cache;
            _repo_attr_type = _data_repository_factory.GetDataRepository<IAttributeTypeRepository>();
            _attr_type_es = _entity_service_factory.GetEntityService<IAttributeTypeEntityService>();
            GetTypes();
        }

        public AttributeType GetTypeByKey(int type)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var attribute_types = _cache.Get(CacheKeys.AttributeTypes) as List<AttributeType>;
                if (attribute_types != null)
                    return attribute_types.Where(item => item.AttributeTypeKey == type).FirstOrDefault();

                return GetTypes().Where(item => item.AttributeTypeKey == type).FirstOrDefault();
            });
        }

        public List<AttributeType> GetTypes()
        {
            return ExecuteFaultHandledOperation(() =>
            {
                List<AttributeType> attribute_types = _cache.Get(CacheKeys.AttributeTypes) as List<AttributeType>;
                if (attribute_types == null)
                {
                    Log.Debug("AttributeTypeRepository GetAll called");
                    attribute_types = new List<AttributeType>();

                    var attrib_type_data = _repo_attr_type.GetAll();

                    foreach (AttributeTypeData account_type in attrib_type_data)
                    {
                        attribute_types.Add(_attr_type_es.Map(account_type));
                    }
                    
                    _cache.Set(CacheKeys.AttributeTypes, attribute_types);
                    Log.Debug("AttributeTypeRepository GetAll complete");
                }
                return attribute_types;
            });
        }

        public List<AttributeType> GetTypesByCategory(string category)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var attribute_types = _cache.Get(CacheKeys.AttributeTypes) as List<AttributeType>;
                if (attribute_types != null)
                    return attribute_types.Where(item => item.AttributeTypeCategory == category).ToList();

                return GetTypes().Where(item => item.AttributeTypeCategory == category).ToList();
            });
        }
        public int AddOrUpdateType(AttributeType type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            return ExecuteFaultHandledOperation(() =>
            {
                AttributeTypeData attribute_type_data = _attr_type_es.Map(type);

                return _repo_attr_type.Insert(attribute_type_data);
            });
        }

        public bool DeleteType(AttributeType type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            return ExecuteFaultHandledOperation(() =>
            {
                AttributeTypeData attribute_type_data = _attr_type_es.Map(type);

                _repo_attr_type.Delete(attribute_type_data);
                return true;
            });
        }
    }
}
