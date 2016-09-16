using Microsoft.Practices.Unity;
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
using System;

namespace QIQO.Business.Bootstrapper
{
    public static class UnityLoader
    {
        public static IUnityContainer Init()
        {
            IUnityContainer container = new UnityContainer();

            RegisterDBContexts(container);

            container.RegisterType<ICache, LocalMemoryCache>(new ContainerControlledLifetimeManager());

            RegisterFactories(container);
            RegisterServices(container);
            RegisterBusinessEngines(container);
            RegisterRepositories(container);
            RegisterMaps(container);
            RegisterEntityServices(container);

            return container;
        }

        private static void RegisterDBContexts(IUnityContainer container)
        {
            container.RegisterType<IMainDBContext, MainDBContext>();
            container.RegisterType<IIdentityDBContext, IdentityDBContext>();
        }

        private static void RegisterBusinessEngines(IUnityContainer container)
        {
            container.RegisterType<IAccountBusinessEngine, AccountBusinessEngine>();
            container.RegisterType<IAccountEmployeeBusinessEngine, AccountEmployeeBusinessEngine>();
            container.RegisterType<IAccountTypeBusinessEngine, AccountTypeBusinessEngine>(new ContainerControlledLifetimeManager());
            container.RegisterType<IAddressBusinessEngine, AddressBusinessEngine>();
            container.RegisterType<IAddressPostalBusinessEngine, AddressPostalBusinessEngine>();
            container.RegisterType<IAddressTypeBusinessEngine, AddressTypeBusinessEngine>(new ContainerControlledLifetimeManager());
            container.RegisterType<IAttributeTypeBusinessEngine, AttributeTypeBusinessEngine>(new ContainerControlledLifetimeManager());
            container.RegisterType<IAuditLogBusinessEngine, AuditLogBusinessEngine>();
            container.RegisterType<IChartOfAccountBusinessEngine, ChartOfAccountBusinessEngine>();
            container.RegisterType<ICommentBusinessEngine, CommentBusinessEngine>();
            container.RegisterType<ICommentTypeBusinessEngine, CommentTypeBusinessEngine>(new ContainerControlledLifetimeManager());
            container.RegisterType<IContactBusinessEngine, ContactBusinessEngine>();
            container.RegisterType<ICompanyBusinessEngine, CompanyBusinessEngine>();
            container.RegisterType<IContactTypeBusinessEngine, ContactTypeBusinessEngine>(new ContainerControlledLifetimeManager());
            container.RegisterType<IAccountBusinessEngine, AccountBusinessEngine>();
            container.RegisterType<IEmployeeBusinessEngine, EmployeeBusinessEngine>();
            container.RegisterType<IEntityAttributeBusinessEngine, EntityAttributeBusinessEngine>();
            container.RegisterType<IEntityProductBusinessEngine, EntityProductBusinessEngine>();
            container.RegisterType<IEntityTypeBusinessEngine, EntityTypeBusinessEngine>();
            container.RegisterType<IFeeScheduleBusinessEngine, FeeScheduleBusinessEngine>();
            container.RegisterType<IInvoiceBusinessEngine, InvoiceBusinessEngine>();
            container.RegisterType<ILedgerBusinessEngine, LedgerBusinessEngine>();
            container.RegisterType<IOrderBusinessEngine, OrderBusinessEngine>();
            container.RegisterType<IPersonTypeBusinessEngine, PersonTypeBusinessEngine>();
            container.RegisterType<IProductBusinessEngine, ProductBusinessEngine>();
            container.RegisterType<IUserSessionBusinessEngine, UserSessionBusinessEngine>();
            container.RegisterType<IProductTypeBusinessEngine, ProductTypeBusinessEngine>();
            container.RegisterType<IOrderStatusBusinessEngine, OrderStatusBusinessEngine>(new ContainerControlledLifetimeManager());
            container.RegisterType<IOrderItemStatusBusinessEngine, OrderItemStatusBusinessEngine>(new ContainerControlledLifetimeManager());
            container.RegisterType<IIdentityUserBusinessEngine, IdentityUserBusinessEngine>();
            container.RegisterType<IIdentityRoleBusinessEngine, IdentityRoleBusinessEngine>();
        }

