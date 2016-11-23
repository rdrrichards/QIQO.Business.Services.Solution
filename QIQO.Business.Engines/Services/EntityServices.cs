//using QIQO.Business.Contracts;
//using QIQO.Business.Entities;
//using QIQO.Data.Entities;

//namespace QIQO.Business.Engines
//{
//    public class AccountEntityService : IAccountEntityService, IEntityService<Account, AccountData>
//    {
//        public Account Map(AccountData account_data)
//        {
//            return new Account()
//            {
//                AccountKey = account_data.AccountKey,
//                CompanyKey = account_data.CompanyKey,
//                AccountTypeKey = account_data.AccountTypeKey,
//                AccountCode = account_data.AccountCode,
//                AccountName = account_data.AccountName,
//                AccountDesc = account_data.AccountDesc,
//                AccountDba = account_data.AccountDba,
//                AccountStartDate = account_data.AccountStartDate,
//                AccountEndDate = account_data.AccountEndDate,
//                AuditAddUserId = account_data.AuditAddUserId,
//                AuditAddDatetime = account_data.AuditAddDatetime,
//                AuditUpdateUserId = account_data.AuditUpdateUserId,
//                AuditUpdateDatetime = account_data.AuditUpdateDatetime,
//            };
//        }

//        public AccountData Map(Account account)
//        {
//            return new AccountData()
//            {
//                AccountKey = account.AccountKey,
//                CompanyKey = account.CompanyKey,
//                AccountTypeKey = account.AccountTypeKey,
//                AccountCode = account.AccountCode,
//                AccountName = account.AccountName,
//                AccountDesc = account.AccountDesc,
//                AccountDba = account.AccountDba,
//                AccountStartDate = account.AccountStartDate,
//                AccountEndDate = account.AccountEndDate,
//                AuditAddUserId = account.AuditAddUserId,
//                AuditAddDatetime = account.AuditAddDatetime,
//                AuditUpdateUserId = account.AuditUpdateUserId,
//                AuditUpdateDatetime = account.AuditUpdateDatetime,
//            };
//        }
//    }

//    public class AccountTypeEntityService : IAccountTypeEntityService, IEntityService<AccountType, AccountTypeData>
//    {
//        public AccountType Map(AccountTypeData account_type_data)
//        {
//            return new AccountType()
//            {
//                AccountKey = account_type_data.AccountKey,
//                CompanyKey = account_type_data.CompanyKey,
//                AccountTypeKey = account_type_data.AccountTypeKey,
//                AccountCode = account_type_data.AccountCode,
//                AccountName = account_type_data.AccountName,
//                AccountDesc = account_type_data.AccountDesc,
//                AccountDba = account_type_data.AccountDba,
//                AccountStartDate = account_type_data.AccountStartDate,
//                AccountEndDate = account_type_data.AccountEndDate,
//                AuditAddUserId = account_type_data.AuditAddUserId,
//                AuditAddDatetime = account_type_data.AuditAddDatetime,
//                AuditUpdateUserId = account_type_data.AuditUpdateUserId,
//                AuditUpdateDatetime = account_type_data.AuditUpdateDatetime,
//            };
//        }

//        public AccountTypeData Map(AccountType account_type)
//        {
//            return new AccountTypeData()
//            {
//                AccountTypeKey = account_type.AccountTypeKey,
//                AccountTypeCode = account_type.AccountTypeCode,
//                AccountTypeName = account_type.AccountTypeName,
//                AccountTypeDesc = account_type.AccountTypeDesc,
//                AuditAddUserId = account_type.AuditAddUserId,
//                AuditAddDatetime = account_type.AuditAddDatetime,
//                AuditUpdateUserId = account_type.AuditUpdateUserId,
//                AuditUpdateDatetime = account_type.AuditUpdateDatetime,
//            };
//        }
//    }

//    public class AddressEntityService : IAddressEntityService, IEntityService<Address, AddressData>
//    {
//        public Address Map(AddressData address_data)
//        {
//            return new Address()
//            {
//                AccountKey = address_data.AccountKey,
//                CompanyKey = address_data.CompanyKey,
//                AccountTypeKey = address_data.AccountTypeKey,
//                AccountCode = address_data.AccountCode,
//                AccountName = address_data.AccountName,
//                AccountDesc = address_data.AccountDesc,
//                AccountDba = address_data.AccountDba,
//                AccountStartDate = address_data.AccountStartDate,
//                AccountEndDate = address_data.AccountEndDate,
//                AuditAddUserId = address_data.AuditAddUserId,
//                AuditAddDatetime = address_data.AuditAddDatetime,
//                AuditUpdateUserId = address_data.AuditUpdateUserId,
//                AuditUpdateDatetime = address_data.AuditUpdateDatetime,
//            };
//        }

//        public AddressData Map(Address address)
//        {
//            return new AddressData()
//            {
//                AddressKey = address.AddressKey,
//                AddressTypeKey = address.AddressTypeKey,
//                EntityKey = address.EntityKey,
//                EntityTypeKey = address.EntityTypeKey,
//                AddressLine1 = address.AddressLine1,
//                AddressLine2 = address.AddressLine2,
//                AddressLine3 = address.AddressLine3,
//                AddressLine4 = address.AddressLine4,
//                AddressCity = address.AddressCity,
//                AddressStateProv = address.AddressStateProv,
//                AddressCounty = address.AddressCounty,
//                AddressCountry = address.AddressCountry,
//                AddressPostalCode = address.AddressPostalCode,
//                AddressNotes = address.AddressNotes,
//                AddressDefaultFlg = address.AddressDefaultFlg,
//                AddressActiveFlg = address.AddressActiveFlg,
//                AuditAddUserId = address.AuditAddUserId,
//                AuditAddDatetime = address.AuditAddDatetime,
//                AuditUpdateUserId = address.AuditUpdateUserId,
//                AuditUpdateDatetime = address.AuditUpdateDatetime,
//            };
//        }
//    }

//    public class AddressPostalEntityService : IAddressPostalEntityService, IEntityService<AddressPostal, AddressPostalData>
//    {
//        public AddressPostal Map(AddressPostalData address_postal_data)
//        {
//            return new AddressPostal()
//            {
//                AccountKey = address_postal_data.AccountKey,
//                CompanyKey = address_postal_data.CompanyKey,
//                AccountTypeKey = address_postal_data.AccountTypeKey,
//                AccountCode = address_postal_data.AccountCode,
//                AccountName = address_postal_data.AccountName,
//                AccountDesc = address_postal_data.AccountDesc,
//                AccountDba = address_postal_data.AccountDba,
//                AccountStartDate = address_postal_data.AccountStartDate,
//                AccountEndDate = address_postal_data.AccountEndDate,
//                AuditAddUserId = address_postal_data.AuditAddUserId,
//                AuditAddDatetime = address_postal_data.AuditAddDatetime,
//                AuditUpdateUserId = address_postal_data.AuditUpdateUserId,
//                AuditUpdateDatetime = address_postal_data.AuditUpdateDatetime,
//            };
//        }

//        public AddressPostalData Map(AddressPostal address_postal)
//        {
//            return new AddressPostalData()
//            {
//                Country = address_postal.Country,
//                PostalCode = address_postal.PostalCode,
//                StateCode = address_postal.StateCode,
//                StateFullName = address_postal.StateFullName,
//                CityName = address_postal.CityName,
//                CountyName = address_postal.CountyName,
//                TimeZone = address_postal.TimeZone,
//            };
//        }
//    }

