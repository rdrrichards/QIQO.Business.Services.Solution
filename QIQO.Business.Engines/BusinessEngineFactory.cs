using QIQO.Common.Contracts;
using QIQO.Common.Core;

namespace QIQO.Business.Engines
{
    public class BusinessEngineFactory : IBusinessEngineFactory
    {
        public T GetBusinessEngine<T>()where T : class, IBusinessEngine
        {
            return IocContainer.Container.GetInstance<T>();
        }
    }
}