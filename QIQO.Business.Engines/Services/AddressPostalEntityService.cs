using QIQO.Business.Contracts;
using QIQO.Business.Entities;
using QIQO.Data.Entities;

namespace QIQO.Business.Engines
{

    public class AddressPostalEntityService : IAddressPostalEntityService
    {
        public AddressPostal Map(AddressPostalData address_postal_data)
        {
            return new AddressPostal()
            {
                CountryName = address_postal_data.Country,
                PostalCode = address_postal_data.PostalCode,
                StateCode = address_postal_data.StateCode,
                StateFullName = address_postal_data.StateFullName,
                CityName = address_postal_data.CityName,
                CountyName = address_postal_data.CountyName,
                TimeZone = address_postal_data.TimeZone,
            };
        }

        public AddressPostalData Map(AddressPostal address_postal)
        {
            return new AddressPostalData()
            {
                Country = address_postal.CountryName,
                PostalCode = address_postal.PostalCode,
                StateCode = address_postal.StateCode,
                StateFullName = address_postal.StateFullName,
                CityName = address_postal.CityName,
                CountyName = address_postal.CountyName,
                TimeZone = address_postal.TimeZone,
            };
        }
    }
}