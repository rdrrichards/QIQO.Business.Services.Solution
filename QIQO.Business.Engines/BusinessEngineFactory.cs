using QIQO.Common.Contracts;
using QIQO.Common.Core;
using Microsoft.Practices.Unity;

namespace QIQO.Business.Engines
{
    public class BusinessEngineFactory : IBusinessEngineFactory
    {
        public T GetBusinessEngine<T>()where T : IBusinessEngine
        {
            return Unity.Container.Resolve<T>();
        }
    }
}