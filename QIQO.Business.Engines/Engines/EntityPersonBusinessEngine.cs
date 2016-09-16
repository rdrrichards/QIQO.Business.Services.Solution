namespace QIQO.Business.Engines
{
    //public class EntityPersonBusinessEngine : EngineBase, IEntityPersonBusinessEngine
    //{
    ////    //private IEntityPersonRepository entity_person_repo;
    ////    private IDataRepositoryFactory _data_repository_factory;
    ////    private IBusinessEngineFactory _business_engine_factory;

    ////    public EntityPersonBusinessEngine(IDataRepositoryFactory data_repo_fact, IBusinessEngineFactory bus_eng_fact) //
    ////    {
    ////        _data_repository_factory = data_repo_fact;
    ////        _business_engine_factory = bus_eng_fact;
    ////    }

    ////    public bool EntityPersonDelete(EntityPerson entity_person)
    ////    {
    ////        return ExecuteFaultHandledOperation(() =>
    ////        {
    ////            IEntityPersonRepository entity_person_repo = _data_repository_factory.GetDataRepository<IEntityPersonRepository>();
    ////            EntityPersonData entity_person = MapEntityPersonToEntityPersonData(entity_person);

    ////            entity_person_repo.Delete(entity_person);
    ////            return true;
    ////        });
    ////    }

    ////    public int EntityPersonSave(EntityPerson entity_person)
    ////    {
    ////        if (entity_person == null)
    ////            throw new ArgumentNullException("entity_person", "The entity_person parameter is invalid");

    ////        return ExecuteFaultHandledOperation(() =>
    ////        {
    ////            IEntityPersonRepository entity_person_repo = _data_repository_factory.GetDataRepository<IEntityPersonRepository>();

    ////            int entity_person_key;
    ////            EntityPersonData prod_data = MapEntityPersonToEntityPersonData(entity_person);

    ////            entity_person_key = entity_person_repo.Insert(prod_data);

    ////            return entity_person_key;
    ////        });
    ////    }
    ////    public EntityPerson GetEntityPersonByCode(string entity_person_code, Company company)
    ////    {
    ////        return GetEntityPersonByCode(entity_person_code, company.CompanyCode);
    ////    }

    ////    public EntityPerson GetEntityPersonByCode(string entity_person_code, string company_code)
    ////    {
    ////        Log.Info("Accessing EntityPersonBusinessEngine GetEntityPersonByCode function");
    ////        return ExecuteFaultHandledOperation(() =>
    ////        {
    ////            IEntityPersonRepository entity_person_repo = _data_repository_factory.GetDataRepository<IEntityPersonRepository>();
    ////            EntityPersonData entity_person_data = entity_person_repo.GetByCode(entity_person_code, company_code);
    ////            Log.Info("EntityPersonBusinessEngine GetEntityPersonByCode function completed");

    ////            if (entity_person_data.EntityPersonKey != 0)
    ////            {
    ////                EntityPerson entity_person = MapEntityPersonDataToEntityPerson(entity_person_data);

    ////                return entity_person;
    ////            }
    ////            else
    ////            {
    ////    //Log.Info("{0} EntityPersonBusinessEngine Error: Unable to find entity_person with key {1}", entity_person_key);
    ////    //FaultException ex = new FaultException(string.Format("EntityPerson with login {0} is not in database", entity_person_key));
    ////    //throw ex;
    ////    NotFoundException ex = new NotFoundException(string.Format("EntityPerson with code {0} is not in database", entity_person_code));
    ////                throw new FaultException<NotFoundException>(ex, ex.Message);
    ////            }
    ////        });
    ////    }
    ////    public EntityPerson GetEntityPersonByID(int entity_person_key)
    ////    {

    ////        //if (Unity.Container != null)
    ////        //{
    ////        //    foreach (ContainerRegistration reg in Unity.Container.Registrations)
    ////        //        Log.Info(reg.RegisteredType.ToString());
    ////        //}
    ////        //Log.Info("{0} Accessing EntityPersonBusinessEngine GetEntityPersonByID function");

    ////        Log.Info("Accessing EntityPersonBusinessEngine GetEntityPersonByID function");
    ////        return ExecuteFaultHandledOperation(() =>
    ////        {
    ////            IEntityPersonRepository entity_person_repo = _data_repository_factory.GetDataRepository<IEntityPersonRepository>();
    ////            EntityPersonData entity_person_data = entity_person_repo.GetByID(entity_person_key);
    ////            Log.Info("EntityPersonBusinessEngine GetByID function completed");

    ////            if (entity_person_data.EntityPersonKey != 0)
    ////            {
    ////                EntityPerson entity_person = MapEntityPersonDataToEntityPerson(entity_person_data);

    ////                return entity_person;
    ////            }
    ////            else
    ////            {
    ////    //Log.Info("{0} EntityPersonBusinessEngine Error: Unable to find entity_person with key {1}", entity_person_key);
    ////    //FaultException ex = new FaultException(string.Format("EntityPerson with login {0} is not in database", entity_person_key));
    ////    //throw ex;
    ////    NotFoundException ex = new NotFoundException(string.Format("EntityPerson with key {0} is not in database", entity_person_key));
    ////                throw new FaultException<NotFoundException>(ex, ex.Message);
    ////            }
    ////        });
    ////    }

    ////    public List<EntityPerson> GetEntityPersonsByCompany(Company company)
    ////    {
    ////        if (company == null)
    ////            throw new ArgumentNullException(nameof(company));

    ////        return ExecuteFaultHandledOperation(() =>
    ////        {
    ////            IEntityPersonRepository entity_person_repo = _data_repository_factory.GetDataRepository<IEntityPersonRepository>();
    ////// _business_engine_factory
    ////List<EntityPerson> entity_persons = new List<EntityPerson>();
    ////            CompanyData comp = new CompanyData();
    ////            comp.CompanyKey = company.CompanyKey;

    ////            IEnumerable<EntityPersonData> entity_persons = entity_person_repo.GetAll(comp);

    ////            foreach (EntityPersonData entity_person in entity_persons)
    ////            {
    ////                EntityPerson entity_person = MapEntityPersonDataToEntityPerson(entity_person);
    ////                entity_persons.Add(entity_person);
    ////            }
    ////            return entity_persons;
    ////        });
    ////    }
    ////    private EntityPerson MapEntityPersonDataToEntityPerson(EntityPersonData entity_person_data)
    ////    {
    ////        EntityPerson entity_person = new EntityPerson()
    ////        {
    ////            AddedUserID = entity_person_data.AuditAddUserId,
    ////            AddedDateTime = entity_person_data.AuditAddDatetime,
    ////            UpdateUserID = entity_person_data.AuditUpdateUserId,
    ////            UpdateDateTime = entity_person_data.AuditUpdateDatetime
    ////        };

    ////        return entity_person;
    ////    }
    ////    private EntityPersonData MapEntityPersonToEntityPersonData(EntityPerson entity_person)
    ////    {
    ////        EntityPersonData entity_person_data = new EntityPersonData()
    ////        {

    ////        };

    ////        return entity_person_data;
    ////    }
    //}
}