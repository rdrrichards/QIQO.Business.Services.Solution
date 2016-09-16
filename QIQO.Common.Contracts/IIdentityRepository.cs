using System;
using System.Collections.Generic;

namespace QIQO.Common.Contracts
{
    public interface IIdentityRepository
    {
    }
    public interface IIdentityRepository<T> : IIdentityRepository
        where T : class, IIdentityEntity, new()
    {
        IEnumerable<T> GetAll();
        T GetByID(Guid id);
        T GetByName(string name);
        void Delete(T entity);
        int Save(T entity);
    }
}