//    public class AddressTypeEntityService : IAddressTypeEntityService, IEntityService<AddressType, AddressTypeData>
//    {
//        public AddressType Map(AddressTypeData address_type_data)
//        {
//            return new AddressType()
//            {
//                AccountKey = address_type_data.AccountKey,
//                CompanyKey = address_type_data.CompanyKey,
//                AccountTypeKey = address_type_data.AccountTypeKey,
//                AccountCode = address_type_data.AccountCode,
//                AccountName = address_type_data.AccountName,
//                AccountDesc = address_type_data.AccountDesc,
//                AccountDba = address_type_data.AccountDba,
//                AccountStartDate = address_type_data.AccountStartDate,
//                AccountEndDate = address_type_data.AccountEndDate,
//                AuditAddUserId = address_type_data.AuditAddUserId,
//                AuditAddDatetime = address_type_data.AuditAddDatetime,
//                AuditUpdateUserId = address_type_data.AuditUpdateUserId,
//                AuditUpdateDatetime = address_type_data.AuditUpdateDatetime,
//            };
//        }

//        public AddressTypeData Map(AddressType address_type)
//        {
//            return new AddressTypeData()
//            {
//                AddressTypeKey = address_type.AddressTypeKey,
//                AddressTypeCode = address_type.AddressTypeCode,
//                AddressTypeName = address_type.AddressTypeName,
//                AddressTypeDesc = address_type.AddressTypeDesc,
//                AuditAddUserId = address_type.AuditAddUserId,
//                AuditAddDatetime = address_type.AuditAddDatetime,
//                AuditUpdateUserId = address_type.AuditUpdateUserId,
//                AuditUpdateDatetime = address_type.AuditUpdateDatetime,
//            };
//        }
//    }

//    public class AttributeEntityService : IAttributeEntityService, IEntityService<Attribute, AttributeData>
//    {
//        public Attribute Map(AttributeData attribute_data)
//        {
//            return new Attribute()
//            {
//                AccountKey = attribute_data.AccountKey,
//                CompanyKey = attribute_data.CompanyKey,
//                AccountTypeKey = attribute_data.AccountTypeKey,
//                AccountCode = attribute_data.AccountCode,
//                AccountName = attribute_data.AccountName,
//                AccountDesc = attribute_data.AccountDesc,
//                AccountDba = attribute_data.AccountDba,
//                AccountStartDate = attribute_data.AccountStartDate,
//                AccountEndDate = attribute_data.AccountEndDate,
//                AuditAddUserId = attribute_data.AuditAddUserId,
//                AuditAddDatetime = attribute_data.AuditAddDatetime,
//                AuditUpdateUserId = attribute_data.AuditUpdateUserId,
//                AuditUpdateDatetime = attribute_data.AuditUpdateDatetime,
//            };
//        }

//        public AttributeData Map(Attribute attribute)
//        {
//            return new AttributeData()
//            {
//                AttributeKey = attribute.AttributeKey,
//                EntityKey = attribute.EntityKey,
//                EntityTypeKey = attribute.EntityTypeKey,
//                AttributeTypeKey = attribute.AttributeTypeKey,
//                AttributeValue = attribute.AttributeValue,
//                AttributeDataTypeKey = attribute.AttributeDataTypeKey,
//                AttributeDisplayFormat = attribute.AttributeDisplayFormat,
//                AuditAddUserId = attribute.AuditAddUserId,
//                AuditAddDatetime = attribute.AuditAddDatetime,
//                AuditUpdateUserId = attribute.AuditUpdateUserId,
//                AuditUpdateDatetime = attribute.AuditUpdateDatetime,
//            };
//        }
//    }

//    public class AttributeTypeEntityService : IAttributeTypeEntityService, IEntityService<AttributeType, AttributeTypeData>
//    {
//        public AttributeType Map(AttributeTypeData attribute_type_data)
//        {
//            return new AttributeType()
//            {
//                AccountKey = attribute_type_data.AccountKey,
//                CompanyKey = attribute_type_data.CompanyKey,
//                AccountTypeKey = attribute_type_data.AccountTypeKey,
//                AccountCode = attribute_type_data.AccountCode,
//                AccountName = attribute_type_data.AccountName,
//                AccountDesc = attribute_type_data.AccountDesc,
//                AccountDba = attribute_type_data.AccountDba,
//                AccountStartDate = attribute_type_data.AccountStartDate,
//                AccountEndDate = attribute_type_data.AccountEndDate,
//                AuditAddUserId = attribute_type_data.AuditAddUserId,
//                AuditAddDatetime = attribute_type_data.AuditAddDatetime,
//                AuditUpdateUserId = attribute_type_data.AuditUpdateUserId,
//                AuditUpdateDatetime = attribute_type_data.AuditUpdateDatetime,
//            };
//        }

//        public AttributeTypeData Map(AttributeType attribute_type)
//        {
//            return new AttributeTypeData()
//            {
//                AttributeTypeKey = attribute_type.AttributeTypeKey,
//                AttributeTypeCategory = attribute_type.AttributeTypeCategory,
//                AttributeTypeCode = attribute_type.AttributeTypeCode,
//                AttributeTypeName = attribute_type.AttributeTypeName,
//                AttributeTypeDesc = attribute_type.AttributeTypeDesc,
//                AttributeDataTypeKey = attribute_type.AttributeDataTypeKey,
//                AttributeDefaultFormat = attribute_type.AttributeDefaultFormat,
//                AuditAddUserId = attribute_type.AuditAddUserId,
//                AuditAddDatetime = attribute_type.AuditAddDatetime,
//                AuditUpdateUserId = attribute_type.AuditUpdateUserId,
//                AuditUpdateDatetime = attribute_type.AuditUpdateDatetime,
//            };
//        }
//    }

//    public class AuditLogEntityService : IAuditLogEntityService, IEntityService<AuditLog, AuditLogData>
//    {
//        public AuditLog Map(AuditLogData audit_log_data)
//        {
//            return new AuditLog()
//            {
//                AccountKey = audit_log_data.AccountKey,
//                CompanyKey = audit_log_data.CompanyKey,
//                AccountTypeKey = audit_log_data.AccountTypeKey,
//                AccountCode = audit_log_data.AccountCode,
//                AccountName = audit_log_data.AccountName,
//                AccountDesc = audit_log_data.AccountDesc,
//                AccountDba = audit_log_data.AccountDba,
//                AccountStartDate = audit_log_data.AccountStartDate,
//                AccountEndDate = audit_log_data.AccountEndDate,
//                AuditAddUserId = audit_log_data.AuditAddUserId,
//                AuditAddDatetime = audit_log_data.AuditAddDatetime,
//                AuditUpdateUserId = audit_log_data.AuditUpdateUserId,
//                AuditUpdateDatetime = audit_log_data.AuditUpdateDatetime,
//            };
//        }

