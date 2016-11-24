using QIQO.Business.Contracts;
using QIQO.Business.Entities;
using QIQO.Data.Entities;

namespace QIQO.Business.Engines
{
    public class AccountEntityService : IAccountEntityService
    {
        public Account Map(AccountData account_data)
        {
            return new Account()
            {
                AccountKey = account_data.AccountKey,
                CompanyKey = account_data.CompanyKey,
                AccountType = (QIQOAccountType)account_data.AccountTypeKey,
                AccountCode = account_data.AccountCode,
                AccountName = account_data.AccountName,
                AccountDesc = account_data.AccountDesc,
                AccountDBA = account_data.AccountDba,
                AccountStartDate = account_data.AccountStartDate,
                AccountEndDate = account_data.AccountEndDate,
                AddedUserID = account_data.AuditAddUserId,
                AddedDateTime = account_data.AuditAddDatetime,
                UpdateUserID = account_data.AuditUpdateUserId,
                UpdateDateTime = account_data.AuditUpdateDatetime,
            };
        }

        public AccountData Map(Account account)
        {
            return new AccountData()
            {
                AccountKey = account.AccountKey,
                CompanyKey = account.CompanyKey,
                AccountTypeKey = (int)account.AccountType,
                AccountCode = account.AccountCode,
                AccountName = account.AccountName,
                AccountDesc = account.AccountDesc,
                AccountDba = account.AccountDBA,
                AccountStartDate = account.AccountStartDate,
                AccountEndDate = account.AccountEndDate
            };
        }

        public AccountPerson Map(PersonData emp_data)
        {
            return new AccountPerson(QIQOPersonType.AccountEmployee)
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
        }

        public AccountPerson Map(EntityPersonData emp_data)
        {
            return new AccountPerson()
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
        }
    }
}