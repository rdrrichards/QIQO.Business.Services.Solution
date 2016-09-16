using System;
using SM = System.ServiceModel;
using QIQO.Common.Core;
using QIQO.Business.Bootstrapper;
using QIQO.Common.Core.Logging;
using QIQO.Business.Services;

namespace QIQO.WindowsServiceHost
{
    public partial class WindowsServiceHost : System.ServiceProcess.ServiceBase
    {
        SM.ServiceHost hostAccountService;
        SM.ServiceHost hostAddressService;
        SM.ServiceHost hostAuditService;
        SM.ServiceHost hostCompanyService;
        SM.ServiceHost hostEmployeeService;
        SM.ServiceHost hostEntityProductService;
        SM.ServiceHost hostFeeScheduleService;
        SM.ServiceHost hostInvoiceService;
        SM.ServiceHost hostLedgerService;
        SM.ServiceHost hostOrderService;
        SM.ServiceHost hostProductService;
        SM.ServiceHost hostSessionService;
        SM.ServiceHost hostTypeService;
        SM.ServiceHost hostIdentityUserService;
        SM.ServiceHost hostIdentityRoleService;


        public WindowsServiceHost()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Log.Info("Starting the application...");
            Unity.Container = UnityLoader.Init();

            hostAccountService = new UnityServiceHost(Unity.Container, typeof(AccountService));
            hostAddressService = new UnityServiceHost(Unity.Container, typeof(AddressService));
            hostAuditService = new UnityServiceHost(Unity.Container, typeof(AuditService));
            hostCompanyService = new UnityServiceHost(Unity.Container, typeof(CompanyService));
            hostEmployeeService = new UnityServiceHost(Unity.Container, typeof(EmployeeService));
            hostEntityProductService = new UnityServiceHost(Unity.Container, typeof(EntityProductService));
            hostFeeScheduleService = new UnityServiceHost(Unity.Container, typeof(FeeScheduleService));
            hostInvoiceService = new UnityServiceHost(Unity.Container, typeof(InvoiceService));
            hostLedgerService = new UnityServiceHost(Unity.Container, typeof(LedgerService));
            hostOrderService = new UnityServiceHost(Unity.Container, typeof(OrderService));
            hostProductService = new UnityServiceHost(Unity.Container, typeof(ProductService));
            hostSessionService = new UnityServiceHost(Unity.Container, typeof(SessionService));
            hostTypeService = new UnityServiceHost(Unity.Container, typeof(TypeService));
            hostIdentityUserService = new UnityServiceHost(Unity.Container, typeof(IdentityUserService));
            hostIdentityRoleService = new UnityServiceHost(Unity.Container, typeof(IdentityRoleService));

            //using (Unity.Container)
            //{

            Log.Info("Configuring UnityServiceHost...");

            try
            {

                StartService(hostAccountService, "Account Service");
                StartService(hostAddressService, "Address Service");
                StartService(hostAuditService, "Audit Service");
                StartService(hostCompanyService, "Company Service");
                StartService(hostEmployeeService, "Employee Service");
                StartService(hostEntityProductService, "Entity Product Service");
                StartService(hostFeeScheduleService, "Fee Schedule Service");
                StartService(hostInvoiceService, "Invoice Service");
                StartService(hostLedgerService, "Ledger Service");
                StartService(hostOrderService, "Order Service");
                StartService(hostProductService, "Product Service");
                StartService(hostSessionService, "Session Service");
                StartService(hostTypeService, "Type Service");
                StartService(hostIdentityUserService, "Identity User Service");
                StartService(hostIdentityRoleService, "Identity Role Service");
                //Console.ReadLine();

            }
            catch (SM.CommunicationException ce)
            {
                Log.Error("An exception occurred: {0}", ce.Message);
            }
            catch (Exception ex)
            {
                Log.Error("An exception occurred: {0}", ex.Message);
            }
            //finally
            //{
            //    hostAccountService.Abort();
            //    hostAddressService.Abort();
            //    hostAuditService.Abort();
            //    hostCompanyService.Abort();
            //    hostEmployeeService.Abort();
            //    hostEntityProductService.Abort();
            //    hostFeeScheduleService.Abort();
            //    hostInvoiceService.Abort();
            //    hostLedgerService.Abort();
            //    hostOrderService.Abort();
            //    hostProductService.Abort();
            //    hostSessionService.Abort();
            //    hostTypeService.Abort();
            //    hostIdentityUserService.Abort();
            //    hostIdentityRoleService.Abort();
            //}
            //}
        }

        protected override void OnStop()
        {
            StopService(hostAccountService, "Account Service");
            StopService(hostAddressService, "Address Service");
            StopService(hostAuditService, "Audit Service");
            StopService(hostCompanyService, "Company Service");
            StopService(hostEmployeeService, "Employee Service");
            StopService(hostEntityProductService, "Entity Product Service");
            StopService(hostFeeScheduleService, "Fee Schedule Service");
            StopService(hostInvoiceService, "Invoice Service");
            StopService(hostLedgerService, "Ledger Service");
            StopService(hostOrderService, "Order Service");
            StopService(hostProductService, "Product Service");
            StopService(hostSessionService, "Session Service");
            StopService(hostTypeService, "Type Service");
            StopService(hostIdentityUserService, "Identity User Service");
            StopService(hostIdentityRoleService, "Identity Role Service");
        }

        private void StartService(SM.ServiceHost host, string serviceDescription)
        {
            host.Open();
            Log.Info("Service '{0}' started.", serviceDescription);

            foreach (var endpoint in host.Description.Endpoints)
            {
                Log.Info(string.Format("Listening on endpoint:"));
                Log.Info(string.Format("Address: {0}", endpoint.Address.Uri.ToString()));
                Log.Info(string.Format("Binding: {0}", endpoint.Binding.Name));
                Log.Info(string.Format("Contract: {0}", endpoint.Contract.ConfigurationName));
            }

            Console.WriteLine();
        }

        private void StopService(SM.ServiceHost host, string serviceDescription)
        {
            host.Close();
            Log.Info("Service '{0}' stopped.", serviceDescription);
        }
    }
}
