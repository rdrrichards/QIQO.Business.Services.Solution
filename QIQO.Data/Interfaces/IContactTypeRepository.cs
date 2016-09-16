using QIQO.Common.Contracts;
using QIQO.Data.Entities;
using System.Collections.Generic;

namespace QIQO.Data.Interfaces
{
    public interface IContactTypeRepository : IRepository<ContactTypeData>
    {
        IEnumerable<ContactTypeData> GetAllByCategory(string category);
    }
}