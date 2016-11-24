using QIQO.Business.Contracts;
using QIQO.Business.Entities;
using QIQO.Common.Contracts;
using QIQO.Data.Entities;

namespace QIQO.Business.Engines
{
    public class CompanyEntityService : ICompanyEntityService
    {
        public Company Map(CompanyData comp_data)
        {
            return new Company()
            {
                CompanyKey = comp_data.CompanyKey,
                CompanyCode = comp_data.CompanyCode,
                CompanyName = comp_data.CompanyName,
                CompanyDesc = comp_data.CompanyDesc,
                AddedUserID = comp_data.AuditAddUserId,
                AddedDateTime = comp_data.AuditAddDatetime,
                UpdateUserID = comp_data.AuditUpdateUserId,
                UpdateDateTime = comp_data.AuditUpdateDatetime
            };
        }

        public CompanyData Map(Company company)
        {
            return new CompanyData()
            {
                CompanyKey = company.CompanyKey,
                CompanyCode = company.CompanyCode,
                CompanyName = company.CompanyName,
                CompanyDesc = company.CompanyDesc
            };
        }
    }
}
