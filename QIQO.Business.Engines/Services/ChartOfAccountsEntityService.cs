using QIQO.Business.Contracts;
using QIQO.Business.Entities;
using QIQO.Data.Entities;

namespace QIQO.Business.Engines
{
    public class ChartOfAccountsEntityService : IChartOfAccountsEntityService
    {
        public ChartOfAccount Map(ChartOfAccountsData chart_of_account_data)
        {
            ChartOfAccount chart_of_account = new ChartOfAccount()
            {
                ChartOfAccountKey = chart_of_account_data.CoaKey,
                AccountNo = chart_of_account_data.AcctNo,
                AccountType = chart_of_account_data.AcctType,
                AccountName = chart_of_account_data.AcctName,
                BalanceType = chart_of_account_data.BalanceType,
                BankAccountFlag = chart_of_account_data.BankAcctFlg,
                CompanyKey = chart_of_account_data.CompanyKey,
                AddedUserID = chart_of_account_data.AuditAddUserId,
                AddedDateTime = chart_of_account_data.AuditAddDatetime,
                UpdateUserID = chart_of_account_data.AuditUpdateUserId,
                UpdateDateTime = chart_of_account_data.AuditUpdateDatetime
            };

            return chart_of_account;
        }

        public ChartOfAccountsData Map(ChartOfAccount chart_of_account)
        {
            ChartOfAccountsData chart_of_account_data = new ChartOfAccountsData()
            {
                CoaKey = chart_of_account.ChartOfAccountKey,
                AcctNo = chart_of_account.AccountNo,
                AcctType = chart_of_account.AccountType,
                AcctName = chart_of_account.AccountName,
                BalanceType = chart_of_account.BalanceType,
                BankAcctFlg = chart_of_account.BankAccountFlag,
                CompanyKey = chart_of_account.CompanyKey
            };

            return chart_of_account_data;
        }
    }
}