//        public AuditLogData Map(AuditLog audit_log)
//        {
//            return new AuditLogData()
//            {
//                AuditLogKey = audit_log.AuditLogKey,
//                AuditAction = audit_log.AuditAction,
//                AuditBusObj = audit_log.AuditBusObj,
//                AuditDatetime = audit_log.AuditDatetime,
//                AuditUserId = audit_log.AuditUserId,
//                AuditAppName = audit_log.AuditAppName,
//                AuditHostName = audit_log.AuditHostName,
//                AuditComment = audit_log.AuditComment,
//                AuditDataOld = audit_log.AuditDataOld,
//                AuditDataNew = audit_log.AuditDataNew,
//                AuditAddUserId = audit_log.AuditAddUserId,
//                AuditAddDatetime = audit_log.AuditAddDatetime,
//                AuditUpdateUserId = audit_log.AuditUpdateUserId,
//                AuditUpdateDatetime = audit_log.AuditUpdateDatetime,
//            };
//        }
//    }

//    public class ChartOfAccountsEntityService : IChartOfAccountsEntityService, IEntityService<ChartOfAccounts, ChartOfAccountsData>
//    {
//        public ChartOfAccounts Map(ChartOfAccountsData chart_of_accounts_data)
//        {
//            return new ChartOfAccounts()
//            {
//                AccountKey = chart_of_accounts_data.AccountKey,
//                CompanyKey = chart_of_accounts_data.CompanyKey,
//                AccountTypeKey = chart_of_accounts_data.AccountTypeKey,
//                AccountCode = chart_of_accounts_data.AccountCode,
//                AccountName = chart_of_accounts_data.AccountName,
//                AccountDesc = chart_of_accounts_data.AccountDesc,
//                AccountDba = chart_of_accounts_data.AccountDba,
//                AccountStartDate = chart_of_accounts_data.AccountStartDate,
//                AccountEndDate = chart_of_accounts_data.AccountEndDate,
//                AuditAddUserId = chart_of_accounts_data.AuditAddUserId,
//                AuditAddDatetime = chart_of_accounts_data.AuditAddDatetime,
//                AuditUpdateUserId = chart_of_accounts_data.AuditUpdateUserId,
//                AuditUpdateDatetime = chart_of_accounts_data.AuditUpdateDatetime,
//            };
//        }

//        public ChartOfAccountsData Map(ChartOfAccounts chart_of_accounts)
//        {
//            return new ChartOfAccountsData()
//            {
//                CoaKey = chart_of_accounts.CoaKey,
//                CompanyKey = chart_of_accounts.CompanyKey,
//                AcctNo = chart_of_accounts.AcctNo,
//                AcctType = chart_of_accounts.AcctType,
//                DepartmentNo = chart_of_accounts.DepartmentNo,
//                LobNo = chart_of_accounts.LobNo,
//                AcctName = chart_of_accounts.AcctName,
//                BalanceType = chart_of_accounts.BalanceType,
//                BankAcctFlg = chart_of_accounts.BankAcctFlg,
//                Report = chart_of_accounts.Report,
//                AuditAddUserId = chart_of_accounts.AuditAddUserId,
//                AuditAddDatetime = chart_of_accounts.AuditAddDatetime,
//                AuditUpdateUserId = chart_of_accounts.AuditUpdateUserId,
//                AuditUpdateDatetime = chart_of_accounts.AuditUpdateDatetime,
//            };
//        }
//    }

//    public class CommentEntityService : ICommentEntityService, IEntityService<Comment, CommentData>
//    {
//        public Comment Map(CommentData comment_data)
//        {
//            return new Comment()
//            {
//                AccountKey = comment_data.AccountKey,
//                CompanyKey = comment_data.CompanyKey,
//                AccountTypeKey = comment_data.AccountTypeKey,
//                AccountCode = comment_data.AccountCode,
//                AccountName = comment_data.AccountName,
//                AccountDesc = comment_data.AccountDesc,
//                AccountDba = comment_data.AccountDba,
//                AccountStartDate = comment_data.AccountStartDate,
//                AccountEndDate = comment_data.AccountEndDate,
//                AuditAddUserId = comment_data.AuditAddUserId,
//                AuditAddDatetime = comment_data.AuditAddDatetime,
//                AuditUpdateUserId = comment_data.AuditUpdateUserId,
//                AuditUpdateDatetime = comment_data.AuditUpdateDatetime,
//            };
//        }

//        public CommentData Map(Comment comment)
//        {
//            return new CommentData()
//            {
//                CommentKey = comment.CommentKey,
//                EntityKey = comment.EntityKey,
//                EntityType = comment.EntityType,
//                CommentTypeKey = comment.CommentTypeKey,
//                CommentValue = comment.CommentValue,
//                AuditAddUserId = comment.AuditAddUserId,
//                AuditAddDatetime = comment.AuditAddDatetime,
//                AuditUpdateUserId = comment.AuditUpdateUserId,
//                AuditUpdateDatetime = comment.AuditUpdateDatetime,
//            };
//        }
//    }

//    public class CommentTypeEntityService : ICommentTypeEntityService, IEntityService<CommentType, CommentTypeData>
//    {
//        public CommentType Map(CommentTypeData comment_type_data)
//        {
//            return new CommentType()
//            {
//                AccountKey = comment_type_data.AccountKey,
//                CompanyKey = comment_type_data.CompanyKey,
//                AccountTypeKey = comment_type_data.AccountTypeKey,
//                AccountCode = comment_type_data.AccountCode,
//                AccountName = comment_type_data.AccountName,
//                AccountDesc = comment_type_data.AccountDesc,
//                AccountDba = comment_type_data.AccountDba,
//                AccountStartDate = comment_type_data.AccountStartDate,
//                AccountEndDate = comment_type_data.AccountEndDate,
//                AuditAddUserId = comment_type_data.AuditAddUserId,
//                AuditAddDatetime = comment_type_data.AuditAddDatetime,
//                AuditUpdateUserId = comment_type_data.AuditUpdateUserId,
//                AuditUpdateDatetime = comment_type_data.AuditUpdateDatetime,
//            };
//        }

//        public CommentTypeData Map(CommentType comment_type)
//        {
//            return new CommentTypeData()
//            {
//                CommentTypeKey = comment_type.CommentTypeKey,
//                CommentTypeCategory = comment_type.CommentTypeCategory,
//                CommentTypeCode = comment_type.CommentTypeCode,
//                CommentTypeName = comment_type.CommentTypeName,
//                CommentTypeDesc = comment_type.CommentTypeDesc,
//                AuditAddUserId = comment_type.AuditAddUserId,
//                AuditAddDatetime = comment_type.AuditAddDatetime,
//                AuditUpdateUserId = comment_type.AuditUpdateUserId,
//                AuditUpdateDatetime = comment_type.AuditUpdateDatetime,
//            };
//        }
//    }

//    public class CompanyEntityService : ICompanyEntityService, IEntityService<Company, CompanyData>
//    {
//        public Company Map(CompanyData company_data)
//        {
//            return new Company()
//            {
//                AccountKey = company_data.AccountKey,
//                CompanyKey = company_data.CompanyKey,
//                AccountTypeKey = company_data.AccountTypeKey,
//                AccountCode = company_data.AccountCode,
//                AccountName = company_data.AccountName,
//                AccountDesc = company_data.AccountDesc,
//                AccountDba = company_data.AccountDba,
//                AccountStartDate = company_data.AccountStartDate,
//                AccountEndDate = company_data.AccountEndDate,
//                AuditAddUserId = company_data.AuditAddUserId,
//                AuditAddDatetime = company_data.AuditAddDatetime,
//                AuditUpdateUserId = company_data.AuditUpdateUserId,
//                AuditUpdateDatetime = company_data.AuditUpdateDatetime,
//            };
//        }

