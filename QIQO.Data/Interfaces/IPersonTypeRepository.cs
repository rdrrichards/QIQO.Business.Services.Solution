using QIQO.Common.Contracts;
using QIQO.Data.Entities;
using System.Collections.Generic;

namespace QIQO.Data.Interfaces
{
    public interface IPersonTypeRepository : IRepository<PersonTypeData>
    {
        IEnumerable<PersonTypeData> GetAllByCategory(string category);
    }
}