using QIQO.Business.Entities;
using QIQO.Common.Contracts;
using System.Collections.Generic;

namespace QIQO.Business.Contracts
{
    public interface IContactTypeBusinessEngine : ITypeBusinessEngine<ContactType>, IBusinessEngine
    {
        List<ContactType> GetTypesByCategory(string category);
    }
}