//        public CompanyData Map(Company company)
//        {
//            return new CompanyData()
//            {
//                CompanyKey = company.CompanyKey,
//                CompanyCode = company.CompanyCode,
//                CompanyName = company.CompanyName,
//                CompanyDesc = company.CompanyDesc,
//                AuditAddUserId = company.AuditAddUserId,
//                AuditAddDatetime = company.AuditAddDatetime,
//                AuditUpdateUserId = company.AuditUpdateUserId,
//                AuditUpdateDatetime = company.AuditUpdateDatetime,
//            };
//        }
//    }

//    public class ContactEntityService : IContactEntityService, IEntityService<Contact, ContactData>
//    {
//        public Contact Map(ContactData contact_data)
//        {
//            return new Contact()
//            {
//                AccountKey = contact_data.AccountKey,
//                CompanyKey = contact_data.CompanyKey,
//                AccountTypeKey = contact_data.AccountTypeKey,
//                AccountCode = contact_data.AccountCode,
//                AccountName = contact_data.AccountName,
//                AccountDesc = contact_data.AccountDesc,
//                AccountDba = contact_data.AccountDba,
//                AccountStartDate = contact_data.AccountStartDate,
//                AccountEndDate = contact_data.AccountEndDate,
//                AuditAddUserId = contact_data.AuditAddUserId,
//                AuditAddDatetime = contact_data.AuditAddDatetime,
//                AuditUpdateUserId = contact_data.AuditUpdateUserId,
//                AuditUpdateDatetime = contact_data.AuditUpdateDatetime,
//            };
//        }

//        public ContactData Map(Contact contact)
//        {
//            return new ContactData()
//            {
//                ContactKey = contact.ContactKey,
//                EntityKey = contact.EntityKey,
//                EntityTypeKey = contact.EntityTypeKey,
//                ContactTypeKey = contact.ContactTypeKey,
//                ContactValue = contact.ContactValue,
//                ContactDefaultFlg = contact.ContactDefaultFlg,
//                ContactActiveFlg = contact.ContactActiveFlg,
//                AuditAddUserId = contact.AuditAddUserId,
//                AuditAddDatetime = contact.AuditAddDatetime,
//                AuditUpdateUserId = contact.AuditUpdateUserId,
//                AuditUpdateDatetime = contact.AuditUpdateDatetime,
//            };
//        }
//    }

//    public class ContactTypeEntityService : IContactTypeEntityService, IEntityService<ContactType, ContactTypeData>
//    {
//        public ContactType Map(ContactTypeData contact_type_data)
//        {
//            return new ContactType()
//            {
//                AccountKey = contact_type_data.AccountKey,
//                CompanyKey = contact_type_data.CompanyKey,
//                AccountTypeKey = contact_type_data.AccountTypeKey,
//                AccountCode = contact_type_data.AccountCode,
//                AccountName = contact_type_data.AccountName,
//                AccountDesc = contact_type_data.AccountDesc,
//                AccountDba = contact_type_data.AccountDba,
//                AccountStartDate = contact_type_data.AccountStartDate,
//                AccountEndDate = contact_type_data.AccountEndDate,
//                AuditAddUserId = contact_type_data.AuditAddUserId,
//                AuditAddDatetime = contact_type_data.AuditAddDatetime,
//                AuditUpdateUserId = contact_type_data.AuditUpdateUserId,
//                AuditUpdateDatetime = contact_type_data.AuditUpdateDatetime,
//            };
//        }

//        public ContactTypeData Map(ContactType contact_type)
//        {
//            return new ContactTypeData()
//            {
//                ContactTypeKey = contact_type.ContactTypeKey,
//                ContactTypeCategory = contact_type.ContactTypeCategory,
//                ContactTypeCode = contact_type.ContactTypeCode,
//                ContactTypeName = contact_type.ContactTypeName,
//                ContactTypeDesc = contact_type.ContactTypeDesc,
//                AuditAddUserId = contact_type.AuditAddUserId,
//                AuditAddDatetime = contact_type.AuditAddDatetime,
//                AuditUpdateUserId = contact_type.AuditUpdateUserId,
//                AuditUpdateDatetime = contact_type.AuditUpdateDatetime,
//            };
//        }
//    }

//    public class EntityPersonEntityService : IEntityPersonEntityService, IEntityService<EntityPerson, EntityPersonData>
//    {
//        public EntityPerson Map(EntityPersonData entity_person_data)
//        {
//            return new EntityPerson()
//            {
//                AccountKey = entity_person_data.AccountKey,
//                CompanyKey = entity_person_data.CompanyKey,
//                AccountTypeKey = entity_person_data.AccountTypeKey,
//                AccountCode = entity_person_data.AccountCode,
//                AccountName = entity_person_data.AccountName,
//                AccountDesc = entity_person_data.AccountDesc,
//                AccountDba = entity_person_data.AccountDba,
//                AccountStartDate = entity_person_data.AccountStartDate,
//                AccountEndDate = entity_person_data.AccountEndDate,
//                AuditAddUserId = entity_person_data.AuditAddUserId,
//                AuditAddDatetime = entity_person_data.AuditAddDatetime,
//                AuditUpdateUserId = entity_person_data.AuditUpdateUserId,
//                AuditUpdateDatetime = entity_person_data.AuditUpdateDatetime,
//            };
//        }

//        public EntityPersonData Map(EntityPerson entity_person)
//        {
//            return new EntityPersonData()
//            {
//                EntityPersonKey = entity_person.EntityPersonKey,
//                PersonKey = entity_person.PersonKey,
//                PersonTypeKey = entity_person.PersonTypeKey,
//                EntityPersonSeq = entity_person.EntityPersonSeq,
//                PersonRole = entity_person.PersonRole,
//                EntityKey = entity_person.EntityKey,
//                EntityTypeKey = entity_person.EntityTypeKey,
//                Comment = entity_person.Comment,
//                StartDate = entity_person.StartDate,
//                EndDate = entity_person.EndDate,
//                AuditAddUserId = entity_person.AuditAddUserId,
//                AuditAddDatetime = entity_person.AuditAddDatetime,
//                AuditUpdateUserId = entity_person.AuditUpdateUserId,
//                AuditUpdateDatetime = entity_person.AuditUpdateDatetime,
//            };
//        }
//    }

//    public class EntityTypeEntityService : IEntityTypeEntityService, IEntityService<EntityType, EntityTypeData>
//    {
//        public EntityType Map(EntityTypeData entity_type_data)
//        {
//            return new EntityType()
//            {
//                AccountKey = entity_type_data.AccountKey,
//                CompanyKey = entity_type_data.CompanyKey,
//                AccountTypeKey = entity_type_data.AccountTypeKey,
//                AccountCode = entity_type_data.AccountCode,
//                AccountName = entity_type_data.AccountName,
//                AccountDesc = entity_type_data.AccountDesc,
//                AccountDba = entity_type_data.AccountDba,
//                AccountStartDate = entity_type_data.AccountStartDate,
//                AccountEndDate = entity_type_data.AccountEndDate,
//                AuditAddUserId = entity_type_data.AuditAddUserId,
//                AuditAddDatetime = entity_type_data.AuditAddDatetime,
//                AuditUpdateUserId = entity_type_data.AuditUpdateUserId,
//                AuditUpdateDatetime = entity_type_data.AuditUpdateDatetime,
//            };
//        }

