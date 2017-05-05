using QIQO.Common.Contracts;
using QIQO.Common.Core;

namespace QIQO.Data
{
    public class DataRepositoryFactory : IDataRepositoryFactory
    {
        public T GetDataRepository<T>() where T : class, IRepository
        {
            return IocContainer.Container.GetInstance<T>();
        }
        public T GetIdentityDataRepository<T>() where T : class, IIdentityRepository
        {
            return IocContainer.Container.GetInstance<T>();
        }
    }
}