        private static void RegisterServices(IUnityContainer container)
        {
            container.RegisterType<IAccountService, AccountService>();
            container.RegisterType<IAddressService, AddressService>();
            container.RegisterType<IAuditService, AuditService>();
            container.RegisterType<ICompanyService, CompanyService>();
            container.RegisterType<IEmployeeService, EmployeeService>();
            container.RegisterType<IEntityProductService, EntityProductService>();
            container.RegisterType<IFeeScheduleService, FeeScheduleService>();
            container.RegisterType<IInvoiceService, InvoiceService>();
            container.RegisterType<ILedgerService, LedgerService>();
            container.RegisterType<IOrderService, OrderService>();
            container.RegisterType<IProductService, ProductService>();
            container.RegisterType<ISessionService, SessionService>();
            container.RegisterType<ITypeService, TypeService>();
            container.RegisterType<IIdentityUserService, IdentityUserService>();
            container.RegisterType<IIdentityRoleService, IdentityRoleService>();
        }

        private static void RegisterRepositories(IUnityContainer container)
        {
            container.RegisterType<IAccountRepository, AccountRepository>();
            container.RegisterType<IAccountTypeRepository, AccountTypeRepository>();
            container.RegisterType<IAddressRepository, AddressRepository>();
            container.RegisterType<IAddressPostalRepository, AddressPostalRepository>();
            container.RegisterType<IAddressTypeRepository, AddressTypeRepository>();
            container.RegisterType<IAttributeRepository, AttributeRepository>();
            container.RegisterType<IAttributeTypeRepository, AttributeTypeRepository>();
            container.RegisterType<IAuditLogRepository, AuditLogRepository>();
            container.RegisterType<IChartOfAccountsRepository, ChartOfAccountsRepository>();
            container.RegisterType<ICommentRepository, CommentRepository>();
            container.RegisterType<ICommentTypeRepository, CommentTypeRepository>();
            container.RegisterType<ICompanyRepository, CompanyRepository>();
            container.RegisterType<IContactRepository, ContactRepository>();
            container.RegisterType<IContactTypeRepository, ContactTypeRepository>();
            container.RegisterType<IEntityEntityRepository, EntityEntityRepository>();
            container.RegisterType<IEntityPersonRepository, EntityPersonRepository>();
            container.RegisterType<IEntityProductRepository, EntityProductRepository>();
            container.RegisterType<IEntityTypeRepository, EntityTypeRepository>();
            container.RegisterType<IFeeScheduleRepository, FeeScheduleRepository>();
            container.RegisterType<IInvoiceRepository, InvoiceRepository>();
            container.RegisterType<IInvoiceItemRepository, InvoiceItemRepository>();
            container.RegisterType<IInvoiceStatusRepository, InvoiceStatusRepository>();
            container.RegisterType<ILedgerRepository, LedgerRepository>();
            container.RegisterType<ILedgerTxnRepository, LedgerTxnRepository>();
            container.RegisterType<IOrderHeaderRepository, OrderHeaderRepository>();
            container.RegisterType<IOrderItemRepository, OrderItemRepository>();
            container.RegisterType<IOrderStatusRepository, OrderStatusRepository>();
            container.RegisterType<IPersonRepository, PersonRepository>();
            container.RegisterType<IPersonTypeRepository, PersonTypeRepository>();
            container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<IProductTypeRepository, ProductTypeRepository>();
            container.RegisterType<IUserSessionRepository, UserSessionRepository>();
            container.RegisterType<IVendorRepository, VendorRepository>();

            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IUserClaimRepository, UserClaimRepository>();
            container.RegisterType<IUserRoleRepository, UserRoleRepository>();
            container.RegisterType<IUserLoginRepository, UserLoginRepository>();
            container.RegisterType<IRoleRepository, RoleRepository>();
            container.RegisterType<IRoleClaimRepository, RoleClaimRepository>();
        }