//        public EntityTypeData Map(EntityType entity_type)
//        {
//            return new EntityTypeData()
//            {
//                EntityTypeKey = entity_type.EntityTypeKey,
//                EntityTypeCode = entity_type.EntityTypeCode,
//                EntityTypeName = entity_type.EntityTypeName,
//                AuditAddUserId = entity_type.AuditAddUserId,
//                AuditAddDatetime = entity_type.AuditAddDatetime,
//                AuditUpdateUserId = entity_type.AuditUpdateUserId,
//                AuditUpdateDatetime = entity_type.AuditUpdateDatetime,
//            };
//        }
//    }

//    public class FeeScheduleEntityService : IFeeScheduleEntityService, IEntityService<FeeSchedule, FeeScheduleData>
//    {
//        public FeeSchedule Map(FeeScheduleData fee_schedule_data)
//        {
//            return new FeeSchedule()
//            {
//                AccountKey = fee_schedule_data.AccountKey,
//                CompanyKey = fee_schedule_data.CompanyKey,
//                AccountTypeKey = fee_schedule_data.AccountTypeKey,
//                AccountCode = fee_schedule_data.AccountCode,
//                AccountName = fee_schedule_data.AccountName,
//                AccountDesc = fee_schedule_data.AccountDesc,
//                AccountDba = fee_schedule_data.AccountDba,
//                AccountStartDate = fee_schedule_data.AccountStartDate,
//                AccountEndDate = fee_schedule_data.AccountEndDate,
//                AuditAddUserId = fee_schedule_data.AuditAddUserId,
//                AuditAddDatetime = fee_schedule_data.AuditAddDatetime,
//                AuditUpdateUserId = fee_schedule_data.AuditUpdateUserId,
//                AuditUpdateDatetime = fee_schedule_data.AuditUpdateDatetime,
//            };
//        }

//        public FeeScheduleData Map(FeeSchedule fee_schedule)
//        {
//            return new FeeScheduleData()
//            {
//                FeeScheduleKey = fee_schedule.FeeScheduleKey,
//                CompanyKey = fee_schedule.CompanyKey,
//                AccountKey = fee_schedule.AccountKey,
//                ProductKey = fee_schedule.ProductKey,
//                FeeScheduleStartDate = fee_schedule.FeeScheduleStartDate,
//                FeeScheduleEndDate = fee_schedule.FeeScheduleEndDate,
//                FeeScheduleType = fee_schedule.FeeScheduleType,
//                FeeScheduleValue = fee_schedule.FeeScheduleValue,
//                AuditAddUserId = fee_schedule.AuditAddUserId,
//                AuditAddDatetime = fee_schedule.AuditAddDatetime,
//                AuditUpdateUserId = fee_schedule.AuditUpdateUserId,
//                AuditUpdateDatetime = fee_schedule.AuditUpdateDatetime,
//            };
//        }
//    }

//    public class InvoiceEntityService : IInvoiceEntityService, IEntityService<Invoice, InvoiceData>
//    {
//        public Invoice Map(InvoiceData invoice_data)
//        {
//            return new Invoice()
//            {
//                AccountKey = invoice_data.AccountKey,
//                CompanyKey = invoice_data.CompanyKey,
//                AccountTypeKey = invoice_data.AccountTypeKey,
//                AccountCode = invoice_data.AccountCode,
//                AccountName = invoice_data.AccountName,
//                AccountDesc = invoice_data.AccountDesc,
//                AccountDba = invoice_data.AccountDba,
//                AccountStartDate = invoice_data.AccountStartDate,
//                AccountEndDate = invoice_data.AccountEndDate,
//                AuditAddUserId = invoice_data.AuditAddUserId,
//                AuditAddDatetime = invoice_data.AuditAddDatetime,
//                AuditUpdateUserId = invoice_data.AuditUpdateUserId,
//                AuditUpdateDatetime = invoice_data.AuditUpdateDatetime,
//            };
//        }

//        public InvoiceData Map(Invoice invoice)
//        {
//            return new InvoiceData()
//            {
//                InvoiceKey = invoice.InvoiceKey,
//                FromEntityKey = invoice.FromEntityKey,
//                AccountKey = invoice.AccountKey,
//                AccountContactKey = invoice.AccountContactKey,
//                InvoiceNum = invoice.InvoiceNum,
//                InvoiceEntryDate = invoice.InvoiceEntryDate,
//                OrderEntryDate = invoice.OrderEntryDate,
//                InvoiceStatusKey = invoice.InvoiceStatusKey,
//                InvoiceStatusDate = invoice.InvoiceStatusDate,
//                OrderShipDate = invoice.OrderShipDate,
//                AccountRepKey = invoice.AccountRepKey,
//                SalesRepKey = invoice.SalesRepKey,
//                InvoiceCompleteDate = invoice.InvoiceCompleteDate,
//                InvoiceValueSum = invoice.InvoiceValueSum,
//                InvoiceItemCount = invoice.InvoiceItemCount,
//                AuditAddUserId = invoice.AuditAddUserId,
//                AuditAddDatetime = invoice.AuditAddDatetime,
//                AuditUpdateUserId = invoice.AuditUpdateUserId,
//                AuditUpdateDatetime = invoice.AuditUpdateDatetime,
//            };
//        }
//    }

//    public class InvoiceItemEntityService : IInvoiceItemEntityService, IEntityService<InvoiceItem, InvoiceItemData>
//    {
//        public InvoiceItem Map(InvoiceItemData invoice_item_data)
//        {
//            return new InvoiceItem()
//            {
//                AccountKey = invoice_item_data.AccountKey,
//                CompanyKey = invoice_item_data.CompanyKey,
//                AccountTypeKey = invoice_item_data.AccountTypeKey,
//                AccountCode = invoice_item_data.AccountCode,
//                AccountName = invoice_item_data.AccountName,
//                AccountDesc = invoice_item_data.AccountDesc,
//                AccountDba = invoice_item_data.AccountDba,
//                AccountStartDate = invoice_item_data.AccountStartDate,
//                AccountEndDate = invoice_item_data.AccountEndDate,
//                AuditAddUserId = invoice_item_data.AuditAddUserId,
//                AuditAddDatetime = invoice_item_data.AuditAddDatetime,
//                AuditUpdateUserId = invoice_item_data.AuditUpdateUserId,
//                AuditUpdateDatetime = invoice_item_data.AuditUpdateDatetime,
//            };
//        }

//        public InvoiceItemData Map(InvoiceItem invoice_item)
//        {
//            return new InvoiceItemData()
//            {
//                InvoiceItemKey = invoice_item.InvoiceItemKey,
//                InvoiceKey = invoice_item.InvoiceKey,
//                InvoiceItemSeq = invoice_item.InvoiceItemSeq,
//                ProductKey = invoice_item.ProductKey,
//                ProductName = invoice_item.ProductName,
//                ProductDesc = invoice_item.ProductDesc,
//                InvoiceItemQuantity = invoice_item.InvoiceItemQuantity,
//                ShiptoAddrKey = invoice_item.ShiptoAddrKey,
//                BilltoAddrKey = invoice_item.BilltoAddrKey,
//                InvoiceItemEntryDate = invoice_item.InvoiceItemEntryDate,
//                OrderItemShipDate = invoice_item.OrderItemShipDate,
//                InvoiceItemCompleteDate = invoice_item.InvoiceItemCompleteDate,
//                InvoiceItemPricePer = invoice_item.InvoiceItemPricePer,
//                InvoiceItemLineSum = invoice_item.InvoiceItemLineSum,
//                InvoiceItemAccountRepKey = invoice_item.InvoiceItemAccountRepKey,
//                InvoiceItemSalesRepKey = invoice_item.InvoiceItemSalesRepKey,
//                InvoiceItemStatusKey = invoice_item.InvoiceItemStatusKey,
//                OrderItemKey = invoice_item.OrderItemKey,
//                AuditAddUserId = invoice_item.AuditAddUserId,
//                AuditAddDatetime = invoice_item.AuditAddDatetime,
//                AuditUpdateUserId = invoice_item.AuditUpdateUserId,
//                AuditUpdateDatetime = invoice_item.AuditUpdateDatetime,
//            };
//        }
//    }

