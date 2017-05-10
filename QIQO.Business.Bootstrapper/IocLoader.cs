using QIQO.Business.Services;
using QIQO.Business.Contracts;
using QIQO.Business.Engines;
using QIQO.Common.Contracts;
using QIQO.Data.Common;
using QIQO.Data.Interfaces;
using QIQO.Data.Repositories;
using QIQO.Data;
using QIQO.Data.Maps;
using QIQO.Common.Core.Caching;
using SimpleInjector;
using SimpleInjector.Integration.Wcf;
using QIQO.Common.Core;

namespace QIQO.Business.Bootstrapper
{
    public static class IocLoader
    {
        public static Container Init()
        {
            var container = IocContainer.Container; // new Container();
            container.Options.DefaultScopedLifestyle = new WcfOperationLifestyle();

            RegisterDBContexts(container);

            container.Register<ICache, LocalMemoryCache>(Lifestyle.Singleton);

            RegisterFactories(container);
            RegisterServices(container);
            RegisterBusinessEngines(container);
            RegisterRepositories(container);
            RegisterMaps(container);
            RegisterEntityServices(container);

            container.Verify();
            // try { container.Verify(); } catch { }

            SimpleInjectorServiceHostFactory.SetContainer(container);

            return container;
        }

        private static void RegisterDBContexts(Container container)
        {
            container.Register<IMainDBContext, MainDBContext>(Lifestyle.Scoped);
            container.Register<IIdentityDBContext, IdentityDBContext>(Lifestyle.Scoped);
        }

        private static void RegisterBusinessEngines(Container container)
        {
            container.Register<IAccountBusinessEngine, AccountBusinessEngine>();
            container.Register<IAccountEmployeeBusinessEngine, AccountEmployeeBusinessEngine>();
            container.Register<IAccountTypeBusinessEngine, AccountTypeBusinessEngine>(Lifestyle.Singleton);
            container.Register<IAddressBusinessEngine, AddressBusinessEngine>();
            container.Register<IAddressPostalBusinessEngine, AddressPostalBusinessEngine>();
            container.Register<IAddressTypeBusinessEngine, AddressTypeBusinessEngine>(Lifestyle.Singleton);
            container.Register<IAttributeTypeBusinessEngine, AttributeTypeBusinessEngine>(Lifestyle.Singleton);
            container.Register<IAuditLogBusinessEngine, AuditLogBusinessEngine>();
            container.Register<IChartOfAccountBusinessEngine, ChartOfAccountBusinessEngine>();
            container.Register<ICommentBusinessEngine, CommentBusinessEngine>();
            container.Register<ICommentTypeBusinessEngine, CommentTypeBusinessEngine>(Lifestyle.Singleton);
            container.Register<IContactBusinessEngine, ContactBusinessEngine>();
            container.Register<ICompanyBusinessEngine, CompanyBusinessEngine>();
            container.Register<IContactTypeBusinessEngine, ContactTypeBusinessEngine>(Lifestyle.Singleton);
            // container.Register<IAccountBusinessEngine, AccountBusinessEngine>();
            container.Register<IEmployeeBusinessEngine, EmployeeBusinessEngine>();
            container.Register<IEntityAttributeBusinessEngine, EntityAttributeBusinessEngine>();
            container.Register<IEntityProductBusinessEngine, EntityProductBusinessEngine>();
            container.Register<IEntityTypeBusinessEngine, EntityTypeBusinessEngine>();
            container.Register<IFeeScheduleBusinessEngine, FeeScheduleBusinessEngine>();
            container.Register<IInvoiceBusinessEngine, InvoiceBusinessEngine>();
            container.Register<ILedgerBusinessEngine, LedgerBusinessEngine>();
            container.Register<IOrderBusinessEngine, OrderBusinessEngine>();
            container.Register<IPersonTypeBusinessEngine, PersonTypeBusinessEngine>();
            container.Register<IProductBusinessEngine, ProductBusinessEngine>();
            //container.Register<IUserSessionBusinessEngine, UserSessionBusinessEngine>();
            container.Register<IProductTypeBusinessEngine, ProductTypeBusinessEngine>();
            container.Register<IOrderStatusBusinessEngine, OrderStatusBusinessEngine>(Lifestyle.Singleton);
            container.Register<IOrderItemStatusBusinessEngine, OrderItemStatusBusinessEngine>(Lifestyle.Singleton);
            container.Register<IIdentityUserBusinessEngine, IdentityUserBusinessEngine>();
            container.Register<IIdentityRoleBusinessEngine, IdentityRoleBusinessEngine>();
        }

