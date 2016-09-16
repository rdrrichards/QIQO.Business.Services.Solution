using QIQO.Business.Entities;
using QIQO.Common.Contracts;
using System.Collections.Generic;

namespace QIQO.Business.Contracts
{
    public interface IChartOfAccountBusinessEngine : IBusinessEngine
    {
        bool ChartOfAccountDelete(ChartOfAccount chart_of_account);
        int ChartOfAccountSave(ChartOfAccount chart_of_accounts);
        ChartOfAccount GetChartOfAccountByCode(string chart_of_accounts_code, Company company);
        ChartOfAccount GetChartOfAccountByCode(string chart_of_accounts_code, string company_code);
        ChartOfAccount GetChartOfAccountByID(int chart_of_accounts_key);
        List<ChartOfAccount> GetChartOfAccountsByCompany(Company company);
    }
}