//    public class InvoiceStatusEntityService : IInvoiceStatusEntityService, IEntityService<InvoiceStatus, InvoiceStatusData>
//    {
//        public InvoiceStatus Map(InvoiceStatusData invoice_status_data)
//        {
//            return new InvoiceStatus()
//            {
//                AccountKey = invoice_status_data.AccountKey,
//                CompanyKey = invoice_status_data.CompanyKey,
//                AccountTypeKey = invoice_status_data.AccountTypeKey,
//                AccountCode = invoice_status_data.AccountCode,
//                AccountName = invoice_status_data.AccountName,
//                AccountDesc = invoice_status_data.AccountDesc,
//                AccountDba = invoice_status_data.AccountDba,
//                AccountStartDate = invoice_status_data.AccountStartDate,
//                AccountEndDate = invoice_status_data.AccountEndDate,
//                AuditAddUserId = invoice_status_data.AuditAddUserId,
//                AuditAddDatetime = invoice_status_data.AuditAddDatetime,
//                AuditUpdateUserId = invoice_status_data.AuditUpdateUserId,
//                AuditUpdateDatetime = invoice_status_data.AuditUpdateDatetime,
//            };
//        }

//        public InvoiceStatusData Map(InvoiceStatus invoice_status)
//        {
//            return new InvoiceStatusData()
//            {
//                InvoiceStatusKey = invoice_status.InvoiceStatusKey,
//                InvoiceStatusCode = invoice_status.InvoiceStatusCode,
//                InvoiceStatusName = invoice_status.InvoiceStatusName,
//                InvoiceStatusType = invoice_status.InvoiceStatusType,
//                InvoiceStatusDesc = invoice_status.InvoiceStatusDesc,
//                AuditAddUserId = invoice_status.AuditAddUserId,
//                AuditAddDatetime = invoice_status.AuditAddDatetime,
//                AuditUpdateUserId = invoice_status.AuditUpdateUserId,
//                AuditUpdateDatetime = invoice_status.AuditUpdateDatetime,
//            };
//        }
//    }

//    public class LedgerEntityService : ILedgerEntityService, IEntityService<Ledger, LedgerData>
//    {
//        public Ledger Map(LedgerData ledger_data)
//        {
//            return new Ledger()
//            {
//                AccountKey = ledger_data.AccountKey,
//                CompanyKey = ledger_data.CompanyKey,
//                AccountTypeKey = ledger_data.AccountTypeKey,
//                AccountCode = ledger_data.AccountCode,
//                AccountName = ledger_data.AccountName,
//                AccountDesc = ledger_data.AccountDesc,
//                AccountDba = ledger_data.AccountDba,
//                AccountStartDate = ledger_data.AccountStartDate,
//                AccountEndDate = ledger_data.AccountEndDate,
//                AuditAddUserId = ledger_data.AuditAddUserId,
//                AuditAddDatetime = ledger_data.AuditAddDatetime,
//                AuditUpdateUserId = ledger_data.AuditUpdateUserId,
//                AuditUpdateDatetime = ledger_data.AuditUpdateDatetime,
//            };
//        }

//        public LedgerData Map(Ledger ledger)
//        {
//            return new LedgerData()
//            {
//                LedgerKey = ledger.LedgerKey,
//                CompanyKey = ledger.CompanyKey,
//                LedgerCode = ledger.LedgerCode,
//                LedgerName = ledger.LedgerName,
//                LedgerDesc = ledger.LedgerDesc,
//                AuditAddUserId = ledger.AuditAddUserId,
//                AuditAddDatetime = ledger.AuditAddDatetime,
//                AuditUpdateUserId = ledger.AuditUpdateUserId,
//                AuditUpdateDatetime = ledger.AuditUpdateDatetime,
//            };
//        }
//    }

//    public class LedgerTxnEntityService : ILedgerTxnEntityService, IEntityService<LedgerTxn, LedgerTxnData>
//    {
//        public LedgerTxn Map(LedgerTxnData ledger_txn_data)
//        {
//            return new LedgerTxn()
//            {
//                AccountKey = ledger_txn_data.AccountKey,
//                CompanyKey = ledger_txn_data.CompanyKey,
//                AccountTypeKey = ledger_txn_data.AccountTypeKey,
//                AccountCode = ledger_txn_data.AccountCode,
//                AccountName = ledger_txn_data.AccountName,
//                AccountDesc = ledger_txn_data.AccountDesc,
//                AccountDba = ledger_txn_data.AccountDba,
//                AccountStartDate = ledger_txn_data.AccountStartDate,
//                AccountEndDate = ledger_txn_data.AccountEndDate,
//                AuditAddUserId = ledger_txn_data.AuditAddUserId,
//                AuditAddDatetime = ledger_txn_data.AuditAddDatetime,
//                AuditUpdateUserId = ledger_txn_data.AuditUpdateUserId,
//                AuditUpdateDatetime = ledger_txn_data.AuditUpdateDatetime,
//            };
//        }

//        public LedgerTxnData Map(LedgerTxn ledger_txn)
//        {
//            return new LedgerTxnData()
//            {
//                LedgerTxnKey = ledger_txn.LedgerTxnKey,
//                LedgerKey = ledger_txn.LedgerKey,
//                TxnComment = ledger_txn.TxnComment,
//                AcctFrom = ledger_txn.AcctFrom,
//                DeptFrom = ledger_txn.DeptFrom,
//                LobFrom = ledger_txn.LobFrom,
//                AcctTo = ledger_txn.AcctTo,
//                DeptTo = ledger_txn.DeptTo,
//                LobTo = ledger_txn.LobTo,
//                TxnNum = ledger_txn.TxnNum,
//                PostDate = ledger_txn.PostDate,
//                EntryDate = ledger_txn.EntryDate,
//                Credit = ledger_txn.Credit,
//                Debit = ledger_txn.Debit,
//                EntityKey = ledger_txn.EntityKey,
//                EntityTypeKey = ledger_txn.EntityTypeKey,
//                AuditAddUserId = ledger_txn.AuditAddUserId,
//                AuditAddDatetime = ledger_txn.AuditAddDatetime,
//                AuditUpdateUserId = ledger_txn.AuditUpdateUserId,
//                AuditUpdateDatetime = ledger_txn.AuditUpdateDatetime,
//            };
//        }
//    }