        private static void RegisterFactories(IUnityContainer container)
        {
            container.RegisterType<IBusinessEngineFactory, BusinessEngineFactory>();
            container.RegisterType<IDataRepositoryFactory, DataRepositoryFactory>();
            container.RegisterType<IEntityServiceFactory, EntityServiceFactory>();
        }

        private static void RegisterMaps(IUnityContainer container)
        {
            container.RegisterType<IAccountMap, AccountMap>();
            container.RegisterType<IAccountTypeMap, AccountTypeMap>();
            container.RegisterType<IAddressMap, AddressMap>();
            container.RegisterType<IAddressPostalMap, AddressPostalMap>();
            container.RegisterType<IAddressTypeMap, AddressTypeMap>();
            container.RegisterType<IAttributeMap, AttributeMap>();
            container.RegisterType<IAttributeTypeMap, AttributeTypeMap>();
            container.RegisterType<IAuditLogMap, AuditLogMap>();
            container.RegisterType<IChartOfAccountsMap, ChartOfAccountsMap>();
            container.RegisterType<ICommentMap, CommentMap>();
            container.RegisterType<ICommentTypeMap, CommentTypeMap>();
            container.RegisterType<ICompanyMap, CompanyMap>();
            container.RegisterType<IContactMap, ContactMap>();
            container.RegisterType<IContactTypeMap, ContactTypeMap>();
            container.RegisterType<IEntityEntityMap, EntityEntityMap>();
            container.RegisterType<IEntityPersonMap, EntityPersonMap>();
            container.RegisterType<IEntityProductMap, EntityProductMap>();
            container.RegisterType<IEntityTypeMap, EntityTypeMap>();
            container.RegisterType<IFeeScheduleMap, FeeScheduleMap>();
            container.RegisterType<IInvoiceItemMap, InvoiceItemMap>();
            container.RegisterType<IInvoiceMap, InvoiceMap>();
            container.RegisterType<IInvoiceStatusMap, InvoiceStatusMap>();
            container.RegisterType<ILedgerMap, LedgerMap>();
            container.RegisterType<ILedgerTxnMap, LedgerTxnMap>();
            container.RegisterType<IOrderHeaderMap, OrderHeaderMap>();
            container.RegisterType<IOrderItemMap, OrderItemMap>();
            container.RegisterType<IOrderStatusMap, OrderStatusMap>();
            container.RegisterType<IPersonMap, PersonMap>();
            container.RegisterType<IPersonTypeMap, PersonTypeMap>();
            container.RegisterType<IProductMap, ProductMap>();
            container.RegisterType<IProductTypeMap, ProductTypeMap>();
            container.RegisterType<IUserSessionMap, UserSessionMap>();
            container.RegisterType<IVendorMap, VendorMap>();

            container.RegisterType<IUserMap, UserMapper>();
            container.RegisterType<IUserClaimMap, UserClaimMapper>();
            container.RegisterType<IUserRoleMap, UserRoleMapper>();
            container.RegisterType<IUserLoginMap, UserLoginMapper>();
            container.RegisterType<IRoleMap, RoleMapper>();
            container.RegisterType<IRoleClaimMap, RoleClaimMapper>();
        }

        private static void RegisterEntityServices(IUnityContainer container)
        {
            container.RegisterType<IAccountEntityService, AccountEntityService>();
            container.RegisterType<ICompanyEntityService, CompanyEntityService>();
            container.RegisterType<IPersonEntityService, PersonEntityService>();
            container.RegisterType<IAddressEntityService, AddressEntityService>();
            container.RegisterType<IChartOfAccountsEntityService, ChartOfAccountsEntityService>();
            container.RegisterType<ICommentEntityService, CommentEntityService>();
            container.RegisterType<IContactEntityService, ContactEntityService>();
            container.RegisterType<IEntityAttributeEntityService, EntityAttributeEntityService>();
            container.RegisterType<IEntityProductEntityService, EntityProductEntityService>();
            container.RegisterType<IFeeScheduleEntityService, FeeScheduleEntityService>();
            container.RegisterType<IInvoiceEntityService, InvoiceEntityService>();
            container.RegisterType<IOrderEntityService, OrderEntityService>();
            container.RegisterType<IProductEntityService, ProductEntityService>();
        }
    }
}
