using System;
using SM = System.ServiceModel;
using QIQO.Business.Services;
using QIQO.Common.Core;
using QIQO.Business.Bootstrapper;
using QIQO.Common.Core.Logging;

namespace QIQO.ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (ServiceHost host = new ServiceHost(typeof(QIQO.Business.Services.AccountService)))
            //{
            //    host.Open();
            //    Console.WriteLine("Account Service Started @ " + DateTime.Now.ToString());
            //    Console.ReadLine();
            //    host.Close();
            //}

            //Logger logr = new Logger("QIQO.Common.Core");
            Log.Info("Starting the application...");
            Unity.Container = UnityLoader.Init();

            //using (IUnityContainer container = new UnityContainer())
            using (Unity.Container)
            {
                //RegisterTypes(container);
                //Unity.Container = container;

                // Step 1 Create a URI to serve as the base address.
                //Uri baseAddress = new Uri("net.tcp://localhost:7478/");

                Log.Info("Configuring UnityServiceHost...");
                // Step 2 Create a ServiceHost instance
                SM.ServiceHost hostAccountService = new UnityServiceHost(Unity.Container, typeof(AccountService));
                SM.ServiceHost hostAddressService = new UnityServiceHost(Unity.Container, typeof(AddressService));
                SM.ServiceHost hostAuditService = new UnityServiceHost(Unity.Container, typeof(AuditService));
                SM.ServiceHost hostCompanyService = new UnityServiceHost(Unity.Container, typeof(CompanyService));
                SM.ServiceHost hostEmployeeService = new UnityServiceHost(Unity.Container, typeof(EmployeeService));
                SM.ServiceHost hostEntityProductService = new UnityServiceHost(Unity.Container, typeof(EntityProductService));
                SM.ServiceHost hostFeeScheduleService = new UnityServiceHost(Unity.Container, typeof(FeeScheduleService));
                SM.ServiceHost hostInvoiceService = new UnityServiceHost(Unity.Container, typeof(InvoiceService));
                SM.ServiceHost hostLedgerService = new UnityServiceHost(Unity.Container, typeof(LedgerService));
                SM.ServiceHost hostOrderService = new UnityServiceHost(Unity.Container, typeof(OrderService));
                SM.ServiceHost hostProductService = new UnityServiceHost(Unity.Container, typeof(ProductService));
                SM.ServiceHost hostSessionService = new UnityServiceHost(Unity.Container, typeof(SessionService));
                SM.ServiceHost hostTypeService = new UnityServiceHost(Unity.Container, typeof(TypeService));
                SM.ServiceHost hostIdentityUserService = new UnityServiceHost(Unity.Container, typeof(IdentityUserService));
                SM.ServiceHost hostIdentityRoleService = new UnityServiceHost(Unity.Container, typeof(IdentityRoleService));

                try
                {
                    //using (hostAccountService)
                    //{
                    //    Log.Info("Opening Service Host...");
                    //    hostAccountService.Open();
                    //    Log.Info("Account Service Started @ " + DateTime.Now.ToString());
                    //    Console.ReadLine();
                    //    hostAccountService.Close();
                    //    Log.Info("Account Service stopped @ " + DateTime.Now.ToString());
                    //}

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


                    Console.WriteLine("");
                    Console.WriteLine("Press [Enter] to exit.");
                    Console.ReadLine();
                    Console.WriteLine("");

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
                catch (SM.CommunicationException ce)
                {
                    Log.Error("An exception occurred: {0}", ce.Message);
                }
                catch (Exception ex)
                {
                    Log.Error("An exception occurred: {0}", ex.Message);
                }
                finally
                {
                    hostAccountService.Abort();
                    hostAddressService.Abort();
                    hostAuditService.Abort();
                    hostCompanyService.Abort();
                    hostEmployeeService.Abort();
                    hostEntityProductService.Abort();
                    hostFeeScheduleService.Abort();
                    hostInvoiceService.Abort();
                    hostLedgerService.Abort();
                    hostOrderService.Abort();
                    hostProductService.Abort();
                    hostSessionService.Abort();
                    hostTypeService.Abort();
                    hostIdentityUserService.Abort();
                    hostIdentityRoleService.Abort();
                }
            }


        }

        static void StartService(SM.ServiceHost host, string serviceDescription)
        {
            //var behavior = host.Description.Behaviors.Find<QIQOServiceBehaviorAttribute>();
            //if (behavior == null)
            //{
            //    behavior = new QIQOServiceBehaviorAttribute(false);
            //    host.Description.Behaviors.Add(behavior);
            //}

            //behavior.ServiceOperationCalled += (s, e) =>
            //{

            //};
            //host.ImpersonateAll();
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

        static void StopService(SM.ServiceHost host, string serviceDescription)
        {
            host.Close();
            Log.Info("Service '{0}' stopped.", serviceDescription);
        }

        //private static void RegisterTypes(IUnityContainer container)
        //{
        //    container.RegisterType<IDBContext, SqlDBContext>();
        //    container.RegisterType<IAccountService, AccountService>();
        //    container.RegisterType<IAccountBusinessEngine, AccountBusinessEngine>();
        //    container.RegisterType<IAccountRepository, AccountRepository>();
        //}

    }
}