//    public class OrderHeaderEntityService : IOrderHeaderEntityService, IEntityService<OrderHeader, OrderHeaderData>
//    {
//        public OrderHeader Map(OrderHeaderData order_header_data)
//        {
//            return new OrderHeader()
//            {
//                AccountKey = order_header_data.AccountKey,
//                CompanyKey = order_header_data.CompanyKey,
//                AccountTypeKey = order_header_data.AccountTypeKey,
//                AccountCode = order_header_data.AccountCode,
//                AccountName = order_header_data.AccountName,
//                AccountDesc = order_header_data.AccountDesc,
//                AccountDba = order_header_data.AccountDba,
//                AccountStartDate = order_header_data.AccountStartDate,
//                AccountEndDate = order_header_data.AccountEndDate,
//                AuditAddUserId = order_header_data.AuditAddUserId,
//                AuditAddDatetime = order_header_data.AuditAddDatetime,
//                AuditUpdateUserId = order_header_data.AuditUpdateUserId,
//                AuditUpdateDatetime = order_header_data.AuditUpdateDatetime,
//            };
//        }

//        public OrderHeaderData Map(OrderHeader order_header)
//        {
//            return new OrderHeaderData()
//            {
//                OrderKey = order_header.OrderKey,
//                AccountKey = order_header.AccountKey,
//                AccountContactKey = order_header.AccountContactKey,
//                OrderNum = order_header.OrderNum,
//                OrderEntryDate = order_header.OrderEntryDate,
//                OrderStatusKey = order_header.OrderStatusKey,
//                OrderStatusDate = order_header.OrderStatusDate,
//                OrderShipDate = order_header.OrderShipDate,
//                AccountRepKey = order_header.AccountRepKey,
//                OrderCompleteDate = order_header.OrderCompleteDate,
//                OrderValueSum = order_header.OrderValueSum,
//                OrderItemCount = order_header.OrderItemCount,
//                DeliverByDate = order_header.DeliverByDate,
//                SalesRepKey = order_header.SalesRepKey,
//                AuditAddUserId = order_header.AuditAddUserId,
//                AuditAddDatetime = order_header.AuditAddDatetime,
//                AuditUpdateUserId = order_header.AuditUpdateUserId,
//                AuditUpdateDatetime = order_header.AuditUpdateDatetime,
//            };
//        }
//    }

//    public class OrderItemEntityService : IOrderItemEntityService, IEntityService<OrderItem, OrderItemData>
//    {
//        public OrderItem Map(OrderItemData order_item_data)
//        {
//            return new OrderItem()
//            {
//                AccountKey = order_item_data.AccountKey,
//                CompanyKey = order_item_data.CompanyKey,
//                AccountTypeKey = order_item_data.AccountTypeKey,
//                AccountCode = order_item_data.AccountCode,
//                AccountName = order_item_data.AccountName,
//                AccountDesc = order_item_data.AccountDesc,
//                AccountDba = order_item_data.AccountDba,
//                AccountStartDate = order_item_data.AccountStartDate,
//                AccountEndDate = order_item_data.AccountEndDate,
//                AuditAddUserId = order_item_data.AuditAddUserId,
//                AuditAddDatetime = order_item_data.AuditAddDatetime,
//                AuditUpdateUserId = order_item_data.AuditUpdateUserId,
//                AuditUpdateDatetime = order_item_data.AuditUpdateDatetime,
//            };
//        }

//        public OrderItemData Map(OrderItem order_item)
//        {
//            return new OrderItemData()
//            {
//                OrderItemKey = order_item.OrderItemKey,
//                OrderKey = order_item.OrderKey,
//                OrderItemSeq = order_item.OrderItemSeq,
//                ProductKey = order_item.ProductKey,
//                ProductName = order_item.ProductName,
//                ProductDesc = order_item.ProductDesc,
//                OrderItemQuantity = order_item.OrderItemQuantity,
//                ShiptoAddrKey = order_item.ShiptoAddrKey,
//                BilltoAddrKey = order_item.BilltoAddrKey,
//                OrderItemShipDate = order_item.OrderItemShipDate,
//                OrderItemCompleteDate = order_item.OrderItemCompleteDate,
//                OrderItemPricePer = order_item.OrderItemPricePer,
//                OrderItemLineSum = order_item.OrderItemLineSum,
//                OrderItemAcctRepKey = order_item.OrderItemAcctRepKey,
//                OrderItemSalesRepKey = order_item.OrderItemSalesRepKey,
//                OrderItemStatusKey = order_item.OrderItemStatusKey,
//                AuditAddUserId = order_item.AuditAddUserId,
//                AuditAddDatetime = order_item.AuditAddDatetime,
//                AuditUpdateUserId = order_item.AuditUpdateUserId,
//                AuditUpdateDatetime = order_item.AuditUpdateDatetime,
//            };
//        }
//    }

//    public class OrderStatusEntityService : IOrderStatusEntityService, IEntityService<OrderStatus, OrderStatusData>
//    {
//        public OrderStatus Map(OrderStatusData order_status_data)
//        {
//            return new OrderStatus()
//            {
//                AccountKey = order_status_data.AccountKey,
//                CompanyKey = order_status_data.CompanyKey,
//                AccountTypeKey = order_status_data.AccountTypeKey,
//                AccountCode = order_status_data.AccountCode,
//                AccountName = order_status_data.AccountName,
//                AccountDesc = order_status_data.AccountDesc,
//                AccountDba = order_status_data.AccountDba,
//                AccountStartDate = order_status_data.AccountStartDate,
//                AccountEndDate = order_status_data.AccountEndDate,
//                AuditAddUserId = order_status_data.AuditAddUserId,
//                AuditAddDatetime = order_status_data.AuditAddDatetime,
//                AuditUpdateUserId = order_status_data.AuditUpdateUserId,
//                AuditUpdateDatetime = order_status_data.AuditUpdateDatetime,
//            };
//        }

//        public OrderStatusData Map(OrderStatus order_status)
//        {
//            return new OrderStatusData()
//            {
//                OrderStatusKey = order_status.OrderStatusKey,
//                OrderStatusCode = order_status.OrderStatusCode,
//                OrderStatusName = order_status.OrderStatusName,
//                OrderStatusType = order_status.OrderStatusType,
//                OrderStatusDesc = order_status.OrderStatusDesc,
//                AuditAddUserId = order_status.AuditAddUserId,
//                AuditAddDatetime = order_status.AuditAddDatetime,
//                AuditUpdateUserId = order_status.AuditUpdateUserId,
//                AuditUpdateDatetime = order_status.AuditUpdateDatetime,
//            };
//        }
//    }

//    public class PersonEntityService : IPersonEntityService, IEntityService<Person, PersonData>
//    {
//        public Person Map(PersonData person_data)
//        {
//            return new Person()
//            {
//                AccountKey = person_data.AccountKey,
//                CompanyKey = person_data.CompanyKey,
//                AccountTypeKey = person_data.AccountTypeKey,
//                AccountCode = person_data.AccountCode,
//                AccountName = person_data.AccountName,
//                AccountDesc = person_data.AccountDesc,
//                AccountDba = person_data.AccountDba,
//                AccountStartDate = person_data.AccountStartDate,
//                AccountEndDate = person_data.AccountEndDate,
//                AuditAddUserId = person_data.AuditAddUserId,
//                AuditAddDatetime = person_data.AuditAddDatetime,
//                AuditUpdateUserId = person_data.AuditUpdateUserId,
//                AuditUpdateDatetime = person_data.AuditUpdateDatetime,
//            };
//        }

