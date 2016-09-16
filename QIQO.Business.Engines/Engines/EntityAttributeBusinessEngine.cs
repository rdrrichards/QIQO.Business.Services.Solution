using System;
using System.Collections.Generic;
using QIQO.Business.Contracts;
using QIQO.Business.Entities;
using QIQO.Common.Contracts;
using QIQO.Data.Entities;
using QIQO.Data.Interfaces;

namespace QIQO.Business.Engines
{
    public class EntityAttributeBusinessEngine : EngineBase, IEntityAttributeBusinessEngine
    {
        private readonly IAttributeRepository _attribute_repo;
        private readonly IEntityTypeBusinessEngine _entity_type_be;
        private readonly IAttributeTypeBusinessEngine _attribute_type_be;
        private readonly IEntityAttributeEntityService _ent_att_es;
        public EntityAttributeBusinessEngine(IDataRepositoryFactory data_repo_fact, IBusinessEngineFactory bus_eng_fact, IEntityServiceFactory ent_serv_fact)
        : base(data_repo_fact, bus_eng_fact, ent_serv_fact)
        {
            _attribute_repo = _data_repository_factory.GetDataRepository<IAttributeRepository>();
            _entity_type_be = _business_engine_factory.GetBusinessEngine<IEntityTypeBusinessEngine>();
            _attribute_type_be = _business_engine_factory.GetBusinessEngine<IAttributeTypeBusinessEngine>();
            _ent_att_es = _entity_service_factory.GetEntityService<IEntityAttributeEntityService>();
        }

        public bool EntityAttributeDelete(EntityAttribute attribute)
        {
            if (attribute == null)
                throw new ArgumentNullException(nameof(attribute));

            return ExecuteFaultHandledOperation(() =>
            {
                var attrib = _ent_att_es.Map(attribute);
                attrib.AttributeKey = attribute.AttributeKey;

                _attribute_repo.Delete(attrib);
                return true;
            });
        }

        public int EntityAttributeUpdate(EntityAttribute attribute)
        {
            if (attribute == null)
                throw new ArgumentNullException(nameof(attribute));

            return ExecuteFaultHandledOperation(() =>
            {
                var attrib = _ent_att_es.Map(attribute);
                attrib.AttributeKey = attribute.AttributeKey;

                return _attribute_repo.Insert(attrib);
            });
        }

        public List<EntityAttribute> GetAllAttribute()
        {
            var attributes = new List<EntityAttribute>();
            return ExecuteFaultHandledOperation(() =>
            {
                var entity_attribs = _attribute_repo.GetAll();

                foreach (AttributeData entity_attrib in entity_attribs)
                {
                    attributes.Add(MapAttributeDataToEntityAttribute(entity_attrib));
                }
                return attributes;
            });
        }

        public List<EntityAttribute> GetAttributeByEntity(int entity_key, QIQOEntityType entity_type)
        {
            var attributes = new List<EntityAttribute>();
            return ExecuteFaultHandledOperation(() =>
            {
                var entity_attribs = _attribute_repo.GetAll(entity_key, (int)entity_type);

                foreach (AttributeData entity_attrib in entity_attribs)
                {
                    attributes.Add(MapAttributeDataToEntityAttribute(entity_attrib));
                }
                return attributes;
            });
        }

        public EntityAttribute GetEntityAttributeByKey(int attrib_key, int entity_key)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var entity_attrib_data = _attribute_repo.GetByID(attrib_key);
                var attribute = MapAttributeDataToEntityAttribute(entity_attrib_data); //, attrib_type_data);
                return attribute;
            });
        }

        private EntityAttribute MapAttributeDataToEntityAttribute(AttributeData entity_attrib_data) //, AttributeTypeData attrib_type_data)
        {
            var attribute = _ent_att_es.Map(entity_attrib_data);

            attribute.EntityTypeData = _entity_type_be.GetTypeByKey(entity_attrib_data.EntityTypeKey);
            attribute.AttributeTypeData = _attribute_type_be.GetTypeByKey(entity_attrib_data.AttributeTypeKey);

            return attribute;
        }
    }
}