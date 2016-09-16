using QIQO.Business.Entities;
using QIQO.Common.Contracts;
using QIQO.Data.Entities;

namespace QIQO.Business.Contracts
{
    public interface ICompanyEntityService : IEntityService
    {
        Company Map(CompanyData account_data);
        CompanyData Map(Company account);
    }
}