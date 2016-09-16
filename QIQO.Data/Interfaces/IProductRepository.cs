using QIQO.Common.Contracts;
using QIQO.Data.Entities;
using System.Collections.Generic;

namespace QIQO.Data.Interfaces
{
    public interface IProductRepository : IRepository<ProductData>
    {
        IEnumerable<ProductData> GetAll(CompanyData company);
    }
}