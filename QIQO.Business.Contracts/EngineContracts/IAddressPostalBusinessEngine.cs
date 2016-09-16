using QIQO.Business.Entities;
using QIQO.Common.Contracts;
using System.Collections.Generic;

namespace QIQO.Business.Contracts
{
    public interface IAddressPostalBusinessEngine : IBusinessEngine
    {
        List<AddressPostal> GetStateListByCountry(string country);
        AddressPostal GetAddressPostalByCode(string postal_code);
    }
}