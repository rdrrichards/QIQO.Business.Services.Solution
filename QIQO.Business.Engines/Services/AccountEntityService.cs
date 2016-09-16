using QIQO.Business.Contracts;
using QIQO.Business.Entities;
using QIQO.Data.Entities;

namespace QIQO.Business.Engines
{
    public class AccountEntityService : IAccountEntityService
    {
        public Account Map(AccountData account_data)
        {
            Account account = new Account()
            {
                AccountKey = account_data.AccountKey,
                CompanyKey = account_data.CompanyKey,
                AccountType = (QIQOAccountType)account_data.AccountTypeKey,
                AccountCode = account_data.AccountCode,
                AccountName = account_data.AccountName,
                AccountDBA = account_data.AccountDba,
                AccountDesc = account_data.AccountDesc,
                AccountStartDate = account_data.AccountStartDate,
                AccountEndDate = account_data.AccountEndDate,
                AddedUserID = account_data.AuditAddUserId,
                AddedDateTime = account_data.AuditAddDatetime,
                UpdateUserID = account_data.AuditUpdateUserId,
                UpdateDateTime = account_data.AuditUpdateDatetime
            };
            
            return account;
        }

        public AccountData Map(Account account)
        {
            AccountData account_data = new AccountData()
            {
                AccountKey = account.AccountKey,
                CompanyKey = account.CompanyKey,
                AccountTypeKey = (int)account.AccountType,
                AccountCode = account.AccountCode,
                AccountName = account.AccountName,
                AccountDba = account.AccountDBA,
                AccountDesc = account.AccountDesc,
                AccountStartDate = account.AccountStartDate,
                AccountEndDate = account.AccountEndDate
            };

            return account_data;
        }

        public AccountType Map(AccountTypeData account_type_data)
        {
            AccountType account_type = new AccountType()
            {
                AccountTypeKey = account_type_data.AccountTypeKey,
                AccountTypeCode = account_type_data.AccountTypeCode,
                AccountTypeName = account_type_data.AccountTypeName,
                AccountTypeDesc = account_type_data.AccountTypeDesc,
                AddedUserID = account_type_data.AuditAddUserId,
                AddedDateTime = account_type_data.AuditAddDatetime,
                UpdateUserID = account_type_data.AuditUpdateUserId,
                UpdateDateTime = account_type_data.AuditUpdateDatetime
            };

            return account_type;
        }

        public AccountTypeData Map(AccountType account_type)
        {
            AccountTypeData account_type_data = new AccountTypeData()
            {
                AccountTypeKey = account_type.AccountTypeKey,
                AccountTypeCode = account_type.AccountTypeCode,
                AccountTypeName = account_type.AccountTypeName,
                AccountTypeDesc = account_type.AccountTypeDesc
            };

            return account_type_data;
        }

        public AccountPerson Map(PersonData emp_data)
        {
            AccountPerson employee = new AccountPerson(QIQOPersonType.AccountEmployee)
            {
                PersonKey = emp_data.PersonKey,
                PersonCode = emp_data.PersonCode,
                PersonFirstName = emp_data.PersonFirstName,
                PersonLastName = emp_data.PersonLastName,
                PersonDOB = emp_data.PersonDob,
                PersonMI = emp_data.PersonMi,
                AddedUserID = emp_data.AuditAddUserId,
                AddedDateTime = emp_data.AuditAddDatetime,
                UpdateUserID = emp_data.AuditUpdateUserId,
                UpdateDateTime = emp_data.AuditUpdateDatetime
            };
            return employee;
        }

        public AccountPerson Map(EntityPersonData emp_data)
        {
            AccountPerson employee = new AccountPerson()
            {
                PersonKey = emp_data.PersonKey,
                Comment = emp_data.Comment,
                StartDate = emp_data.StartDate,
                EndDate = emp_data.EndDate,
                CompanyRoleType = (QIQOPersonType)emp_data.PersonTypeKey,
                RoleInCompany = emp_data.PersonRole,
                EntityPersonKey = emp_data.EntityPersonKey,
                AddedUserID = emp_data.AuditAddUserId,
                AddedDateTime = emp_data.AuditAddDatetime,
                UpdateUserID = emp_data.AuditUpdateUserId,
                UpdateDateTime = emp_data.AuditUpdateDatetime
            };
            return employee;
        }
    }
}
