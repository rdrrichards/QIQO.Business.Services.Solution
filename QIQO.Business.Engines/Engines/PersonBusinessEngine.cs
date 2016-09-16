namespace QIQO.Business.Engines
{
    //public class PersonBusinessEngine : EngineBase, IPersonBusinessEngine
    //{
    //    ////private IPersonRepository person_repo;
    //    //private IDataRepositoryFactory _data_repository_factory;
    //    //private IBusinessEngineFactory _business_engine_factory;

    //    //public PersonBusinessEngine(IDataRepositoryFactory data_repo_fact, IBusinessEngineFactory bus_eng_fact) //
    //    //{
    //    //    _data_repository_factory = data_repo_fact;
    //    //    _business_engine_factory = bus_eng_fact;
    //    //}

    //    //public bool PersonDelete(PersonBase person)
    //    //{
    //    //    return ExecuteFaultHandledOperation(() =>
    //    //    {
    //    //        IPersonRepository person_repo = _data_repository_factory.GetDataRepository<IPersonRepository>();
    //    //        PersonData person = MapPersonToPersonData(person);

    //    //        person_repo.Delete(person);
    //    //        return true;
    //    //    });
    //    //}

    //    //public int PersonSave(PersonBase person)
    //    //{
    //    //    if (person == null)
    //    //        throw new ArgumentNullException("person", "The person parameter is invalid");

    //    //    return ExecuteFaultHandledOperation(() =>
    //    //    {
    //    //        IPersonRepository person_repo = _data_repository_factory.GetDataRepository<IPersonRepository>();

    //    //        int person_key;
    //    //        PersonData prod_data = MapPersonToPersonData(person);

    //    //        person_key = person_repo.Insert(prod_data);

    //    //        return person_key;
    //    //    });
    //    //}
    //    //public PersonBase GetPersonByCode(string person_code, Company company)
    //    //{
    //    //    return GetPersonByCode(person_code, company.CompanyCode);
    //    //}

    //    //public PersonBase GetPersonByCode(string person_code, string company_code)
    //    //{
    //    //    Log.Info("Accessing PersonBusinessEngine GetPersonByCode function");
    //    //    return ExecuteFaultHandledOperation(() =>
    //    //    {
    //    //        IPersonRepository person_repo = _data_repository_factory.GetDataRepository<IPersonRepository>();
    //    //        PersonData person_data = person_repo.GetByCode(person_code, company_code);
    //    //        Log.Info("PersonBusinessEngine GetPersonByCode function completed");

    //    //        if (person_data.PersonKey != 0)
    //    //        {
    //    //            PersonBase person = MapPersonDataToPerson(person_data);

    //    //            return person;
    //    //        }
    //    //        else
    //    //        {
    //    ////Log.Info("{0} PersonBusinessEngine Error: Unable to find person with key {1}", person_key);
    //    ////FaultException ex = new FaultException(string.Format("Person with login {0} is not in database", person_key));
    //    ////throw ex;
    //    //NotFoundException ex = new NotFoundException(string.Format("Person with code {0} is not in database", person_code));
    //    //            throw new FaultException<NotFoundException>(ex, ex.Message);
    //    //        }
    //    //    });
    //    //}
    //    //public PersonBase GetPersonByID(int person_key)
    //    //{

    //    //    //if (Unity.Container != null)
    //    //    //{
    //    //    //    foreach (ContainerRegistration reg in Unity.Container.Registrations)
    //    //    //        Log.Info(reg.RegisteredType.ToString());
    //    //    //}
    //    //    //Log.Info("{0} Accessing PersonBusinessEngine GetPersonByID function");

    //    //    Log.Info("Accessing PersonBusinessEngine GetPersonByID function");
    //    //    return ExecuteFaultHandledOperation(() =>
    //    //    {
    //    //        IPersonRepository person_repo = _data_repository_factory.GetDataRepository<IPersonRepository>();
    //    //        PersonData person_data = person_repo.GetByID(person_key);
    //    //        Log.Info("PersonBusinessEngine GetByID function completed");

    //    //        if (person_data.PersonKey != 0)
    //    //        {
    //    //            PersonBase person = MapPersonDataToPerson(person_data);

    //    //            return person;
    //    //        }
    //    //        else
    //    //        {
    //    ////Log.Info("{0} PersonBusinessEngine Error: Unable to find person with key {1}", person_key);
    //    ////FaultException ex = new FaultException(string.Format("Person with login {0} is not in database", person_key));
    //    ////throw ex;
    //    //NotFoundException ex = new NotFoundException(string.Format("Person with key {0} is not in database", person_key));
    //    //            throw new FaultException<NotFoundException>(ex, ex.Message);
    //    //        }
    //    //    });
    //    //}

    //    //public List<PersonBase> GetPersonsByCompany(Company company)
    //    //{
    //    //    if (company == null)
    //    //        throw new ArgumentNullException(nameof(company));

    //    //    return ExecuteFaultHandledOperation(() =>
    //    //    {
    //    //        IPersonRepository person_repo = _data_repository_factory.GetDataRepository<IPersonRepository>();
    //    //        // _business_engine_factory
    //    //        List<PersonBase> persons = new List<PersonBase>();
    //    //        CompanyData comp = new CompanyData();
    //    //        comp.CompanyKey = company.CompanyKey;

    //    //        IEnumerable<PersonData> persons = person_repo.GetAll(comp);

    //    //        foreach (PersonData person in persons)
    //    //        {
    //    //            PersonBase person = MapPersonDataToPerson(person);
    //    //            persons.Add(person);
    //    //        }
    //    //        return persons;
    //    //    });
    //    //}
    //    //private PersonBase MapPersonDataToPerson(PersonData person_data)
    //    //{
    //    //    PersonBase person = new PersonBase()
    //    //    {
    //    //        AddedUserID = person_data.AuditAddUserId,
    //    //        AddedDateTime = person_data.AuditAddDatetime,
    //    //        UpdateUserID = person_data.AuditUpdateUserId,
    //    //        UpdateDateTime = person_data.AuditUpdateDatetime
    //    //    };

    //    //    return person;
    //    //}
    //    //private PersonData MapPersonToPersonData(PersonBase person)
    //    //{
    //    //    PersonData person_data = new PersonData()
    //    //    {

    //    //    };

    //    //    return person_data;
    //    //}
    //}
}