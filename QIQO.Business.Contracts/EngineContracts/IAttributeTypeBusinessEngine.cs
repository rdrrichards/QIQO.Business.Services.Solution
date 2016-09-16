using QIQO.Business.Entities;
using QIQO.Common.Contracts;
using System.Collections.Generic;

namespace QIQO.Business.Contracts
{
    public interface IAttributeTypeBusinessEngine : ITypeBusinessEngine<AttributeType>, IBusinessEngine
    {
        List<AttributeType> GetTypesByCategory(string category);
    }
}