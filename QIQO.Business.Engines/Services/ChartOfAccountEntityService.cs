using QIQO.Business.Contracts;
using QIQO.Business.Entities;
using QIQO.Data.Entities;

namespace QIQO.Business.Engines
{

    public class ChartOfAccountEntityService : IChartOfAccountEntityService
    {
        public ChartOfAccount Map(ChartOfAccountsData chart_of_accounts_data)
        {
            return new ChartOfAccount()
            {
                ChartOfAccountKey = chart_of_accounts_data.CoaKey,
                CompanyKey = chart_of_accounts_data.CompanyKey,
                AccountNo = chart_of_accounts_data.AcctNo,
                AccountType = chart_of_accounts_data.AcctType,
                AccountName = chart_of_accounts_data.AcctName,
                BalanceType = chart_of_accounts_data.BalanceType,
                BankAccountFlag = chart_of_accounts_data.BankAcctFlg,
                AddedUserID = chart_of_accounts_data.AuditAddUserId,
                AddedDateTime = chart_of_accounts_data.AuditAddDatetime,
                UpdateUserID = chart_of_accounts_data.AuditUpdateUserId,
                UpdateDateTime = chart_of_accounts_data.AuditUpdateDatetime,
            };
        }

        public ChartOfAccountsData Map(ChartOfAccount chart_of_accounts)
        {
            return new ChartOfAccountsData()
            {
                CoaKey = chart_of_accounts.ChartOfAccountKey,
                CompanyKey = chart_of_accounts.CompanyKey,
                AcctNo = chart_of_accounts.AccountNo,
                AcctType = chart_of_accounts.AccountType,
                AcctName = chart_of_accounts.AccountName,
                BalanceType = chart_of_accounts.BalanceType,
                BankAcctFlg = chart_of_accounts.BankAccountFlag
            };
        }
    }
}