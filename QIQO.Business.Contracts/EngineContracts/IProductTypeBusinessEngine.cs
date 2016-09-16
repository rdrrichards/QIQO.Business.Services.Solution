using QIQO.Business.Entities;
using QIQO.Common.Contracts;
using System.Collections.Generic;

namespace QIQO.Business.Contracts
{
    public interface IProductTypeBusinessEngine : ITypeBusinessEngine<ProductType>, IBusinessEngine
    {
        List<ProductType> GetTypesByCategory(string category);
    }
}