        private static void RegisterServices(Container container)
        {
            container.Register<IAccountService, AccountService>();
            container.Register<IAddressService, AddressService>();
            container.Register<IAuditService, AuditService>();
            container.Register<ICompanyService, CompanyService>();
            container.Register<IEmployeeService, EmployeeService>();
            container.Register<IEntityProductService, EntityProductService>();
            container.Register<IFeeScheduleService, FeeScheduleService>();
            container.Register<IInvoiceService, InvoiceService>();
            container.Register<ILedgerService, LedgerService>();
            container.Register<IOrderService, OrderService>();
            container.Register<IProductService, ProductService>();
            container.Register<ISessionService, SessionService>();
            container.Register<ITypeService, TypeService>();
            container.Register<IIdentityUserService, IdentityUserService>();
            container.Register<IIdentityRoleService, IdentityRoleService>();
        }

        private static void RegisterRepositories(Container container)
        {
            container.Register<IAccountRepository, AccountRepository>();
            container.Register<IAccountTypeRepository, AccountTypeRepository>();
            container.Register<IAddressRepository, AddressRepository>();
            container.Register<IAddressPostalRepository, AddressPostalRepository>();
            container.Register<IAddressTypeRepository, AddressTypeRepository>();
            container.Register<IAttributeRepository, AttributeRepository>();
            container.Register<IAttributeTypeRepository, AttributeTypeRepository>();
            container.Register<IAuditLogRepository, AuditLogRepository>();
            container.Register<IChartOfAccountsRepository, ChartOfAccountsRepository>();
            container.Register<ICommentRepository, CommentRepository>();
            container.Register<ICommentTypeRepository, CommentTypeRepository>();
            container.Register<ICompanyRepository, CompanyRepository>();
            container.Register<IContactRepository, ContactRepository>();
            container.Register<IContactTypeRepository, ContactTypeRepository>();
            container.Register<IEntityEntityRepository, EntityEntityRepository>();
            container.Register<IEntityPersonRepository, EntityPersonRepository>();
            container.Register<IEntityProductRepository, EntityProductRepository>();
            container.Register<IEntityTypeRepository, EntityTypeRepository>();
            container.Register<IFeeScheduleRepository, FeeScheduleRepository>();
            container.Register<IInvoiceRepository, InvoiceRepository>();
            container.Register<IInvoiceItemRepository, InvoiceItemRepository>();
            container.Register<IInvoiceStatusRepository, InvoiceStatusRepository>();
            container.Register<ILedgerRepository, LedgerRepository>();
            container.Register<ILedgerTxnRepository, LedgerTxnRepository>();
            container.Register<IOrderHeaderRepository, OrderHeaderRepository>();
            container.Register<IOrderItemRepository, OrderItemRepository>();
            container.Register<IOrderStatusRepository, OrderStatusRepository>();
            container.Register<IPersonRepository, PersonRepository>();
            container.Register<IPersonTypeRepository, PersonTypeRepository>();
            container.Register<IProductRepository, ProductRepository>();
            container.Register<IProductTypeRepository, ProductTypeRepository>();
            container.Register<IUserSessionRepository, UserSessionRepository>();
            container.Register<IVendorRepository, VendorRepository>();

            container.Register<IUserRepository, UserRepository>();
            container.Register<IUserClaimRepository, UserClaimRepository>();
            container.Register<IUserRoleRepository, UserRoleRepository>();
            container.Register<IUserLoginRepository, UserLoginRepository>();
            container.Register<IRoleRepository, RoleRepository>();
            container.Register<IRoleClaimRepository, RoleClaimRepository>();
        }

        private static void RegisterFactories(Container container)
        {
            container.Register<IBusinessEngineFactory, BusinessEngineFactory>(Lifestyle.Singleton);
            container.Register<IDataRepositoryFactory, DataRepositoryFactory>(Lifestyle.Singleton);
            container.Register<IEntityServiceFactory, EntityServiceFactory>(Lifestyle.Singleton);
        }

