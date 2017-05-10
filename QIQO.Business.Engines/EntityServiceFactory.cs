using QIQO.Common.Contracts;
using QIQO.Common.Core;

namespace QIQO.Business.Engines
{
    public class EntityServiceFactory : IEntityServiceFactory
    {
        public T GetEntityService<T>()where T : class, IEntityService
        {
            return IocContainer.Container.GetInstance<T>();
        }
    }
}