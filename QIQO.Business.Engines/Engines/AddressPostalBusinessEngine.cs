using QIQO.Business.Contracts;
using QIQO.Business.Entities;
using QIQO.Common.Contracts;
using QIQO.Data.Entities;
using QIQO.Data.Interfaces;
using System.Collections.Generic;

namespace QIQO.Business.Engines
{
    public class AddressPostalBusinessEngine : EngineBase, IAddressPostalBusinessEngine
    {
        private readonly IAddressPostalRepository _address_postal_repo;
        private readonly IAddressPostalEntityService _addr_postal_es;
        public AddressPostalBusinessEngine(IDataRepositoryFactory data_repo_fact, IBusinessEngineFactory bus_eng_fact, IEntityServiceFactory ent_serv_fact)
            : base(data_repo_fact, bus_eng_fact, ent_serv_fact)
        {
            _address_postal_repo = _data_repository_factory.GetDataRepository<IAddressPostalRepository>();
            _addr_postal_es = _entity_service_factory.GetEntityService<IAddressPostalEntityService>();
        }

        public List<AddressPostal> GetStateListByCountry(string country)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var address_postals = new List<AddressPostal>();
                var postal_data = _address_postal_repo.GetStatesByCountry(country);

                foreach (AddressPostalData post in postal_data)
                {
                    AddressPostal address_post = _addr_postal_es.Map(post);
                    address_postals.Add(address_post);
                }
                return address_postals;
            });
        }

        public AddressPostal GetAddressPostalByCode(string postal_code)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var postal_data = _address_postal_repo.GetByCode(postal_code, postal_code);
                var address_post = _addr_postal_es.Map(postal_data);
                return address_post;
            });
        }
    }
}