namespace QIQO.Business.Engines
{
    //public class EntityEntityBusinessEngine : EngineBase, IEntityEntityBusinessEngine
    //{
    ////    //private IEntityEntityRepository entity_entity_repo;
    ////    private IDataRepositoryFactory _data_repository_factory;
    ////    private IBusinessEngineFactory _business_engine_factory;

    ////    public EntityEntityBusinessEngine(IDataRepositoryFactory data_repo_fact, IBusinessEngineFactory bus_eng_fact) //
    ////    {
    ////        _data_repository_factory = data_repo_fact;
    ////        _business_engine_factory = bus_eng_fact;
    ////    }

    ////    public bool EntityEntityDelete(EntityEntity entity_entity)
    ////    {
    ////        return ExecuteFaultHandledOperation(() =>
    ////        {
    ////            IEntityEntityRepository entity_entity_repo = _data_repository_factory.GetDataRepository<IEntityEntityRepository>();
    ////            EntityEntityData entity_entity = MapEntityEntityToEntityEntityData(entity_entity);

    ////            entity_entity_repo.Delete(entity_entity);
    ////            return true;
    ////        });
    ////    }

    ////    public int EntityEntitySave(EntityEntity entity_entity)
    ////    {
    ////        if (entity_entity == null)
    ////            throw new ArgumentNullException("entity_entity", "The entity_entity parameter is invalid");

    ////        return ExecuteFaultHandledOperation(() =>
    ////        {
    ////            IEntityEntityRepository entity_entity_repo = _data_repository_factory.GetDataRepository<IEntityEntityRepository>();

    ////            int entity_entity_key;
    ////            EntityEntityData prod_data = MapEntityEntityToEntityEntityData(entity_entity);

    ////            entity_entity_key = entity_entity_repo.Insert(prod_data);

    ////            return entity_entity_key;
    ////        });
    ////    }
    ////    public EntityEntity GetEntityEntityByCode(string entity_entity_code, Company company)
    ////    {
    ////        return GetEntityEntityByCode(entity_entity_code, company.CompanyCode);
    ////    }

    ////    public EntityEntity GetEntityEntityByCode(string entity_entity_code, string company_code)
    ////    {
    ////        Log.Info("Accessing EntityEntityBusinessEngine GetEntityEntityByCode function");
    ////        return ExecuteFaultHandledOperation(() =>
    ////        {
    ////            IEntityEntityRepository entity_entity_repo = _data_repository_factory.GetDataRepository<IEntityEntityRepository>();
    ////            EntityEntityData entity_entity_data = entity_entity_repo.GetByCode(entity_entity_code, company_code);
    ////            Log.Info("EntityEntityBusinessEngine GetEntityEntityByCode function completed");

    ////            if (entity_entity_data.EntityEntityKey != 0)
    ////            {
    ////                EntityEntity entity_entity = MapEntityEntityDataToEntityEntity(entity_entity_data);

    ////                return entity_entity;
    ////            }
    ////            else
    ////            {
    ////    //Log.Info("{0} EntityEntityBusinessEngine Error: Unable to find entity_entity with key {1}", entity_entity_key);
    ////    //FaultException ex = new FaultException(string.Format("EntityEntity with login {0} is not in database", entity_entity_key));
    ////    //throw ex;
    ////    NotFoundException ex = new NotFoundException(string.Format("EntityEntity with code {0} is not in database", entity_entity_code));
    ////                throw new FaultException<NotFoundException>(ex, ex.Message);
    ////            }
    ////        });
    ////    }
    ////    public EntityEntity GetEntityEntityByID(int entity_entity_key)
    ////    {

    ////        //if (Unity.Container != null)
    ////        //{
    ////        //    foreach (ContainerRegistration reg in Unity.Container.Registrations)
    ////        //        Log.Info(reg.RegisteredType.ToString());
    ////        //}
    ////        //Log.Info("{0} Accessing EntityEntityBusinessEngine GetEntityEntityByID function");

    ////        Log.Info("Accessing EntityEntityBusinessEngine GetEntityEntityByID function");
    ////        return ExecuteFaultHandledOperation(() =>
    ////        {
    ////            IEntityEntityRepository entity_entity_repo = _data_repository_factory.GetDataRepository<IEntityEntityRepository>();
    ////            EntityEntityData entity_entity_data = entity_entity_repo.GetByID(entity_entity_key);
    ////            Log.Info("EntityEntityBusinessEngine GetByID function completed");

    ////            if (entity_entity_data.EntityEntityKey != 0)
    ////            {
    ////                EntityEntity entity_entity = MapEntityEntityDataToEntityEntity(entity_entity_data);

    ////                return entity_entity;
    ////            }
    ////            else
    ////            {
    ////    //Log.Info("{0} EntityEntityBusinessEngine Error: Unable to find entity_entity with key {1}", entity_entity_key);
    ////    //FaultException ex = new FaultException(string.Format("EntityEntity with login {0} is not in database", entity_entity_key));
    ////    //throw ex;
    ////    NotFoundException ex = new NotFoundException(string.Format("EntityEntity with key {0} is not in database", entity_entity_key));
    ////                throw new FaultException<NotFoundException>(ex, ex.Message);
    ////            }
    ////        });
    ////    }

    ////    public List<EntityEntity> GetEntityEntitysByCompany(Company company)
    ////    {
    ////        if (company == null)
    ////            throw new ArgumentNullException(nameof(company));

    ////        return ExecuteFaultHandledOperation(() =>
    ////        {
    ////            IEntityEntityRepository entity_entity_repo = _data_repository_factory.GetDataRepository<IEntityEntityRepository>();
    ////// _business_engine_factory
    ////List<EntityEntity> entity_entitys = new List<EntityEntity>();
    ////            CompanyData comp = new CompanyData();
    ////            comp.CompanyKey = company.CompanyKey;

    ////            IEnumerable<EntityEntityData> entity_entitys = entity_entity_repo.GetAll(comp);

    ////            foreach (EntityEntityData entity_entity in entity_entitys)
    ////            {
    ////                EntityEntity entity_entity = MapEntityEntityDataToEntityEntity(entity_entity);
    ////                entity_entitys.Add(entity_entity);
    ////            }
    ////            return entity_entitys;
    ////        });
    ////    }
    ////    private EntityEntity MapEntityEntityDataToEntityEntity(EntityEntityData entity_entity_data)
    ////    {
    ////        EntityEntity entity_entity = new EntityEntity()
    ////        {
    ////            AddedUserID = entity_entity_data.AuditAddUserId,
    ////            AddedDateTime = entity_entity_data.AuditAddDatetime,
    ////            UpdateUserID = entity_entity_data.AuditUpdateUserId,
    ////            UpdateDateTime = entity_entity_data.AuditUpdateDatetime
    ////        };

    ////        return entity_entity;
    ////    }
    ////    private EntityEntityData MapEntityEntityToEntityEntityData(EntityEntity entity_entity)
    ////    {
    ////        EntityEntityData entity_entity_data = new EntityEntityData()
    ////        {

    ////        };

    ////        return entity_entity_data;
    ////    }
    //}
}