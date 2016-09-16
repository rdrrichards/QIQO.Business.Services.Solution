using QIQO.Common.Contracts;
using QIQO.Data.Entities;
using System.Collections.Generic;

namespace QIQO.Data.Interfaces
{
    public interface ICompanyRepository : IRepository<CompanyData>
    {
        IEnumerable<CompanyData> GetAll(PersonData person);
        string GetNextNumber(CompanyData company, int number_type);
    }
}