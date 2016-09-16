using QIQO.Common.Contracts;
using QIQO.Data.Entities;
using System.Collections.Generic;

namespace QIQO.Data.Interfaces
{
    public interface IChartOfAccountsRepository : IRepository<ChartOfAccountsData>
    {
        IEnumerable<ChartOfAccountsData> GetAll(CompanyData company);
        IEnumerable<ChartOfAccountsData> GetAll(string company_code);
    }
}