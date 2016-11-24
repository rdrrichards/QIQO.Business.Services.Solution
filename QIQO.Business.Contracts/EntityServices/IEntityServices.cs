using QIQO.Business.Entities;
using QIQO.Common.Contracts;
using QIQO.Data.Entities;

namespace QIQO.Business.Contracts
{
    public interface IAccountEntityService : IEntityService<Account, AccountData> {
        AccountPerson Map(PersonData emp_data);
        AccountPerson Map(EntityPersonData emp_data);
    }
    public interface IAccountTypeEntityService : IEntityService<AccountType, AccountTypeData> { }
    public interface IAddressEntityService : IEntityService<Address, AddressData> { }
    public interface IAddressPostalEntityService : IEntityService<AddressPostal, AddressPostalData> { }
    public interface IAddressTypeEntityService : IEntityService<AddressType, AddressTypeData> { }
    public interface IAttributeEntityService : IEntityService<EntityAttribute, AttributeData> { }
    public interface IAttributeTypeEntityService : IEntityService<AttributeType, AttributeTypeData> { }
    public interface IAuditLogEntityService : IEntityService<AuditLog, AuditLogData> { }
    public interface IChartOfAccountEntityService : IEntityService<ChartOfAccount, ChartOfAccountsData> { }
    public interface ICommentEntityService : IEntityService<Comment, CommentData> { }
    public interface ICommentTypeEntityService : IEntityService<CommentType, CommentTypeData> { }
    public interface ICompanyEntityService : IEntityService<Company, CompanyData> { }
    public interface IContactEntityService : IEntityService<Contact, ContactData> { }
    public interface IContactTypeEntityService : IEntityService<ContactType, ContactTypeData> { }
    public interface IEntityAttributeEntityService : IEntityService<EntityAttribute, AttributeData> { }
    public interface IEntityProductEntityService : IEntityService<EntityProduct, EntityProductData> {
        EntityProduct Map(EntityProductData entity_product_data, ProductData product_data);
    }
    //public interface IEntityEntityEntityService : IEntityService<EntityEntity, EntityEntityData> { }
    //public interface IEntityPersonEntityService : IEntityService<EntityPerson, EntityPersonData> { }
    //public interface IEntityProductEntityService : IEntityService<EntityProduct, EntityProductData> { }
    public interface IEntityTypeEntityService : IEntityService<EntityType, EntityTypeData> { }
    public interface IFeeScheduleEntityService : IEntityService<FeeSchedule, FeeScheduleData> { }
    public interface IInvoiceEntityService : IEntityService<Invoice, InvoiceData> { }
    public interface IInvoiceItemEntityService : IEntityService<InvoiceItem, InvoiceItemData> { }
    public interface IInvoiceStatusEntityService : IEntityService<InvoiceStatus, InvoiceStatusData> { }
    public interface ILedgerEntityService : IEntityService<Ledger, LedgerData> { }
    public interface ILedgerTxnEntityService : IEntityService<LedgerTxn, LedgerTxnData> { }
    public interface IOrderEntityService : IEntityService<Order, OrderHeaderData> { }
    public interface IOrderItemEntityService : IEntityService<OrderItem, OrderItemData> { }
    public interface IOrderStatusEntityService : IEntityService<OrderStatus, OrderStatusData> { }
    public interface IOrderItemStatusEntityService : IEntityService<OrderItemStatus, OrderStatusData> { }
    //public interface IPersonEntityService : IEntityService<PersonBase, PersonData> { }
    //public interface IPersonTypeEntityService : IEntityService<PersonType, PersonTypeData> { }
    public interface IProductEntityService : IEntityService<Product, ProductData> { }
    public interface IProductTypeEntityService : IEntityService<ProductType, ProductTypeData> { }
    public interface IVendorEntityService : IEntityService<Vendor, VendorData> { }
} // namespace closer
