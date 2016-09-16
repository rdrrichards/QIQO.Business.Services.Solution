using QIQO.Business.Entities;
using QIQO.Common.Contracts;
using System.Collections.Generic;

namespace QIQO.Business.Contracts
{
    public interface IPersonTypeBusinessEngine : ITypeBusinessEngine<PersonType>, IBusinessEngine
    {
        List<PersonType> GetTypesByCategory(string category);
    }
}