//        public PersonData Map(Person person)
//        {
//            return new PersonData()
//            {
//                PersonKey = person.PersonKey,
//                PersonCode = person.PersonCode,
//                PersonFirstName = person.PersonFirstName,
//                PersonMi = person.PersonMi,
//                PersonLastName = person.PersonLastName,
//                ParentPersonKey = person.ParentPersonKey,
//                PersonDob = person.PersonDob,
//                AuditAddUserId = person.AuditAddUserId,
//                AuditAddDatetime = person.AuditAddDatetime,
//                AuditUpdateUserId = person.AuditUpdateUserId,
//                AuditUpdateDatetime = person.AuditUpdateDatetime,
//            };
//        }
//    }

//    public class PersonTypeEntityService : IPersonTypeEntityService, IEntityService<PersonType, PersonTypeData>
//    {
//        public PersonType Map(PersonTypeData person_type_data)
//        {
//            return new PersonType()
//            {
//                AccountKey = person_type_data.AccountKey,
//                CompanyKey = person_type_data.CompanyKey,
//                AccountTypeKey = person_type_data.AccountTypeKey,
//                AccountCode = person_type_data.AccountCode,
//                AccountName = person_type_data.AccountName,
//                AccountDesc = person_type_data.AccountDesc,
//                AccountDba = person_type_data.AccountDba,
//                AccountStartDate = person_type_data.AccountStartDate,
//                AccountEndDate = person_type_data.AccountEndDate,
//                AuditAddUserId = person_type_data.AuditAddUserId,
//                AuditAddDatetime = person_type_data.AuditAddDatetime,
//                AuditUpdateUserId = person_type_data.AuditUpdateUserId,
//                AuditUpdateDatetime = person_type_data.AuditUpdateDatetime,
//            };
//        }

//        public PersonTypeData Map(PersonType person_type)
//        {
//            return new PersonTypeData()
//            {
//                PersonTypeKey = person_type.PersonTypeKey,
//                PersonTypeCategory = person_type.PersonTypeCategory,
//                PersonTypeCode = person_type.PersonTypeCode,
//                PersonTypeName = person_type.PersonTypeName,
//                PersonTypeDesc = person_type.PersonTypeDesc,
//                AuditAddUserId = person_type.AuditAddUserId,
//                AuditAddDatetime = person_type.AuditAddDatetime,
//                AuditUpdateUserId = person_type.AuditUpdateUserId,
//                AuditUpdateDatetime = person_type.AuditUpdateDatetime,
//            };
//        }
//    }

//    public class ProductEntityService : IProductEntityService, IEntityService<Product, ProductData>
//    {
//        public Product Map(ProductData product_data)
//        {
//            return new Product()
//            {
//                AccountKey = product_data.AccountKey,
//                CompanyKey = product_data.CompanyKey,
//                AccountTypeKey = product_data.AccountTypeKey,
//                AccountCode = product_data.AccountCode,
//                AccountName = product_data.AccountName,
//                AccountDesc = product_data.AccountDesc,
//                AccountDba = product_data.AccountDba,
//                AccountStartDate = product_data.AccountStartDate,
//                AccountEndDate = product_data.AccountEndDate,
//                AuditAddUserId = product_data.AuditAddUserId,
//                AuditAddDatetime = product_data.AuditAddDatetime,
//                AuditUpdateUserId = product_data.AuditUpdateUserId,
//                AuditUpdateDatetime = product_data.AuditUpdateDatetime,
//            };
//        }

//        public ProductData Map(Product product)
//        {
//            return new ProductData()
//            {
//                ProductKey = product.ProductKey,
//                ProductTypeKey = product.ProductTypeKey,
//                ProductCode = product.ProductCode,
//                ProductName = product.ProductName,
//                ProductDesc = product.ProductDesc,
//                ProductNameShort = product.ProductNameShort,
//                ProductNameLong = product.ProductNameLong,
//                ProductImagePath = product.ProductImagePath,
//                AuditAddUserId = product.AuditAddUserId,
//                AuditAddDatetime = product.AuditAddDatetime,
//                AuditUpdateUserId = product.AuditUpdateUserId,
//                AuditUpdateDatetime = product.AuditUpdateDatetime,
//            };
//        }
//    }

//    public class ProductTypeEntityService : IProductTypeEntityService, IEntityService<ProductType, ProductTypeData>
//    {
//        public ProductType Map(ProductTypeData product_type_data)
//        {
//            return new ProductType()
//            {
//                AccountKey = product_type_data.AccountKey,
//                CompanyKey = product_type_data.CompanyKey,
//                AccountTypeKey = product_type_data.AccountTypeKey,
//                AccountCode = product_type_data.AccountCode,
//                AccountName = product_type_data.AccountName,
//                AccountDesc = product_type_data.AccountDesc,
//                AccountDba = product_type_data.AccountDba,
//                AccountStartDate = product_type_data.AccountStartDate,
//                AccountEndDate = product_type_data.AccountEndDate,
//                AuditAddUserId = product_type_data.AuditAddUserId,
//                AuditAddDatetime = product_type_data.AuditAddDatetime,
//                AuditUpdateUserId = product_type_data.AuditUpdateUserId,
//                AuditUpdateDatetime = product_type_data.AuditUpdateDatetime,
//            };
//        }

//        public ProductTypeData Map(ProductType product_type)
//        {
//            return new ProductTypeData()
//            {
//                ProductTypeKey = product_type.ProductTypeKey,
//                ProductTypeCategory = product_type.ProductTypeCategory,
//                ProductTypeCode = product_type.ProductTypeCode,
//                ProductTypeName = product_type.ProductTypeName,
//                ProductTypeDesc = product_type.ProductTypeDesc,
//                AuditAddUserId = product_type.AuditAddUserId,
//                AuditAddDatetime = product_type.AuditAddDatetime,
//                AuditUpdateUserId = product_type.AuditUpdateUserId,
//                AuditUpdateDatetime = product_type.AuditUpdateDatetime,
//            };
//        }
//    }

//    public class VendorEntityService : IVendorEntityService, IEntityService<Vendor, VendorData>
//    {
//        public Vendor Map(VendorData vendor_data)
//        {
//            return new Vendor()
//            {
//                AccountKey = vendor_data.AccountKey,
//                CompanyKey = vendor_data.CompanyKey,
//                AccountTypeKey = vendor_data.AccountTypeKey,
//                AccountCode = vendor_data.AccountCode,
//                AccountName = vendor_data.AccountName,
//                AccountDesc = vendor_data.AccountDesc,
//                AccountDba = vendor_data.AccountDba,
//                AccountStartDate = vendor_data.AccountStartDate,
//                AccountEndDate = vendor_data.AccountEndDate,
//                AuditAddUserId = vendor_data.AuditAddUserId,
//                AuditAddDatetime = vendor_data.AuditAddDatetime,
//                AuditUpdateUserId = vendor_data.AuditUpdateUserId,
//                AuditUpdateDatetime = vendor_data.AuditUpdateDatetime,
//            };
//        }

//        public VendorData Map(Vendor vendor)
//        {
//            return new VendorData()
//            {
//                VendorKey = vendor.VendorKey,
//                VendorCode = vendor.VendorCode,
//                VendorName = vendor.VendorName,
//                VendorDesc = vendor.VendorDesc,
//                AuditAddUserId = vendor.AuditAddUserId,
//                AuditAddDatetime = vendor.AuditAddDatetime,
//                AuditUpdateUserId = vendor.AuditUpdateUserId,
//                AuditUpdateDatetime = vendor.AuditUpdateDatetime,
//            };
//        }
//    }

//} // namespace closer
