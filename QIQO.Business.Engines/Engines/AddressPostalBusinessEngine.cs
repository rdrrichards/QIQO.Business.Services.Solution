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
        public AddressPostalBusinessEngine(IDataRepositoryFactory data_repo_fact, IBusinessEngineFactory bus_eng_fact)
            : base(data_repo_fact, bus_eng_fact, null)
        {
            _address_postal_repo = _data_repository_factory.GetDataRepository<IAddressPostalRepository>();
        }

        public List<AddressPostal> GetStateListByCountry(string country)
        {
            return ExecuteFaultHandledOperation(() =>
            {
                var address_postals = new List<AddressPostal>();
                var postal_data = _address_postal_repo.GetStatesByCountry(country);

                foreach (AddressPostalData post in postal_data)
                {
                    AddressPostal address_post = Map(post);
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
                var address_post = Map(postal_data);
                return address_post;
            });
        }

        private AddressPostal Map(AddressPostalData post_data)
        {
            AddressPostal postal = new AddressPostal()
            {
                CountryName = post_data.Country,
                PostalCode = post_data.PostalCode,
                StateCode = post_data.StateCode,
                StateFullName = post_data.StateFullName,
                CityName = post_data.CityName,
                CountyName = post_data.CountyName,
                TimeZone = post_data.TimeZone
            };
            return postal;
        }
    }
}