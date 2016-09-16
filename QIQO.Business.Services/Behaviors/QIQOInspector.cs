using QIQO.Business.Contracts;
using Microsoft.Practices.Unity;
using QIQO.Common.Core;
using System.ServiceModel.Dispatcher;
using System.Threading.Tasks;
using System.Configuration;

namespace QIQO.Business.Services.Behaviors
{
    public class QIQOInspector : IParameterInspector
    {
        private string _service_name;
        private static string audit_on_read => ConfigurationManager.AppSettings["audit_on_read"].ToLower();

        public QIQOInspector(string service_name)
        {
            _service_name = service_name;
        }
        public async void AfterCall(string operationName, object[] outputs, object returnValue, object correlationState)
        {
            if (audit_on_read == "true")
                await Task.Run(() =>
                {
                    DoAudit(operationName, returnValue);
                });
        }

        public object BeforeCall(string operationName, object[] inputs)
        {
            return null;
        }

        private void DoAudit(string operation, object object_to_audit)
        {
            //Console.WriteLine("************************************************************************");
            //Console.WriteLine($"PERFORMING AUDIT ON {operation} FOR OBJECT {obejct_to_audit.ToString()}");
            //Console.WriteLine("************************************************************************");
            var audit_be = Unity.Container.Resolve<IAuditLogBusinessEngine>();
            audit_be.AuditObject(_service_name, operation, object_to_audit);
            audit_be = null;
        }
    }
}
