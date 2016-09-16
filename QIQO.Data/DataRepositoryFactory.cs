using QIQO.Common.Contracts;
using QIQO.Common.Core;
using Microsoft.Practices.Unity;

namespace QIQO.Data
{
    public class DataRepositoryFactory : IDataRepositoryFactory
    {
        public T GetDataRepository<T>() where T : IRepository
        {
            return Unity.Container.Resolve<T>();
        }
        public T GetIdentityDataRepository<T>() where T : IIdentityRepository
        {
            return Unity.Container.Resolve<T>();
        }
    }
}
