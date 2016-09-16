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

        public AttributeTypeBusinessEngine(IDataRepositoryFactory data_repo_fact, ICache cache, IEntityServiceFactory ent_serv_fact)
            : base(data_repo_fact, null, ent_serv_fact)
        {
            _cache = cache;
            _repo_attr_type = _data_repository_factory.GetDataRepository<IAttributeTypeRepository>();
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
                        attribute_types.Add(Map(account_type));
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
                AttributeTypeData attribute_type_data = Map(type);

                return _repo_attr_type.Insert(attribute_type_data);
            });
        }

        public bool DeleteType(AttributeType type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            return ExecuteFaultHandledOperation(() =>
            {
                AttributeTypeData attribute_type_data = Map(type);

                _repo_attr_type.Delete(attribute_type_data);
                return true;
            });
        }

        private AttributeType Map(AttributeTypeData attribute_type_data)
        {
            AttributeType AttributeType = new AttributeType()
            {
                AttributeTypeKey = attribute_type_data.AttributeTypeKey,
                AttributeTypeCategory = attribute_type_data.AttributeTypeCategory,
                AttributeTypeCode = attribute_type_data.AttributeTypeCode,
                AttributeTypeName = attribute_type_data.AttributeTypeName,
                AttributeTypeDesc = attribute_type_data.AttributeTypeDesc,
                AttributeDataTypeKey = (QIQOAttributeDataType)attribute_type_data.AttributeDataTypeKey,
                AttributeDefaultFormat = attribute_type_data.AttributeDefaultFormat,
                AddedUserID = attribute_type_data.AuditAddUserId,
                AddedDateTime = attribute_type_data.AuditAddDatetime,
                UpdateUserID = attribute_type_data.AuditUpdateUserId,
                UpdateDateTime = attribute_type_data.AuditUpdateDatetime
            };

            return AttributeType;
        }

        private AttributeTypeData Map(AttributeType attribute_type)
        {
            AttributeTypeData AttributeType_data = new AttributeTypeData()
            {
                AttributeTypeKey = attribute_type.AttributeTypeKey,
                AttributeTypeCategory = attribute_type.AttributeTypeCategory,
                AttributeTypeCode = attribute_type.AttributeTypeCode,
                AttributeTypeName = attribute_type.AttributeTypeName,
                AttributeTypeDesc = attribute_type.AttributeTypeDesc,
                AttributeDataTypeKey = (int)attribute_type.AttributeDataTypeKey,
                AttributeDefaultFormat = attribute_type.AttributeDefaultFormat
            };

            return AttributeType_data;
        }
    }
}
