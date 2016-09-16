using QIQO.Common.Contracts;
using QIQO.Data.Entities;
using QIQO.Data.Entities.Identity;

namespace QIQO.Data.Interfaces
{
    public interface IAccountMap : IMapper<AccountData> { }
    public interface IAccountTypeMap : IMapper<AccountTypeData> { }
    public interface IAddressMap : IMapper<AddressData> { }
    public interface IAddressPostalMap : IMapper<AddressPostalData> { }
    public interface IAddressTypeMap : IMapper<AddressTypeData> { }
    public interface IAttributeMap : IMapper<AttributeData> { }
    public interface IAttributeTypeMap : IMapper<AttributeTypeData> { }
    public interface IAuditLogMap : IMapper<AuditLogData> { }
    public interface IChartOfAccountsMap : IMapper<ChartOfAccountsData> { }
    public interface ICommentMap : IMapper<CommentData> { }
    public interface ICommentTypeMap : IMapper<CommentTypeData> { }
    public interface ICompanyMap : IMapper<CompanyData> { }
    public interface IContactMap : IMapper<ContactData> { }
    public interface IContactTypeMap : IMapper<ContactTypeData> { }
    public interface IEntityEntityMap : IMapper<EntityEntityData> { }
    public interface IEntityPersonMap : IMapper<EntityPersonData> { }
    public interface IEntityProductMap : IMapper<EntityProductData> { }
    public interface IEntityTypeMap : IMapper<EntityTypeData> { }
    public interface IFeeScheduleMap : IMapper<FeeScheduleData> { }
    public interface IInvoiceItemMap : IMapper<InvoiceItemData> { }
    public interface IInvoiceMap : IMapper<InvoiceData> { }
    public interface IInvoiceStatusMap : IMapper<InvoiceStatusData> { }
    public interface ILedgerMap : IMapper<LedgerData> { }
    public interface ILedgerTxnMap : IMapper<LedgerTxnData> { }
    public interface IOrderHeaderMap : IMapper<OrderHeaderData> { }
    public interface IOrderItemMap : IMapper<OrderItemData> { }
    public interface IOrderStatusMap : IMapper<OrderStatusData> { }
    public interface IPersonMap : IMapper<PersonData> { }
    public interface IPersonTypeMap : IMapper<PersonTypeData> { }
    public interface IProductMap : IMapper<ProductData> { }
    public interface IProductTypeMap : IMapper<ProductTypeData> { }
    public interface IUserSessionMap : IMapper<UserSessionData> { }
    public interface IVendorMap : IMapper<VendorData> { }

    public interface IUserMap : IIdentityMapper<UserData> { }
    public interface IUserClaimMap : IIdentityMapper<UserClaimData> { }
    public interface IUserRoleMap : IIdentityMapper<UserRoleData> { }
    public interface IUserLoginMap : IIdentityMapper<UserLoginData> { }
    public interface IRoleMap : IIdentityMapper<RoleData> { }
    public interface IRoleClaimMap : IIdentityMapper<RoleClaimData> { }
}
