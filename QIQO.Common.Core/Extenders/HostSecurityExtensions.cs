using System.ServiceModel;
using System.ServiceModel.Description;

namespace QIQO.Common.Core
{
    public static class HostSecurityExtensions
    {
        public static void ImpersonateAll(this ServiceHostBase host)
        {
            host.Authorization.ImpersonateCallerForAllOperations = true;
            host.Description.ImpersonateAll();
        }

        public static void ImpersonateAll(this ServiceDescription description)
        {
            foreach (ServiceEndpoint endpoint in description.Endpoints)
            {
                if (endpoint.Contract.Name == "IMetadataExchange")
                    continue;

                foreach (OperationDescription operation in endpoint.Contract.Operations)
                {
                    OperationBehaviorAttribute attribute = operation.Behaviors.Find<OperationBehaviorAttribute>();
                    attribute.Impersonation = ImpersonationOption.Allowed;
                }
            }
        }
    }
}
