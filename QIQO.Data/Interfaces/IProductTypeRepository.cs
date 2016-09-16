using QIQO.Common.Contracts;
using QIQO.Data.Entities;
using System.Collections.Generic;

namespace QIQO.Data.Interfaces
{
    public interface IProductTypeRepository : IRepository<ProductTypeData>
    {
        IEnumerable<ProductTypeData> GetAllByCategory(string category);
    }
}