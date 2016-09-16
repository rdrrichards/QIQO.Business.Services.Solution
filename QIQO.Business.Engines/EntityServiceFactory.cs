using QIQO.Common.Contracts;
using QIQO.Common.Core;
using Microsoft.Practices.Unity;

namespace QIQO.Business.Engines
{
    public class EntityServiceFactory : IEntityServiceFactory
    {
        public T GetEntityService<T>()where T : IEntityService
        {
            return Unity.Container.Resolve<T>();
        }
    }
}