        private static void RegisterMaps(Container container)
        {
            container.Register<IAccountMap, AccountMap>();
            container.Register<IAccountTypeMap, AccountTypeMap>();
            container.Register<IAddressMap, AddressMap>();
            container.Register<IAddressPostalMap, AddressPostalMap>();
            container.Register<IAddressTypeMap, AddressTypeMap>();
            container.Register<IAttributeMap, AttributeMap>();
            container.Register<IAttributeTypeMap, AttributeTypeMap>();
            container.Register<IAuditLogMap, AuditLogMap>();
            container.Register<IChartOfAccountsMap, ChartOfAccountsMap>();
            container.Register<ICommentMap, CommentMap>();
            container.Register<ICommentTypeMap, CommentTypeMap>();
            container.Register<ICompanyMap, CompanyMap>();
            container.Register<IContactMap, ContactMap>();
            container.Register<IContactTypeMap, ContactTypeMap>();
            container.Register<IEntityEntityMap, EntityEntityMap>();
            container.Register<IEntityPersonMap, EntityPersonMap>();
            container.Register<IEntityProductMap, EntityProductMap>();
            container.Register<IEntityTypeMap, EntityTypeMap>();
            container.Register<IFeeScheduleMap, FeeScheduleMap>();
            container.Register<IInvoiceItemMap, InvoiceItemMap>();
            container.Register<IInvoiceMap, InvoiceMap>();
            container.Register<IInvoiceStatusMap, InvoiceStatusMap>();
            container.Register<ILedgerMap, LedgerMap>();
            container.Register<ILedgerTxnMap, LedgerTxnMap>();
            container.Register<IOrderHeaderMap, OrderHeaderMap>();
            container.Register<IOrderItemMap, OrderItemMap>();
            container.Register<IOrderStatusMap, OrderStatusMap>();
            container.Register<IPersonMap, PersonMap>();
            container.Register<IPersonTypeMap, PersonTypeMap>();
            container.Register<IProductMap, ProductMap>();
            container.Register<IProductTypeMap, ProductTypeMap>();
            container.Register<IUserSessionMap, UserSessionMap>();
            container.Register<IVendorMap, VendorMap>();

            container.Register<IUserMap, UserMapper>();
            container.Register<IUserClaimMap, UserClaimMapper>();
            container.Register<IUserRoleMap, UserRoleMapper>();
            container.Register<IUserLoginMap, UserLoginMapper>();
            container.Register<IRoleMap, RoleMapper>();
            container.Register<IRoleClaimMap, RoleClaimMapper>();
        }

        private static void RegisterEntityServices(Container container)
        {
            container.Register<IEntityTypeEntityService, EntityTypeEntityService>();
            container.Register<IAttributeTypeEntityService, AttributeTypeEntityService>();
            container.Register<IAccountEntityService, AccountEntityService>();
            container.Register<IAccountTypeEntityService, AccountTypeEntityService>();
            container.Register<IAuditLogEntityService, AuditLogEntityService>();
            container.Register<ICompanyEntityService, CompanyEntityService>();
            container.Register<IPersonEntityService, PersonEntityService>();
            //container.Register<IPersonTypeEntityService, PersonTypeEntityService>();
            container.Register<IAddressEntityService, AddressEntityService>();
            container.Register<IAddressTypeEntityService, AddressTypeEntityService>();
            container.Register<IAddressPostalEntityService, AddressPostalEntityService>();
            container.Register<IChartOfAccountEntityService, ChartOfAccountEntityService>();
            container.Register<ICommentEntityService, CommentEntityService>();
            container.Register<ICommentTypeEntityService, CommentTypeEntityService>();
            container.Register<IContactEntityService, ContactEntityService>();
            container.Register<IContactTypeEntityService, ContactTypeEntityService>();
            container.Register<IEntityAttributeEntityService, EntityAttributeEntityService>();
            container.Register<IEntityProductEntityService, EntityProductEntityService>();
            container.Register<IFeeScheduleEntityService, FeeScheduleEntityService>();
            container.Register<IInvoiceEntityService, InvoiceEntityService>();
            container.Register<IInvoiceStatusEntityService, InvoiceStatusEntityService>();
            container.Register<IInvoiceItemEntityService, InvoiceItemEntityService>();
            container.Register<IOrderEntityService, OrderEntityService>();
            container.Register<IOrderItemEntityService, OrderItemEntityService>();
            container.Register<IOrderStatusEntityService, OrderStatusEntityService>();
            container.Register<IOrderItemStatusEntityService, OrderItemStatusEntityService>();
            container.Register<IProductEntityService, ProductEntityService>();
            container.Register<IProductTypeEntityService, ProductTypeEntityService>();
        }
    }
}
