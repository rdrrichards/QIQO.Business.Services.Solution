using QIQO.Business.Contracts;
using QIQO.Business.Entities;
using QIQO.Data.Entities;

namespace QIQO.Business.Engines
{

    public class AccountTypeEntityService : IAccountTypeEntityService
    {
        public AccountType Map(AccountTypeData account_type_data)
        {
            return new AccountType()
            {
                AccountTypeKey = account_type_data.AccountTypeKey,
                AccountTypeCode = account_type_data.AccountTypeCode,
                AccountTypeName = account_type_data.AccountTypeName,
                AccountTypeDesc = account_type_data.AccountTypeDesc,
                AddedUserID = account_type_data.AuditAddUserId,
                AddedDateTime = account_type_data.AuditAddDatetime,
                UpdateUserID = account_type_data.AuditUpdateUserId,
                UpdateDateTime = account_type_data.AuditUpdateDatetime,
            };
        }

        public AccountTypeData Map(AccountType account_type)
        {
            return new AccountTypeData()
            {
                AccountTypeKey = account_type.AccountTypeKey,
                AccountTypeCode = account_type.AccountTypeCode,
                AccountTypeName = account_type.AccountTypeName,
                AccountTypeDesc = account_type.AccountTypeDesc
            };
        }
    }
}