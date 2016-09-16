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
    public class EntityTypeBusinessEngine : EngineBase, IEntityTypeBusinessEngine
    {
        private readonly ICache _cache;
        private readonly IEntityTypeRepository _repo_ent_type;

        public EntityTypeBusinessEngine(IDataRepositoryFactory data_repo_fact, ICache cache, IEntityServiceFactory ent_serv_fact)
            : base(data_repo_fact, null, ent_serv_fact)
        {
            _cache = cache;
            _repo_ent_type = _data_repository_factory.GetDataRepository<IEntityTypeRepository>();
        }

        public EntityType GetTypeByKey(int type)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var entity_types = _cache.Get(CacheKeys.EntityTypes) as List<EntityType>;
                if (entity_types != null)
                    return entity_types.Where(item => item.EntityTypeKey == type).FirstOrDefault();  //account_type_entry;

                return GetTypes().Where(item => item.EntityTypeKey == type).FirstOrDefault();
            });
        }

        public List<EntityType> GetTypes()
        {
            return ExecuteFaultHandledOperation(() =>
            {
                List<EntityType> entity_types = _cache.Get(CacheKeys.EntityTypes) as List<EntityType>;
                if (entity_types == null)
                {
                    Log.Debug("EntityTypeRepository GetAll called");
                    
                    entity_types = new List<EntityType>();

                    var entity_type_data = _repo_ent_type.GetAll();

                    foreach (EntityTypeData account_type in entity_type_data)
                    {
                        entity_types.Add(Map(account_type));
                    }
                    
                    _cache.Set(CacheKeys.EntityTypes, entity_types);
                    Log.Debug("EntityTypeRepository GetAll complete");
                }
                return entity_types;
            });
        }

        public int AddOrUpdateType(EntityType type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            return ExecuteFaultHandledOperation(() =>
            {
                var entity_type_data = Map(type);
                return _repo_ent_type.Insert(entity_type_data);
            });
        }

        public bool DeleteType(EntityType type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            return ExecuteFaultHandledOperation(() =>
            {
                var entity_type_data = Map(type);
                _repo_ent_type.Delete(entity_type_data);
                return true;
            });
        }

        private EntityType Map(EntityTypeData entity_type_data)
        {
            return new EntityType()
            {
                EntityTypeKey = entity_type_data.EntityTypeKey,
                EntityTypeCode = entity_type_data.EntityTypeCode,
                EntityTypeName = entity_type_data.EntityTypeName,
                AddedUserID = entity_type_data.AuditAddUserId,
                AddedDateTime = entity_type_data.AuditAddDatetime,
                UpdateUserID = entity_type_data.AuditUpdateUserId,
                UpdateDateTime = entity_type_data.AuditUpdateDatetime
            };
        }

        private EntityTypeData Map(EntityType entity_type)
        {
            return new EntityTypeData()
            {
                EntityTypeKey = entity_type.EntityTypeKey,
                EntityTypeCode = entity_type.EntityTypeCode,
                EntityTypeName = entity_type.EntityTypeName
            };
        }
    }
}